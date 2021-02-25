using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosCadastradosQuery : IRequest<PaginacaoResultadoDto<Curso>>
    {
        public ObterCursosCadastradosQuery(Paginacao paginacacao)
        {
            this.Paginacacao = paginacacao;
        }

        public Paginacao Paginacacao { get; set; }
    }
}
