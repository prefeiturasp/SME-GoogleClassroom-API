using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterNotasUseCase : AbstractUseCase, IObterNotasUseCase
    {
        public ObterNotasUseCase(IMediator mediator) : base(mediator)
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
                    var processarNotaDto = new ProcessarNotasDto()
                    {
                        TotalDiasImportacao = dadosAtividade.TotalDiasImportacao,
                        NotaId = nota.Id,
                        DataCriacaoAtividade = dadosAtividade.DataCriacao,
                        DataEntrega = dadosAtividade.DataEntrega,
                        LancaNota = dadosAtividade.LancaNota,
                        AtividadeId = dadosAtividade.AtividadeId,
                        UsuarioId = nota.UsuarioId,
                        Nota = nota.Nota,
                        StatusNota = nota.StatusNota,
                        NotaMaxima = dadosAtividade.NotaMaxima,
                        TurmaId = dadosAtividade.TurmaId,
                        ComponenteCurricularId = dadosAtividade.ComponenteCurricularId,
                        TituloAtividade = dadosAtividade.TituloAtividade
                    };
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaNotasImportar, processarNotaDto));
                }
            }

            if (string.IsNullOrEmpty(paginaNotas.TokenProximaPagina))
            {
                var notasProximaPagina = await mediator.Send(new ObterNotasGooglePorAtividadeQuery(paginaNotas.DadosAtividade, paginaNotas.TokenProximaPagina));
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaNotasProcessar, notasProximaPagina));
            }
            return true;
        }
    }
}
