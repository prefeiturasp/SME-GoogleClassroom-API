using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCadastradosQuery : IRequest<PaginacaoResultadoDto<Usuario>>
    {
        public ObterAlunosCadastradosQuery(Paginacao paginacao, long? codigoEol, string email)
        {
            Paginacao = paginacao;
            CodigoEol = codigoEol;
            Email = email;
        }

        public Paginacao Paginacao { get; set; }
        public long? CodigoEol { get; set; }
        public string Email { get; set; }
    }
}
