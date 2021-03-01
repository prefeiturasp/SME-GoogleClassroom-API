using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosNovosQuery : IRequest<PaginacaoResultadoDto<Aluno>>
    {
        public ObterAlunosNovosQuery(Paginacao paginacao)
        {
            this.Paginacao = paginacao;
        }

        public Paginacao Paginacao { get; set; }
    }
}
