using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncGoogleAlunoUseCase : IIniciarSyncGoogleAlunoUseCase
    {
        private readonly IMediator mediator;

        public IniciarSyncGoogleAlunoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(long? codigoAluno)
        {
            var dto = new IniciarSyncGoogleAlunoDto
            {
                CodigoAluno = codigoAluno
            };

            var publicarSyncAluno = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaAlunoSync, RotasRabbit.FilaAlunoSync, dto));
            if (!publicarSyncAluno)
            {
                throw new NegocioException("Não foi possível iniciar a sincronização de alunos.");
            }

            return publicarSyncAluno;
        }
    }
}