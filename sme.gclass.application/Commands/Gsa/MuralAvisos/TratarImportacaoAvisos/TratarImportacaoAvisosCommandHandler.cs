using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static SME.GoogleClassroom.Infra.ExtensionMethods;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarImportacaoAvisosCommandHandler : AsyncRequestHandler<TratarImportacaoAvisosCommand>
    {
        private readonly int quantidadeRegistrosBloco = 100;
        private readonly IMediator mediator;

        public TratarImportacaoAvisosCommandHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override async Task Handle(TratarImportacaoAvisosCommand request, CancellationToken cancellationToken)
        {
            var avisosImportar = ObterAvisosInclusosOuAlterados(request.Avisos, request.UltimaExecucao).ToList();

            if (avisosImportar.Any())
            {
                for (int bloco = 0; bloco < avisosImportar.TotalBlocos(quantidadeRegistrosBloco); bloco++)
                {
                    var avisosBloco = avisosImportar
                        .ObterBloco(bloco, quantidadeRegistrosBloco)
                        .ToArray();

                    if (avisosBloco.Any())
                    {
                        await mediator
                            .Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaMuralAvisosIncluir, avisosBloco));
                    }
                }
            }
        }

        private IEnumerable<AvisoMuralGsaDto> ObterAvisosInclusosOuAlterados(ICollection<AvisoMuralGsaDto> avisos, DateTime ultimaExecucao)
            => avisos.Where(a => a.CriadoEm > ultimaExecucao
                            || a.AlteradoEm > ultimaExecucao);
    }
}
