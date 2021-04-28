using MediatR;
using Polly;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using Polly.Registry;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarCargaUsuariosUseCase : IRealizarCargaUsuariosUseCase
    {
        private readonly IAsyncPolicy policy;
        private readonly IMediator mediator;

        public RealizarCargaUsuariosUseCase(IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>("RetryPolicy");
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var tokenPagina = mensagemRabbit.ObterObjetoMensagem<string>();

            var diretorioClassroom = await mediator.Send(new ObterDirectoryServiceGoogleClassroomQuery());
            await policy.ExecuteAsync(() => CarregarUsuariosAtivosDoGoogle(diretorioClassroom, tokenPagina));

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
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaUsuariosCarregar, RotasRabbit.FilaUsuariosCarregar, listaUsuarios.NextPageToken));
        }

        private async Task ExecutaSyncUsuarios(Users listaUsuarios)
        {
            // TODO task 38508 Sincronizar Usuarios
            //foreach (var usuario in listaUsuarios.UsersValue)
            //    await mediator.Send(new )
            
        }

        private bool PossuiProximaPagina(Users exec)
            => !string.IsNullOrEmpty(exec.NextPageToken);
    }
}
