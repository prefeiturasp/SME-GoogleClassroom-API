using MediatR;
using SME.GoogleClassroom.Infra;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarInativacaoUsuarioGsaUseCase : ITratarInativacaoUsuarioGsaUseCase
    {
        private readonly IMediator mediator;

        public TratarInativacaoUsuarioGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<AlunosInativosPorTurmaDto>();
            foreach (var alunoCodigo in dto.AlunosCodigos)
            {
                var cursosUsuarios = await mediator.Send(new ObterUsuariosPorIdETurmaIdQuery(alunoCodigo, dto.TurmaId));

                if (cursosUsuarios != null && cursosUsuarios.Any())
                {
                    foreach (var cursoUsuario in cursosUsuarios)
                    {
                        await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaInativarUsuarioTratar, RotasRabbit.FilaGsaInativarUsuarioTratar, cursoUsuario));
                    }
                }
            }
            return true;
        }
    }
}
