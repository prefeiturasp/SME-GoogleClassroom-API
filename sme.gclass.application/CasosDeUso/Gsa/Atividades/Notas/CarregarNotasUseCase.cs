using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class CarregarNotasUseCase : AbstractUseCase, ICarregarNotasUseCase
    {
        public CarregarNotasUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            var paginaNotas = mensagem.ObterObjetoMensagem<PaginaConsultaNotasGsaDto>();
            var dadosAtividade = paginaNotas.DadosAtividade;
            if (paginaNotas.Notas != null && paginaNotas.Notas.Any())
            {
                foreach (var nota in paginaNotas.Notas)
                {
                    if (nota.Nota != null && ((dadosAtividade.DataEntrega != null && dadosAtividade.DataEntrega.Value < DateTime.UtcNow) || ))
                    {
                        var id = await mediator.Send(new GravarNotaGsaCommand(nota.Id, dadosAtividade.AtividadeId, nota.UsuarioId, nota.Nota.Value, DateTime.UtcNow, null));
                    }
                }
            }

            if (string.IsNullOrEmpty(paginaNotas.TokenProximaPagina))
            {
                var notasProximaPagina = await mediator.Send(new ObterNotasGooglePorAtividadeQuery(paginaNotas.DadosAtividade, paginaNotas.TokenProximaPagina));
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaNotasCarregar, notasProximaPagina));
            }
            return true;
        }
    }
}
