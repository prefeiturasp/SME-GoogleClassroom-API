using Google;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System;
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
            try
            {
                foreach (var curso in cursosIds.Split(","))
                {
                    var cursoId = long.Parse(curso);
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
                }
            }
            catch (Exception ex)
            {
                await mediator.Send(new SalvarLogViaRabbitCommand($"turmas/excluir - {ex.Message}", LogNivel.Critico, LogContexto.FormacaoCidade, cursosIds));
            }
            return true;
        }
    }
}