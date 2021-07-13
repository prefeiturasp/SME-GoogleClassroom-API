using MediatR;
using SME.GoogleClassroom.Aplicacao.Queries;
using SME.GoogleClassroom.Infra;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizarInativacaoUsuarioGsaUseCase : ISincronizarInativacaoUsuarioGsaUseCase
    {
        private readonly IMediator mediator;

        public SincronizarInativacaoUsuarioGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<FiltroTurmaUsuarioInativoDto>();
            foreach (var turmaId in dto.TurmasIds)
            {
                var alunosCodigos = await mediator.Send(new ObterCodigosAlunosInativosPorAnoLetivoETurmaQuery(dto.AnoLetivo, turmaId, dto.DataReferencia));
                if (alunosCodigos != null && alunosCodigos.Any())
                {
                    //var alunos = new AlunosCursoUsuarioRemovidoTurmaDto(alunosCodigos, turmaId);
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaInativarUsuarioTratar, RotasRabbit.FilaGsaInativarUsuarioTratar, alunos));
                }
            }
            return true;
        }
    }
}
