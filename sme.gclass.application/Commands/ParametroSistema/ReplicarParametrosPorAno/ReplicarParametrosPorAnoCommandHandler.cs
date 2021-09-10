using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sentry;
using SME.GoogleClassroom.Dados;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ReplicarParametrosPorAnoCommandHandler : IRequestHandler<ReplicarParametrosPorAnoCommand, bool>
    {
        private readonly IMediator mediator;
        private readonly IRepositorioParametroSistema repositorioParametroSistema;

        public ReplicarParametrosPorAnoCommandHandler(IMediator mediator,
            IRepositorioParametroSistema repositorioParametroSistema)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.repositorioParametroSistema = repositorioParametroSistema ??
                                               throw new ArgumentNullException(nameof(repositorioParametroSistema));
        }

        public async Task<bool> Handle(ReplicarParametrosPorAnoCommand request, CancellationToken cancellationToken)
        {
            var parametros = await mediator.Send(new ObterParametroSistemaPorAnoQuery(request.Ano));

            if (parametros != null && !parametros.Any())
            {
                try
                {
                    var parametrosSistemasUltimoAno = await mediator.Send(new ObterParametroSistemaPorAnoQuery(request.Ano - 1));
                    foreach (var parametrosSistema in parametrosSistemasUltimoAno)
                    {
                        await repositorioParametroSistema.Salvar(parametrosSistema, request.Ano);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    SentrySdk.CaptureMessage($"Não foi possível replicar os parametros do sistema para o ano de {request.Ano}");
                }
            }
            return false;
        }
    }
}