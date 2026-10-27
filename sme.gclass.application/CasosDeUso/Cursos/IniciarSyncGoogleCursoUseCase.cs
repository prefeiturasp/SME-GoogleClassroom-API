using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncGoogleCursoUseCase : IIniciarSyncGoogleCursoUseCase
    {
        private readonly IMediator mediator;

        public IniciarSyncGoogleCursoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(long? turmaId, long? componenteCurricularId, bool recriarCursoSeExistirNaBaseDeDados)
        {
            if (recriarCursoSeExistirNaBaseDeDados && (!turmaId.HasValue || !componenteCurricularId.HasValue))
                throw new NegocioException("Para recriar o curso deve-se informar a turma e o componente curricular.");

            if (turmaId.HasValue ^ componenteCurricularId.HasValue)
                throw new NegocioException("Para utilizar o filtro de sincronização deve-se informar a turma e o componente curricular.");

            if (turmaId.HasValue && componenteCurricularId.HasValue)
            {
                await ValidarExistenciaTurmaEComponenteAsync(turmaId.Value, componenteCurricularId.Value);

                if (recriarCursoSeExistirNaBaseDeDados)
                    await RemoverCursoParaSerCriadoNovamenteAsync(turmaId.Value, componenteCurricularId.Value);
            }

            var command = new IniciarSyncGoogleCursoCommand(turmaId, componenteCurricularId);
            return await mediator.Send(command);
        }

        private async Task ValidarExistenciaTurmaEComponenteAsync(long turmaId, long componenteCurricularId)
        {
            var existeTurma = await mediator.Send(new ExisteTurmaPorIdQuery(turmaId));
            if (!existeTurma)
                throw new NegocioException("A turma informada não existe.");

            var existeComponente = await mediator.Send(new ExisteComponenteCurricularPorIdQuery(componenteCurricularId));
            if (!existeComponente)
                throw new NegocioException("O componente curricular informado não existe.");
        }

        private async Task RemoverCursoParaSerCriadoNovamenteAsync(long turmaId, long componenteCurricularId)
        {
            var curso = await mediator.Send(new ObterCursoPorTurmaComponenteCurricularQuery(turmaId, componenteCurricularId));
            if (curso is null) return;

            if(!await mediator.Send(new ExcluirCursoCommand(curso.Id)))
            {
                throw new NegocioException("Não foi possível remover o registro do curso solicitado para ser recriado. Por favor tente novamente.");
            }
        }
    }
}
