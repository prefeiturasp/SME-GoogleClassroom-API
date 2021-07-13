using MediatR;
using SME.GoogleClassroom.Infra;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizarTurmasInativacaoUsuarioUseCase : ISincronizarTurmasInativacaoUsuarioUseCase
    {
        private readonly IMediator mediator;

        public SincronizarTurmasInativacaoUsuarioUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<FiltroTurmaInativacaoUsuarioDto>();
            foreach (var turmaId in dto.TurmasIds)
            {
                var alunosCodigos = await mediator.Send(new ObterAlunosCodigosInativosPorAnoLetivoETurmaQuery(dto.AnoLetivo, turmaId, dto.DataReferencia, false));
                if (alunosCodigos != null && alunosCodigos.Any())
                {
                    var alunosCodigosComCurso = await mediator.Send(new ObterAlunosCodigosComRegistroEmCursosQuery(alunosCodigos));
                    if (alunosCodigosComCurso != null && alunosCodigosComCurso.Any())
                    {
                        var alunos = new AlunosInativacaoUsuarioTurmaDto(alunosCodigosComCurso, turmaId);
                        await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaInativarUsuarioTratar, RotasRabbit.FilaGsaInativarUsuarioTratar, alunos));
                    }
                }
            }
            return true;
        }
    }
}
