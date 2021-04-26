using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtualizacaoUsuarioGoogleClassroomIdUseCase : IAtualizacaoUsuarioGoogleClassroomIdUseCase
    {
        private readonly IMediator mediator;

        public AtualizacaoUsuarioGoogleClassroomIdUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit.Mensagem is null)
                throw new NegocioException("Não foi possível atualizar o GoogleClassroomId do usuário. A mensagem enviada é inválida.");

            var usuarioParaAtualizacao = JsonConvert.DeserializeObject<UsuarioParaAtualizacaoGoogleClassroomIdDto>(mensagemRabbit.Mensagem.ToString());
            if (usuarioParaAtualizacao is null) return false;

            var usuarioGoogleClasroom = await mediator.Send(new ObterUsuarioGoogleQuery(usuarioParaAtualizacao.Email));
            if (usuarioParaAtualizacao is null) return false;

            return await mediator.Send(new AtualizarUsuarioGoogleClassroomIdCommand(usuarioParaAtualizacao.UsuarioId, usuarioGoogleClasroom.Id));
        }
    }
}