using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosGsaGoogleQuery : IRequest<PaginaConsultaCursosGsaDto>
    {
        public string TokenPagina { get; set; }

        public ObterCursosGsaGoogleQuery(string tokenPagina)
        {
            this.TokenPagina = tokenPagina;
        }
    }
}