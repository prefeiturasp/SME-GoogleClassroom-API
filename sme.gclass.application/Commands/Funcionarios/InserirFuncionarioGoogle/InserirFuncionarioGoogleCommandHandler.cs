using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using MediatR;
using Polly;
using Polly.Registry;
using Polly.Retry;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirFuncionarioGoogleCommandHandler : IRequestHandler<InserirFuncionarioGoogleCommand, bool>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public InserirFuncionarioGoogleCommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<AsyncRetryPolicy>("RetryPolicy");
        }

        public async Task<bool> Handle(InserirFuncionarioGoogleCommand request, CancellationToken cancellationToken)
        {
            var diretorioClassroom = await mediator.Send(new ObterDirectoryServiceGoogleClassroomQuery());
            await policy.ExecuteAsync(() => IncluirFuncionarioNoGoogle(request.FuncionarioGoogle, diretorioClassroom));
            return true;
        }

        private async Task IncluirFuncionarioNoGoogle(FuncionarioGoogle funcionarioGoogle, DirectoryService diretorioClassroom)
        {
            var usuarioParaIncluirNoGoogle = new User
            {
                Name = new UserName { FamilyName = funcionarioGoogle.Sobrenome, GivenName = funcionarioGoogle.PrimeiroNome, FullName = funcionarioGoogle.Nome },
                PrimaryEmail = funcionarioGoogle.Email,
                OrgUnitPath = funcionarioGoogle.OrganizationPath
            };

            var requestCreate = diretorioClassroom.Users.Insert(usuarioParaIncluirNoGoogle);
            await requestCreate.ExecuteAsync();
        }
    }
}