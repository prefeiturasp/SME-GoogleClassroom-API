using MediatR;
using Sentry;
using SME.GoogleClassroom.Infra;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarAlunosInativacaoUsuarioGsaUseCase : ITratarAlunosInativacaoUsuarioUseCase
    {
        private readonly IMediator mediator;

        public TratarAlunosInativacaoUsuarioGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<FiltroAlunoInativacaoUsuarioDto>();
            var alunosCodigos = dto.AlunosIds.ToArray();
            var alunosGoogle = await mediator.Send(new ObterAlunosPorCodigosQuery(alunosCodigos));

            if (alunosGoogle != null && alunosGoogle.Any())
            {
                foreach (var alunoGoogle in alunosGoogle)
                {
                    var alunoInativar = new AlunoUsuarioInativarDto(alunoGoogle.Codigo, alunoGoogle.Indice, alunoGoogle.Email);
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaInativarUsuarioIncluir, RotasRabbit.FilaGsaInativarUsuarioIncluir, alunoInativar));
                }
                return true;
            }
            else
            {
                SentrySdk.CaptureMessage($"Não foi possível localizar os usuários (alunos) pelos códigos {string.Join(", ", alunosCodigos)} no GSA");
                return false;
            }
        }
    }
}