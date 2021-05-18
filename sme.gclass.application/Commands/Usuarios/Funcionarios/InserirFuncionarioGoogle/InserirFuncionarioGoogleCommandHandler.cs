﻿using Google.Apis.Admin.Directory.directory_v1;
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
    public class InserirFuncionarioGoogleCommandHandler : EnvioDeDadosIntegracaoGoogleClassroomHandler<InserirFuncionarioGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IConfiguration configuration;
        private readonly IAsyncPolicy policy;

        public InserirFuncionarioGoogleCommandHandler(IMediator mediator, IConfiguration configuration, IReadOnlyPolicyRegistry<string> registry, VariaveisGlobaisOptions variaveisGlobais, IMetricReporter metricReporter)
            : base(variaveisGlobais, metricReporter)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
        }

        protected override async Task<bool> ExecutarAsync(InserirFuncionarioGoogleCommand request, CancellationToken cancellationToken)
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
                OrgUnitPath = funcionarioGoogle.OrganizationPath,
                Password = configuration["GoogleClassroomConfig:PasswordPadraoParaUsuarioNovo"],
                ChangePasswordAtNextLogin = true
            };

            var requestCreate = diretorioClassroom.Users.Insert(usuarioParaIncluirNoGoogle);
            var usuarioIncluido = await requestCreate.ExecuteAsync();

            if (usuarioIncluido is null)
                throw new NegocioException("Não foi possível obter o funcionário incluído no Google Classroom.");

            funcionarioGoogle.GoogleClassroomId = usuarioIncluido.Id;
        }
    }
}