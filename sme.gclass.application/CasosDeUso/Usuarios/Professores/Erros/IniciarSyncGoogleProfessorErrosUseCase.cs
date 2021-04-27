using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncGoogleProfessorErrosUseCase : IIniciarSyncGoogleProfessorErrosUseCase
    {
        private readonly IMediator mediator;

        public IniciarSyncGoogleProfessorErrosUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar()
        {
            var publicarSyncAluno = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorErroSync, RotasRabbit.FilaProfessorErroSync, true));
            if (!publicarSyncAluno)
            {
                throw new NegocioException("Não foi possível iniciar o tratamento de erros de professores.");
            }

            return publicarSyncAluno;
        }
    }
}