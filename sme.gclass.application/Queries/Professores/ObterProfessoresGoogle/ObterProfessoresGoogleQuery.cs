using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresGoogleQuery : IRequest<PaginacaoResultadoDto<ProfessorGoogle>>
    {
        public ObterProfessoresGoogleQuery(Paginacao paginacao)
        {
            Paginacao = paginacao;
        }

        public Paginacao Paginacao { get; set; }
    }
}
