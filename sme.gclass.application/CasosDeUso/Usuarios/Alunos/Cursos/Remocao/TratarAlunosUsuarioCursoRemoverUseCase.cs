using MediatR;
using SME.GoogleClassroom.Infra;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarAlunosUsuarioCursoRemoverUseCase : ITratarAlunosUsuarioCursoRemoverUseCase
    {
        private readonly IMediator mediator;

        public TratarAlunosUsuarioCursoRemoverUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<AlunosUsuarioTurmaRemoverDto>();
            foreach(var alunoCodigo in dto.AlunosCodigos)
            {
                var cursosUsuarios = await mediator.Send(new ObterCursoUsuarioPorUsuarioIdETurmaIdQuery(alunoCodigo, dto.TurmaId));
                if(cursosUsuarios != null && cursosUsuarios.Any())
                {
                    foreach(var cursoUsuario in cursosUsuarios)
                    {

                    }
                }
            }
            return true;
        }
    }
}
