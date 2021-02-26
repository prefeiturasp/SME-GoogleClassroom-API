using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirCursoUseCase : IIncluirCursoUseCase
    {
        private readonly IMediator mediator;

        public IncluirCursoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var resposta = JsonConvert.DeserializeObject<CursoParaInclusaoDto>(mensagemRabbit.Mensagem.ToString());

            if (resposta != null)
                await mediator.Send(new IncluirCursoCommand(resposta));

            return true;
        }
    }
}
