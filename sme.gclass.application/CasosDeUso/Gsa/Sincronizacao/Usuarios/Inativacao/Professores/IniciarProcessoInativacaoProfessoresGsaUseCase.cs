using MediatR;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarProcessoInativacaoProfessoresGsaUseCase : IIniciarInativacaoProfessoresEFuncionariosUseCase
    {
        private readonly IMediator mediator;

        public IniciarProcessoInativacaoProfessoresGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(string rf, string cpf)
        {
            var dto = new FiltroInativarProfessoresEFuncionariosDto(rf, cpf);
            return await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCarregarProfessoresEFuncionariosInativar, dto));
        }
    }
}
