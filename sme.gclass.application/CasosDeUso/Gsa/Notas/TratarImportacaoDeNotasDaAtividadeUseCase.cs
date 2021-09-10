using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarImportacaoDeNotasDaAtividadeUseCase : AbstractUseCase, ITratarImportacaoDeNotasDaAtividadeUseCase
    {
        public TratarImportacaoDeNotasDaAtividadeUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            if (mensagem.Mensagem is null)
                throw new NegocioException("O objeto da atividade avaliativa deve ser informado na mensagem");

            var atividade = mensagem.ObterObjetoMensagem<TratarImportacaoNotasAvalidacaoDto>();
            var consultaNotas = await mediator.Send(new ObterNotasGooglePorAtividadeQuery(atividade.DadosAvaliacao));
            await ProximaPagina(atividade, consultaNotas.TokenProximaPagina);

            foreach (var nota in consultaNotas.Notas)
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaNotasAtividadesSync, new SincronizarImportacaoNotasDto(atividade.DadosAvaliacao, nota)));

            return true;
        }

        private async Task ProximaPagina(TratarImportacaoNotasAvalidacaoDto atividade, string tokenProximaPagina)
        {
            atividade.TokenProximaPagina = tokenProximaPagina;
            if (!string.IsNullOrEmpty(tokenProximaPagina))
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaNotasAtividadesTratar, atividade));

        }
    }
}
