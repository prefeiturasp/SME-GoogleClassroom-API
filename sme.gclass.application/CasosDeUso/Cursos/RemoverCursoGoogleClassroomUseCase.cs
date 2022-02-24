using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RemoverCursoGoogleClassroomUseCase : AbstractUseCase, IRemoverCursoGoogleClassroomUseCase
    {
        public RemoverCursoGoogleClassroomUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var codigoCurso = long.Parse(mensagemRabbit.Mensagem.ToString());
            var excluido = await mediator.Send(new ExcluirCursoGoogleCommand(codigoCurso));
            if (excluido)
            {
                return await mediator.Send(new ExcluirCursoCommand(codigoCurso));    
            }
            return false;
            
        }
    }
}