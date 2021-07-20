using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAtividadesDoCursoGoogleQuery : IRequest<PaginaConsultaAtividadesGsaDto>
    {
        public ObterAtividadesDoCursoGoogleQuery(CursoDto curso, string tokenProximaPagina = "")
        {
            Curso = curso;
            TokenProximaPagina = tokenProximaPagina;
        }

        public CursoDto Curso { get; }
        public string TokenProximaPagina { get; }
    }
}
