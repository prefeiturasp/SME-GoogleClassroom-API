using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using MediatR;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosGsaGoogleQueryHandler : IRequestHandler<ObterUsuariosGsaGoogleQuery, PaginaConsultaUsuariosGsaDto>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public ObterUsuariosGsaGoogleQueryHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyCargaGsa);
        }

        public async Task<PaginaConsultaUsuariosGsaDto> Handle(ObterUsuariosGsaGoogleQuery request, CancellationToken cancellationToken)
        {
            var diretorioClassroom = await mediator.Send(new ObterDirectoryServiceGoogleClassroomQuery());
            var usuariosGoogle = await policy.ExecuteAsync(() => ObterUsuariosGsaGoogleAsync(diretorioClassroom, request.TokenPagina));
            return MapearParaDto(usuariosGoogle);
        }

        private async Task<Users> ObterUsuariosGsaGoogleAsync(DirectoryService diretorioClassroom, string tokenPagina)
        {
            var requestList = diretorioClassroom.Users.List();
            requestList.PageToken = tokenPagina;
            requestList.Query = "isSuspended=false";

            return await requestList.ExecuteAsync();
        }

        private PaginaConsultaUsuariosGsaDto MapearParaDto(Users usuariosGoogle)
        {
            var paginaConsultaUsuarios = new PaginaConsultaUsuariosGsaDto
            {
                TokenProximaPagina = usuariosGoogle?.NextPageToken
            };

            if (usuariosGoogle?.UsersValue is null)
                return paginaConsultaUsuarios;

            paginaConsultaUsuarios.Usuarios = usuariosGoogle.UsersValue
                .Select(user => new UsuarioGsaDto
                {
                    EhAdmin = user.IsAdmin ?? false,
                    Email = user.PrimaryEmail,
                    Id = user.Id,
                    Nome = user.Name.FullName,
                    OrganizationPath = user.OrgUnitPath,
                    DataUltimoLogin = user.LastLoginTime,
                    DataInclusao = user.CreationTime
                })
                .ToList();

            if (string.IsNullOrEmpty(usuariosGoogle.NextPageToken))
                paginaConsultaUsuarios.Usuarios.Last().UltimoItemDaFila = true;

            return paginaConsultaUsuarios;
        }
    }
}