using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ArquivarCursoExtintoUseCase : IArquivarCursoExtintoUseCase
    {
        private IMediator mediator;

        public ArquivarCursoExtintoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            if (mensagem?.Mensagem is null)
                throw new NegocioException("Não foi possível realizar arquivamento do curso. Mensagem não recebida");

            //var atividadeGsa = mensagem.ObterObjetoMensagem<AtividadeGsaDto>();

            var usuario = await mediator.Send(new ArquivarCursoExtintoQuery());

            return true;
        }
    }
}
