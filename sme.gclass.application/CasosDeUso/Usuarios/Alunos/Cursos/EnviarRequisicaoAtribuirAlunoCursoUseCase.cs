using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class EnviarRequisicaoAtribuirAlunoCursoUseCase : IEnviarRequisicaoAtribuirAlunoCursoUseCase
    {
        private readonly IMediator mediator;

        public EnviarRequisicaoAtribuirAlunoCursoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(AtribuirAlunoCursoDto atribuirAlunoCurso)
        {
            var alunoCursoEol = new AlunoCursoEol(atribuirAlunoCurso.CodigoAluno, atribuirAlunoCurso.TurmaId, atribuirAlunoCurso.ComponenteCurricularId);

            var publicarAlunoCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaAlunoCursoIncluir, RotasRabbit.FilaAlunoCursoIncluir, alunoCursoEol));
            if (!publicarAlunoCurso)
            {
                throw new NegocioException("Não foi possível realizar a requisição para atribuir o aluno ao curso.");
            }

            return publicarAlunoCurso;
        }
    }
}
