using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class EnviarRequisicaoAtribuirFuncionarioCursoUseCase : IEnviarRequisicaoAtribuirFuncionarioCursoUseCase
    {
        private readonly IMediator mediator;

        public EnviarRequisicaoAtribuirFuncionarioCursoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(AtribuirFuncionarioCursoDto atribuirFuncionarioCurso)
        {
            var funciorarioCursoEol = new FuncionarioCursoEol(atribuirFuncionarioCurso.Rf, atribuirFuncionarioCurso.TurmaId, atribuirFuncionarioCurso.ComponenteCurricularId);

            var publicarFuncionarioCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaFuncionarioCursoIncluir, RotasRabbit.FilaFuncionarioCursoIncluir, funciorarioCursoEol));
            if (!publicarFuncionarioCurso)
            {
                throw new NegocioException("Não foi possível realizar a requisição para atribuir o funcionário ao curso.");
            }

            return publicarFuncionarioCurso;
        }
    }
}
