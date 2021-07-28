using MediatR;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarProcessoInativacaoUsuariosGsaUseCase : IIniciarProcessoInativacaoUsuariosGsaUseCase
    {
        private readonly IMediator mediator;

        public IniciarProcessoInativacaoUsuariosGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(long? alunoId = null)
        {
            var dto = new FiltroInativacaoUsuariosCursosGoogleDto(alunoId);
            return await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaInativarUsuarioCarregar, RotasRabbit.FilaGsaInativarUsuarioCarregar, dto));
        }
    }
}