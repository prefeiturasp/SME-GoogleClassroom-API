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
            var codigoCuros = long.Parse(mensagemRabbit.Mensagem.ToString());
            var excluido = await mediator.Send(new ExcluirCursoGoogleCommand(codigoCuros));
            if (!excluido)
            {
                return false;
            }
            return await mediator.Send(new ExcluirCursoCommand(codigoCuros));
        }
    }
}