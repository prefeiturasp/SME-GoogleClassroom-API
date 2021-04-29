using Google.Apis.Admin.Directory.directory_v1.Data;
using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirUsuarioComparativoCommandHandler : IRequestHandler<IncluirUsuarioComparativoCommand, bool>
    {
        private readonly IRepositorioUsuarioComparativo repositorio;

        public IncluirUsuarioComparativoCommandHandler(IRepositorioUsuarioComparativo repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<bool> Handle(IncluirUsuarioComparativoCommand request, CancellationToken cancellationToken)
        {
            var usuarioComparativo = MapearParaEntidade(request.UsuarioGsa);

            return await repositorio.SalvarAsync(usuarioComparativo);
        }

        private UsuarioComparativo MapearParaEntidade(User usuarioGsa)
            => new UsuarioComparativo()
            {
                Id = usuarioGsa.Id,
                Email = ObterEmail(usuarioGsa),
                DataInclusao = usuarioGsa.CreationTime.Value,
                DataUltimoLogin = usuarioGsa.LastLoginTime,
                EhAdmin = usuarioGsa.IsAdmin ?? false,
                Nome = usuarioGsa.Name.FullName,
                OrganizationPath = usuarioGsa.OrgUnitPath
            };

        private string ObterEmail(User usuarioGsa)
            => usuarioGsa.Emails.Any(a => a.Primary.Value) ?
                usuarioGsa.Emails.FirstOrDefault(a => a.Primary.Value).Address :
                usuarioGsa.Emails.FirstOrDefault()?.Address ?? "";
    }
}
