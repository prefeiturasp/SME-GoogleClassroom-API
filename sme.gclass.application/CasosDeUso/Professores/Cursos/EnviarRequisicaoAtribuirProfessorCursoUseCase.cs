using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class EnviarRequisicaoAtribuirProfessorCursoUseCase : IEnviarRequisicaoAtribuirProfessorCursoUseCase
    {
        private readonly IMediator mediator;

        public EnviarRequisicaoAtribuirProfessorCursoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(AtribuirProfessorCursoDto atribuirProfessorCursoDto)
        {
            var professorCursoEol = new ProfessorCursoEol(atribuirProfessorCursoDto.Rf, atribuirProfessorCursoDto.TurmaId, atribuirProfessorCursoDto.ComponenteCurricularId);

            var publicarProfessorCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorCursoIncluir, RotasRabbit.FilaProfessorCursoIncluir, professorCursoEol));
            if (!publicarProfessorCurso)
            {
                throw new NegocioException("Não foi possível realizar a requisição para atribuir o professor ao curso.");
            }

            return publicarProfessorCurso;
        }
    }
}