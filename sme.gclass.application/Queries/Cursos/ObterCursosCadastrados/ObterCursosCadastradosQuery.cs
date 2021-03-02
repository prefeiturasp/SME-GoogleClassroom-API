using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosCadastradosQuery : IRequest<PaginacaoResultadoDto<Curso>>
    {
        public ObterCursosCadastradosQuery(Paginacao paginacacao, long? turmaId, long? componenteCurricularId, long? cursoId, string emailCriador)
        {
            this.Paginacacao = paginacacao;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            CursoId = cursoId;
            EmailCriador = emailCriador;
        }

        public Paginacao Paginacacao { get; set; }
        public long? TurmaId { get; set; }
        public long? ComponenteCurricularId { get; set; }
        public long? CursoId { get; set; }
        public string EmailCriador { get; set; }
    }
}
