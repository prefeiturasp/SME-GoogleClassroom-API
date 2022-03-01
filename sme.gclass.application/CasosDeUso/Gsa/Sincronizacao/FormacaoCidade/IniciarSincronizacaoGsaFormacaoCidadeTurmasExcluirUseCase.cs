using MediatR;
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

        public async Task<bool> Executar(long[] cursosIds)
        {
            foreach (var curso in cursosIds)
                await mediator.Send(new ExcluirCursoGoogleCommand(curso));
            return true;
        }
    }
}