using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosGsaGoogleQuery : IRequest<PaginaConsultaUsuariosGsaDto>
    {
        public ObterUsuariosGsaGoogleQuery(string tokenProximaPagina)
        {
            TokenProximaPagina = tokenProximaPagina;
        }

        public string TokenProximaPagina { get; }
    }
}