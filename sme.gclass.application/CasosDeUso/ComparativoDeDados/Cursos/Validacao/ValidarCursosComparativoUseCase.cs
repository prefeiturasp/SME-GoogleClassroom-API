using MediatR;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ValidarCursosComparativoUseCase : IValidarCursosComparativoUseCase
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public ValidarCursosComparativoUseCase(IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
        {
            this.mediator = mediator;
            this.policy = registry.Get<IAsyncPolicy>("RetryComparativoDeDadosPolicy");
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
            => await policy.ExecuteAsync(() => ValidarCursosComparativoAsync());

        private async Task<bool> ValidarCursosComparativoAsync()
        {
            if (await mediator.Send(new VerificarSeExistemMensagemNaFilaQuery(RotasRabbit.FilaCursoComparativoAtualizar)))
                throw new NegocioException("Não é possível iniciar a validação de cursos comparativo. Ainda existem itens na fila de atualização.");

            await mediator.Send(new ValidarCursosExistentesCursosComparativosCommand());
            return true;
        }
    }
}