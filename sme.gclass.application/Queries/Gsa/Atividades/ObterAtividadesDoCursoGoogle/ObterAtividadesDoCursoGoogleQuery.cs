using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAtividadesDoCursoGoogleQuery : IRequest<PaginaConsultaAtividadesGsaDto>
    {
        public ObterAtividadesDoCursoGoogleQuery(CursoGsaManualmenteDto curso, string tokenProximaPagina = "")
        {
            Curso = curso;
            TokenProximaPagina = tokenProximaPagina;
        }

        public CursoGsaManualmenteDto Curso { get; }
        public string TokenProximaPagina { get; }
    }
}
