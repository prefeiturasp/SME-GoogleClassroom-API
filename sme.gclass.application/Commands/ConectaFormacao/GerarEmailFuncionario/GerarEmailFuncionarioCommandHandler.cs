using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class GerarEmailFuncionarioCommandHandler : IRequestHandler<GerarEmailFuncionarioCommand, string>
    {
        private const string DOMINIO_EMAIL = "@edu.sme.prefeitura.sp.gov.br";
        public async Task<string> Handle(GerarEmailFuncionarioCommand request, CancellationToken cancellationToken)
        {
            var cpfOuRf = request.EhUsuarioParceiro? request.Cpf : request.CodigoRF;

            var nomes = request.Nome.Trim().Split(' ');
            var primeiroNome = nomes.FirstOrDefault();
            var ultimoNome = nomes.LastOrDefault();

            var email = $"{primeiroNome}{ultimoNome}.{cpfOuRf}{DOMINIO_EMAIL}";

            return email.RemoverAcentosECaracteresEspeciais().ToLower();
        }
    }
}
