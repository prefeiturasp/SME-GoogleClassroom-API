using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ProcessarUsuarioGsaErroUseCase : IProcessarUsuarioGsaErroUseCase
    {
        private readonly IMediator mediator;

        public ProcessarUsuarioGsaErroUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar()
        {
            var publicarSyncErro = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaUsuarioIncluirErro, true));
            if (!publicarSyncErro)
                throw new NegocioException("Não foi possível processar usuário GSA e adicionar na base.");

            return publicarSyncErro;
        }
    }
}
