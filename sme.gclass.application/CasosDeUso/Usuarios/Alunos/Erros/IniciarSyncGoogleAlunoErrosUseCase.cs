using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncGoogleAlunoErrosUseCase : IIniciarSyncGoogleAlunoErrosUseCase
    {
        private readonly IMediator mediator;

        public IniciarSyncGoogleAlunoErrosUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar()
        {
            var publicarSyncAluno = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaAlunoErroSync, RotasRabbit.FilaAlunoErroSync, true));
            if (!publicarSyncAluno)
            {
                throw new NegocioException("Não foi possível iniciar o tratamento de erros de alunos.");
            }

            return publicarSyncAluno;
        }
    }
}