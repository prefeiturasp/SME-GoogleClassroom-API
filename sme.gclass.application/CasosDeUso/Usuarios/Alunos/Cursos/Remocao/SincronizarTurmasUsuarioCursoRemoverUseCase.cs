using MediatR;
using SME.GoogleClassroom.Infra;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizarTurmasUsuarioCursoRemoverUseCase : ISincronizarTurmasUsuarioCursoRemoverUseCase
    {
        private readonly IMediator mediator;

        public SincronizarTurmasUsuarioCursoRemoverUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<FiltroTurmaRemoverUsuarioCursoDto>();
            foreach (var turmaId in dto.TurmasIds)
            {
                var alunosCodigos = await mediator.Send(new ObterAlunosCodigosInativosPorAnoLetivoETurmaQuery(dto.AnoLetivo, turmaId, dto.DataReferencia));
                if(alunosCodigos != null && alunosCodigos.Any())
                {
                    var alunos = new AlunosUsuarioTurmaRemoverDto(alunosCodigos, turmaId);
                    /**TODO criar fila e associar o useCase*/
                    //await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaUsuariosCursosRemoverTurmasSync, RotasRabbit.FilaGsaUsuariosCursosRemoverTurmasSync, alunos));
                }
            }
            return true;
        }
    }
}
