using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosExtintosUseCase : IObterCursosExtintosUseCase
    {
        private IMediator mediator;

        public ObterCursosExtintosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            if (mensagem?.Mensagem is null)
                throw new NegocioException("Não foi possível realizar arquivamento do curso. Mensagem não recebida");

            var dataInicio = new DateTime();
            var dataFim = new DateTime();
            var anoLetivo = 2021;

            var cursosExtintos = await mediator.Send(new ObterCursosExtintosQueryPorPeriodo(dataInicio, dataFim, anoLetivo));
            
            //incluir na próxima fila
            logica exclusao ou arquivamento

            TurmaId
            DataExtincao
            Excluir = true/false

            return true;
        }
    }
}
