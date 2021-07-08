using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarImportacaoAvisosCommandHandler : AsyncRequestHandler<TratarImportacaoAvisosCommand>
    {
        private readonly IMediator mediator;

        public TratarImportacaoAvisosCommandHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override async Task Handle(TratarImportacaoAvisosCommand request, CancellationToken cancellationToken)
        {
            var ultimaExecucao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.MuralAvisosCarregar));
            var avisosImportar = ObterAvisosInclusosOuAlterados(request.Avisos, ultimaExecucao);

            if (avisosImportar.Any())
            {
                foreach (var avisoGsa in ObterAvisosInclusosOuAlterados(request.Avisos, ultimaExecucao))
                {
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaMuralAvisosIncluir, avisoGsa));
                }
            }
        }

        private IEnumerable<AvisoMuralGsaDto> ObterAvisosInclusosOuAlterados(ICollection<AvisoMuralGsaDto> avisos, DateTime ultimaExecucao)
            => avisos.Where(a => a.CriadoEm > ultimaExecucao
                            || a.AlteradoEm > ultimaExecucao);
    }
}
