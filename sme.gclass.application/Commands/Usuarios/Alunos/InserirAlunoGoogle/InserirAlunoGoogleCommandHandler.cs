using Google;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using MediatR;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Interfaces.Metricas;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirAlunoGoogleCommandHandler : EnvioDeDadosIntegracaoGoogleClassroomHandler<InserirAlunoGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IConfiguration configuration;
        private readonly IAsyncPolicy policy;

        public InserirAlunoGoogleCommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, IConfiguration configuration, VariaveisGlobaisOptions variaveisGlobais)
            : base(variaveisGlobais)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
        }

        protected override async Task<bool> ExecutarAsync(InserirAlunoGoogleCommand request, CancellationToken cancellationToken)
        {
            var diretorioClassroom = await mediator.Send(new ObterDirectoryServiceGoogleClassroomQuery());

            try
            {
                await policy.ExecuteAsync(() => IncluirAlunoNoGoogle(request.AlunoGoogle, diretorioClassroom));
            }
            catch (GoogleApiException gex)
            {
                if (gex.EhErroDeDuplicidade())
                {
                    var user = await diretorioClassroom
                        .Users.Get(request.AlunoGoogle.Email).ExecuteAsync();

                    request.AlunoGoogle.GoogleClassroomId = user?.Id;
                }
                else
                    throw;
            }

            return true;
        }

        private async Task IncluirAlunoNoGoogle(AlunoGoogle alunoGoogle, DirectoryService diretorioClassroom)
        {
            var usuarioParaIncluirNoGoogle = new User
            {
                Name = new UserName { FamilyName = alunoGoogle.Sobrenome, GivenName = alunoGoogle.PrimeiroNome, FullName = alunoGoogle.Nome },
                PrimaryEmail = alunoGoogle.Email,
                OrgUnitPath = alunoGoogle.OrganizationPath,
                Password = configuration["GoogleClassroomConfig:PasswordPadraoParaUsuarioNovo"],
                ChangePasswordAtNextLogin = true
            };

            var requestCreate = diretorioClassroom.Users.Insert(usuarioParaIncluirNoGoogle);
            var usuarioIncluido = await requestCreate.ExecuteAsync();

            if (usuarioIncluido is null)
                throw new NegocioException("Não foi possível obter o aluno incluído no Google Classroom.");

            alunoGoogle.GoogleClassroomId = usuarioIncluido.Id;
        }
    }
}