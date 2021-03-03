using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncGooglAlunoUseCase : IIniciarSyncGooglAlunoUseCase
    {
        private readonly IMediator mediator;

        public IniciarSyncGooglAlunoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar()
        {
            var publicarSyncAluno = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaAlunoSync, RotasRabbit.FilaAlunoSync, true));
            if (!publicarSyncAluno)
            {
                throw new NegocioException("Não foi possível iniciar a sincronização de alunos.");
            }

            return publicarSyncAluno;
        }
    }
}