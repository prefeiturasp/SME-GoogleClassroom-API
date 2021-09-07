using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ImportarNotasGsaUseCase : AbstractUseCase, IImportarNotasGsaUseCase
    {
        public ImportarNotasGsaUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            var dadosNota = mensagem.ObterObjetoMensagem<ProcessarNotasDto>();
            try
            {
                var dataValidaCriacao = dadosNota.DataCriacaoAtividade.AddDays(dadosNota.TotalDiasImportacao);
                if (dadosNota.Nota != null && ((dadosNota.DataEntrega != null && dadosNota.DataEntrega.Value < DateTime.UtcNow) || dataValidaCriacao <= DateTime.UtcNow))
                {
                    var usuario = await mediator.Send(new ObterUsuarioPorClassroomIdQuery(dadosNota.UsuarioId));
                    var status = Enum.Parse<StatusGSA>(dadosNota.StatusNota);
                    await mediator.Send(new GravarNotaGsaCommand(dadosNota.NotaId, dadosNota.AtividadeId, usuario.Indice, dadosNota.Nota.Value, status, DateTime.UtcNow, null));
                    if (dadosNota.LancaNota)
                    {
                        var notaFinal = dadosNota.Nota;
                        if (dadosNota.NotaMaxima != null && dadosNota.NotaMaxima.HasValue && dadosNota.NotaMaxima != 10)
                        {
                            notaFinal = (dadosNota.NotaMaxima.Value / 100) * dadosNota.Nota.Value;
                        }
                        var notaRetornoSgpDto = new RetornoNotasSgpDto(dadosNota.TurmaId, dadosNota.ComponenteCurricularId, dadosNota.AtividadeId,
                            status, Math.Round(notaFinal.Value, 2), dadosNota.DataEntrega, long.Parse(usuario.Id), dadosNota.TituloAtividade);

                        return await mediator.Send(new PublicaFilaRabbitSgpCommand(RotasRabbitSgp.RotaAtividadesNotasSync, notaRetornoSgpDto));
                    }
                }
            }
            catch (Exception e)
            {
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaNotasImportarErro, dadosNota));
                SentrySdk.CaptureMessage($"Não foi possível importar a nota {dadosNota.NotaId} referente a atividade {dadosNota.AtividadeId} do aluno {dadosNota.UsuarioId}");
                throw e;
            }
            return true;
        }
    }
}
