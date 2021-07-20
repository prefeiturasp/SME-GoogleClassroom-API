using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarImportacaoAtividadesCommandHandler : AsyncRequestHandler<TratarImportacaoAtividadesCommand>
    {
        private readonly IMediator mediator;

        public TratarImportacaoAtividadesCommandHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override async Task Handle(TratarImportacaoAtividadesCommand request, CancellationToken cancellationToken)
        {
            var ultimaExecucao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.AtividadesCarregar));
            var atividadesImportar = ObterAtividadesInclusasOuAlteradas(request.Atividades, ultimaExecucao);

            if (atividadesImportar.Any())
            {
                foreach (var atividadeGsa in atividadesImportar)
                {
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaAtividadesIncluir, atividadeGsa));
                }
            }
        }

        private IEnumerable<AtividadeGsaDto> ObterAtividadesInclusasOuAlteradas(ICollection<AtividadeGsaDto> atividades, DateTime ultimaExecucao)
            => atividades.Where(a => a.CriadoEm > ultimaExecucao
                                  || a.AlteradoEm > ultimaExecucao);
    }
}
