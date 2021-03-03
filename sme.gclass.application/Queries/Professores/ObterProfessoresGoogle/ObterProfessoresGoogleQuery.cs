using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresGoogleQuery : IRequest<PaginacaoResultadoDto<ProfessorGoogle>>
    {
        public ObterProfessoresGoogleQuery(Paginacao paginacao, long? rf, string email)
        {
            Paginacao = paginacao;
            Rf = rf;
            Email = email;
        }

        public Paginacao Paginacao { get; set; }
        public long? Rf { get; set; }
        public string Email { get; set; }
    }
}
