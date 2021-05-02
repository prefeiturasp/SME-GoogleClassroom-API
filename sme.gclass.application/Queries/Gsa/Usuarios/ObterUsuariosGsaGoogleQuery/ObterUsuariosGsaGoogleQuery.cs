using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosGsaGoogleQuery : IRequest<PaginaConsultaUsuariosGsaDto>
    {
        public ObterUsuariosGsaGoogleQuery(string tokenPagina)
        {
            TokenPagina = tokenPagina;
        }

        public string TokenPagina { get; }
    }
}