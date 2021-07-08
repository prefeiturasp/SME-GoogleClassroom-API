using MediatR;
using SME.GoogleClassroom.Infra;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizarTurmasCursoUsuarioRemovidoUseCase : ISincronizarTurmasCursoUsuarioRemovidoUseCase
    {
        private readonly IMediator mediator;

        public SincronizarTurmasCursoUsuarioRemovidoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<FiltroTurmaRemoverCursoUsuarioDto>();
            foreach (var turmaId in dto.TurmasIds)
            {
                var alunosCodigos = await mediator.Send(new ObterAlunosCodigosInativosPorAnoLetivoETurmaQuery(dto.AnoLetivo, turmaId, dto.DataReferencia));
                if(alunosCodigos != null && alunosCodigos.Any())
                {
                    var alunos = new AlunosCursoUsuarioRemovidoTurmaDto(alunosCodigos, turmaId);
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoAlunosTratar, RotasRabbit.FilaGsaCursoUsuarioRemovidoAlunosTratar, alunos));
                }
            }
            return true;
        }
    }
}
