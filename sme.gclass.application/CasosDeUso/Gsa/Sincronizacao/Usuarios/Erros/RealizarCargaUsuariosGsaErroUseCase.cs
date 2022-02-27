using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarCargaUsuariosGsaErroUseCase : IRealizarCargaUsuariosGsaErroUseCase
    {
        private readonly IMediator mediator;

        public RealizarCargaUsuariosGsaErroUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar()
        {
            var publicarSyncErro = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaUsuarioCarregarErro, true));
            if (!publicarSyncErro)
                throw new NegocioException("Sincroniza os usuários GSA Erro a serem adicionados na base");

            return publicarSyncErro;
        }
    }
}
