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
            if (turmaId.HasValue && componenteCurricularId.HasValue && recriarCursoSeExistirNaBaseDeDados)
                await RemoverCursoParaSerCriadoNovamenteAsync(turmaId.Value, componenteCurricularId.Value);

            var command = new IniciarSyncGoogleCursoCommand(turmaId, componenteCurricularId);
            return await mediator.Send(command);
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