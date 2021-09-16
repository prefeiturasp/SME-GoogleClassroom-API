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

        public async Task<bool> Executar(string codigo, string cpf, bool processarProfessoresEFuncionarios, bool processarFuncionariosIndiretos)
        {
            var dto = new FiltroInativarProfessoresEFuncionariosDto(codigo, cpf, processarProfessoresEFuncionarios, processarFuncionariosIndiretos);
            return await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCarregarProfessoresEFuncionariosInativar, dto));
        }
    }
}
