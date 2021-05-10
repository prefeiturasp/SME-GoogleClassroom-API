using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using MediatR;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Interfaces.Metricas;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosGsaGoogleQueryHandler : BaseIntegracaoGoogleClassroomHandler<ObterUsuariosGsaGoogleQuery, PaginaConsultaUsuariosGsaDto>
    {
        private readonly IMediator mediator;
        private readonly GsaSyncOptions gsaSyncOptions;
        private readonly IAsyncPolicy policy;

        public ObterUsuariosGsaGoogleQueryHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, GsaSyncOptions gsaSyncOptions, IMetricReporter metricReporter)
            :base(metricReporter)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.gsaSyncOptions = gsaSyncOptions;
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyCargaGsa);
        }

        public override async Task<PaginaConsultaUsuariosGsaDto> Handle(ObterUsuariosGsaGoogleQuery request, CancellationToken cancellationToken)
        {
            var diretorioClassroom = await mediator.Send(new ObterDirectoryServiceGoogleClassroomQuery());
            return await ObterUsuariosGsaGoogleAsync(diretorioClassroom, request.TokenPagina);
        }

        private async Task<PaginaConsultaUsuariosGsaDto> ObterUsuariosGsaGoogleAsync(DirectoryService diretorioClassroom, string tokenPagina)
        {
            var contadorDePagina = 0;
            var resultado = new PaginaConsultaUsuariosGsaDto(tokenPagina);

            await ObterUsuariosGsaGoogleTotalDePaginasPorExecucaoAsync(diretorioClassroom, resultado, contadorDePagina);

            if (string.IsNullOrWhiteSpace(resultado.TokenProximaPagina))
                resultado.Usuarios.Last().UltimoItemDaFila = true;

            return resultado;
        }

        private async Task ObterUsuariosGsaGoogleTotalDePaginasPorExecucaoAsync(DirectoryService diretorioClassroom, PaginaConsultaUsuariosGsaDto paginaConsulta, int contadorDePagina)
        {
            var resultadoPagina = await policy.ExecuteAsync(() => ObterUsuariosGsaGooglePaginadoAsync(diretorioClassroom, paginaConsulta.TokenProximaPagina));
            paginaConsulta.TokenProximaPagina = resultadoPagina.NextPageToken;
            paginaConsulta.Usuarios.AddRange(resultadoPagina.UsersValue
                .Select(user => new UsuarioGsaDto
                {
                    EhAdmin = user.IsAdmin ?? false,
                    Email = user.PrimaryEmail,
                    Id = user.Id,
                    Nome = user.Name?.FullName,
                    OrganizationPath = user.OrgUnitPath,
                    DataUltimoLogin = user.LastLoginTime,
                    DataInclusao = user.CreationTime
                })
                .ToList());

            contadorDePagina++;

            if (!string.IsNullOrWhiteSpace(paginaConsulta.TokenProximaPagina) && contadorDePagina < gsaSyncOptions.QuantidadeDePaginasConsultadasPorExecucao)
                await ObterUsuariosGsaGoogleTotalDePaginasPorExecucaoAsync(diretorioClassroom, paginaConsulta, contadorDePagina);
        }

        private async Task<Users> ObterUsuariosGsaGooglePaginadoAsync(DirectoryService diretorioClassroom, string tokenPagina)
        {
            var requestList = diretorioClassroom.Users.List();
            requestList.PageToken = tokenPagina;
            requestList.Domain = "edu.sme.prefeitura.sp.gov.br";
            requestList.Query = "isSuspended=false";
            requestList.MaxResults = gsaSyncOptions.QuantidadeDeItensPorPagina;

            RegistraRequisicaoGoogleClassroom();
            return await requestList.ExecuteAsync();
        }
    }
}