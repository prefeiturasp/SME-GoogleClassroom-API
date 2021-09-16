using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var atividadesImportar = ObterAtividadesInclusasOuAlteradas(request.Atividades, request.UltimaExecucao);

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
