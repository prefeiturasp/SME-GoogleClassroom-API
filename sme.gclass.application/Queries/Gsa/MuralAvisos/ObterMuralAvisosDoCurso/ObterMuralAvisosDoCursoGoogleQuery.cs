using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterMuralAvisosDoCursoGoogleQuery : IRequest<PaginaConsultaMuralAvisosGsaDto>
    {
        public ObterMuralAvisosDoCursoGoogleQuery(CursoGsaManualmenteDto curso, string tokenProximaPagina = "")
        {
            Curso = curso;
            TokenProximaPagina = tokenProximaPagina;
        }

        public CursoGsaManualmenteDto Curso { get; set; }
        public string TokenProximaPagina { get; set; }
    }
}
