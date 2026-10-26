using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class CarregarArquivamentoCursosExtintosManualUseCase : AbstractUseCase, ICarregarArquivamentoCursosExtintosManualUseCase
    {
        public CarregarArquivamentoCursosExtintosManualUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(long? turmaId, DateTime? dataReferencia)
        {
            if (turmaId.HasValue)
            {
                var turmaExiste = await mediator.Send(new ExisteTurmaPorCodigoQuery(turmaId.Value));
                if (!turmaExiste)
                    throw new NegocioException("A turma informada não foi localizada na base do EOL.");
            }

            var publicado = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoExtintoArquivarCarregar, new FiltroArquivamentoTurmasDto(turmaId, dataReferencia)));
            if (!publicado)
                throw new NegocioException("Não foi possível publicar a mensagem para arquivamento de turmas extintas.");

            return publicado;
        }
    }
}
