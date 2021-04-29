using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using MediatR;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class CarregarUsuariosGSACommandHandler : IRequestHandler<CarregarUsuariosGSACommand, bool>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public CarregarUsuariosGSACommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.GoogleSync);
        }

        public async Task<bool> Handle(CarregarUsuariosGSACommand request, CancellationToken cancellationToken)
        {
            var diretorioClassroom = await mediator.Send(new ObterDirectoryServiceGoogleClassroomQuery());
            await policy.ExecuteAsync(() => CarregarUsuariosAtivosDoGoogle(diretorioClassroom, request.TokenPagina));

            return true;
        }

        private async Task CarregarUsuariosAtivosDoGoogle(DirectoryService diretorioClassroom, string tokenPagina)
        {
            var requestList = diretorioClassroom.Users.List();
            requestList.PageToken = tokenPagina;
            requestList.Query = "isSuspended=false";

            var listaUsuarios = await requestList.ExecuteAsync();

            await ExecutaSyncUsuarios(listaUsuarios);

            if (PossuiProximaPagina(listaUsuarios))
                await PublicaExecucaoProximaPagina(listaUsuarios.NextPageToken);
        }

        private async Task PublicaExecucaoProximaPagina(string tokenPagina)
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaComparativoUsuarioCarregar, mensagem: new FiltroCargaUsuariosGoogleDto(tokenPagina)));
        }

        private async Task ExecutaSyncUsuarios(Users listaUsuarios)
        {
            foreach (var usuario in listaUsuarios.UsersValue)
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaComparativoUsuarioIncluir, mensagem: usuario));
        }

        private bool PossuiProximaPagina(Users exec)
            => !string.IsNullOrEmpty(exec.NextPageToken);

    }
}
