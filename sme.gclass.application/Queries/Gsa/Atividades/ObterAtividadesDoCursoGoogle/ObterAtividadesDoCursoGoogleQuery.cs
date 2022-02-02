using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAtividadesDoCursoGoogleQuery : IRequest<PaginaConsultaAtividadesGsaDto>
    {
        public ObterAtividadesDoCursoGoogleQuery(CursoGsaId curso, string tokenProximaPagina = "")
        {
            Curso = curso;
            TokenProximaPagina = tokenProximaPagina;
        }

        public CursoGsaId Curso { get; }
        public string TokenProximaPagina { get; }
    }
}
