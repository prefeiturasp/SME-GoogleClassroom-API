using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleGeralUseCase : ITrataSyncGoogleGeralUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleGeralUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var resposta = mensagemRabbit.Mensagem;

            var publicarCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoSync, RotasRabbit.FilaCursoSync, resposta));
            var publicarFuncionario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaFuncionarioSync, RotasRabbit.FilaFuncionarioSync, resposta));
            var publicarProfessor = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorSync, RotasRabbit.FilaProfessorSync, resposta));
            var publicarAluno = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaAlunoSync, RotasRabbit.FilaAlunoSync, resposta));
            var publicarAtribuicoesProfessores = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorCursoAtribuicaoSync, RotasRabbit.FilaProfessorCursoAtribuicaoSync, resposta));

            if (!publicarCurso)
                throw new NegocioException("Erro ao enviar a sync de cursos.");

            if (!publicarFuncionario)
                throw new NegocioException("Erro ao enviar a sync de funcionários.");

            if (!publicarProfessor)
                throw new NegocioException("Erro ao enviar a sync de professores.");

            if (!publicarAluno)
                throw new NegocioException("Erro ao enviar a sync de alunos.");

            if (!publicarAtribuicoesProfessores)
                throw new NegocioException("Erro ao enviar a sync de atribuições de professores.");

            return await Task.FromResult(true);
        }
    }
}
