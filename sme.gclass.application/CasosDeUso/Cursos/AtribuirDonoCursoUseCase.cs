using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtribuirDonoCursoUseCase : IAtribuirDonoCursoUseCase
    {
        private readonly IMediator mediator;

        public AtribuirDonoCursoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(string email, long turmaId, long componenteCurricularId)
        {
            var curso = await mediator.Send(new ObterCursoPorTurmaComponenteCurricularQuery(turmaId, componenteCurricularId));
            if (curso == null)
            {
                throw new NegocioException("Não foi possível alterar o dono do curso, pois o curso não existe na base do GSA");
            }
            var usuario = await mediator.Send(new ObterUsuarioGoogleQuery(email));
            return await mediator.Send(new AtribuirDonoCursoGoogleCommand(curso.Id, usuario.Id));
        }
    }
}
