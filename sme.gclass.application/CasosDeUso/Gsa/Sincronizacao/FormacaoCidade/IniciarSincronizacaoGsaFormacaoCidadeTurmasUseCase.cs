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
            foreach (var cursoId in cursosIds)
                await mediator.Send(new ExcluirCursoGoogleCommand(cursoId));
            return true;
        }
    }
}
