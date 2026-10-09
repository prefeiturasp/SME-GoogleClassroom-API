using Google;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSincronizacaoGsaFormacaoCidadeTurmasExcluirUseCase : IIniciarSincronizacaoGsaFormacaoCidadeTurmasExcluirUseCase
    {
        private readonly IMediator mediator;

        public IniciarSincronizacaoGsaFormacaoCidadeTurmasExcluirUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(string cursosIds)
        {
            if (string.IsNullOrWhiteSpace(cursosIds))
                throw new NegocioException("É necessário informar ao menos um curso para exclusão.");

            var cursos = cursosIds.Split(",", StringSplitOptions.RemoveEmptyEntries)
                                  .Select(c => c.Trim())
                                  .Where(c => !string.IsNullOrEmpty(c))
                                  .ToList();

            if (!cursos.Any())
                throw new NegocioException("É necessário informar ao menos um curso para exclusão.");

            var falhas = new List<string>();

            foreach (var cursoStr in cursos)
            {
                if (!long.TryParse(cursoStr, out var cursoId))
                {
                    falhas.Add($"Curso '{cursoStr}': Identificador inválido.");
                    await mediator.Send(new SalvarLogViaRabbitCommand($"turmas/excluir - Curso '{cursoStr}': Identificador inválido.", LogNivel.Critico, LogContexto.FormacaoCidade, cursoStr));
                    continue;
                }

                try
                {
                    var excluido = false;
                    try
                    {
                        excluido = await mediator.Send(new ExcluirCursoGoogleCommand(cursoId));
                    }
                    catch (GoogleApiException ex) when (ex.HttpStatusCode == HttpStatusCode.NotFound)
                    {
                        excluido = true;
                    }

                    if (excluido)
                    {
                        await mediator.Send(new ExcluirCursoGsaCommand(cursoId));
                    }
                    else
                    {
                        falhas.Add($"Curso {cursoId}: Não foi possível excluir no Google Classroom.");
                        await mediator.Send(new SalvarLogViaRabbitCommand($"turmas/excluir - Curso {cursoId}: Não foi possível excluir no Google Classroom.", LogNivel.Critico, LogContexto.FormacaoCidade, cursoId.ToString()));
                    }
                }
                catch (Exception ex)
                {
                    falhas.Add($"Curso {cursoId}: {ex.Message}");
                    await mediator.Send(new SalvarLogViaRabbitCommand($"turmas/excluir - Curso {cursoId}: {ex.Message}", LogNivel.Critico, LogContexto.FormacaoCidade, cursoId.ToString()));
                }
            }

            if (falhas.Any())
                throw new NegocioException(falhas);

            return true;
        }
    }
}