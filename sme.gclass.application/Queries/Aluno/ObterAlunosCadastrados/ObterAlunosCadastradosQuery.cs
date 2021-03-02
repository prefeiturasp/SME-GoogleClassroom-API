using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCadastradosQuery : IRequest<PaginacaoResultadoDto<AlunoGoogle>>
    {
        public ObterAlunosCadastradosQuery(Paginacao paginacao)
        {
            this.Paginacao = paginacao;
        }

        public Paginacao Paginacao { get; set; }
    }
}
