using Google;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoGsaGoogleUseCase : IObterCursoGsaGoogleUseCase
    {
        private readonly IMediator mediator;

        public ObterCursoGsaGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<CursoGsaDto> Executar(long turmaId, long componenteCurricularId)
        {
            var curso = await mediator.Send(new ObterCursoPorTurmaComponenteCurricularQuery(turmaId, componenteCurricularId));
            if (curso is null)
                throw new NegocioException($"Não foi encontrado um curso para a Turma {turmaId} e Componente Curricular {componenteCurricularId} na base de dados.");

            try
            {
                var cursoGsa = await mediator.Send(new ObterCursoGsaGoogleQuery(curso.Id.ToString()));
                if (cursoGsa is null)
                    throw new NegocioException("Não foi possível buscar o curso no Google Classroom.");

                return cursoGsa;
            }
            catch (GoogleApiException gEx)
            {
                if (gEx.RegistroNaoEncontrado())
                    throw new NegocioException("Curso não existe no Google Classroom.");
                else
                    throw;
            }
        }
    }
}