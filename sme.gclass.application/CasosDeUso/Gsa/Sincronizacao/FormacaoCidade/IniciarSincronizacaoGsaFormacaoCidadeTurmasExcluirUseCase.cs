using MediatR;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSincronizacaoGsaFormacaoCidadeTurmasExcluirUseCase : IIniciarSincronizacaoGsaFormacaoCidadeTurmasExcluirUseCase
    {
        private readonly IMediator mediator;

        public IniciarSincronizacaoGsaFormacaoCidadeTurmasExcluirUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(string cursosIds)
        {
            try
            {
                foreach (var curso in cursosIds.Split(","))
                    await mediator.Send(new ExcluirCursoGoogleCommand(long.Parse(curso)));
            }
            catch (Exception ex)
            {
                await mediator.Send(new SalvarLogViaRabbitCommand($"turmas/excluir - {ex.Message}", LogNivel.Critico, LogContexto.FormacaoCidade, cursosIds));
            }
            return true;
        }
    }
}