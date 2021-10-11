using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static SME.GoogleClassroom.Infra.ExtensionMethods;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarImportacaoAtividadesCommandHandler : AsyncRequestHandler<TratarImportacaoAtividadesCommand>
    {
        private readonly int quantidadeRegistrosBloco = 100;
        private readonly IMediator mediator;

        public TratarImportacaoAtividadesCommandHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override async Task Handle(TratarImportacaoAtividadesCommand request, CancellationToken cancellationToken)
        {
            var atividadesImportar = ObterAtividadesInclusasOuAlteradas(request.Atividades, request.UltimaExecucao).ToList();

            if (atividadesImportar.Any())
            {
                for (int bloco = 0; bloco < atividadesImportar.TotalBlocos(quantidadeRegistrosBloco); bloco++)
                {
                    var atividadesBloco = atividadesImportar
                        .ObterBloco(bloco, quantidadeRegistrosBloco)
                        .ToArray();

                    if (atividadesBloco.Any())
                    {
                        await mediator
                            .Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaAtividadesIncluir, atividadesBloco));
                    }
                }
            }
        }

        private IEnumerable<AtividadeGsaDto> ObterAtividadesInclusasOuAlteradas(ICollection<AtividadeGsaDto> atividades, DateTime ultimaExecucao)
            => atividades.Where(a => a.CriadoEm > ultimaExecucao
                                  || a.AlteradoEm > ultimaExecucao);
    }
}
