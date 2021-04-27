using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciaAtualizacaoUsuarioGoogleClassroomIdUseCase : IIniciaAtualizacaoUsuarioGoogleClassroomIdUseCase
    {
        private readonly IMediator mediator;

        public IniciaAtualizacaoUsuarioGoogleClassroomIdUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(int registrosPorPagina)
        {
            var dto = new AtualizacaoUsuarioGoogleClassroomIdPaginadoDto
            {
                Pagina = 0,
                RegistrosPorPagina = registrosPorPagina
            };

            var publicarSyncFuncionario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaUsuarioGoogleIdSync, RotasRabbit.FilaUsuarioGoogleIdSync, dto));
            if (!publicarSyncFuncionario)
            {
                throw new NegocioException("Não foi possível iniciar a sincronização de funcionários.");
            }

            return publicarSyncFuncionario;
        }
    }
}