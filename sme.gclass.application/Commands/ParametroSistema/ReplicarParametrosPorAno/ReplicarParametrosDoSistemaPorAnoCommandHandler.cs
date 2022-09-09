using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sentry;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ReplicarParametrosDoSistemaPorAnoCommandHandler : IRequestHandler<ReplicarParametrosDoSistemaPorAnoCommand, bool>
    {
        private readonly IMediator mediator;
        private readonly IRepositorioParametroSistema repositorioParametroSistema;

        public ReplicarParametrosDoSistemaPorAnoCommandHandler(IMediator mediator,
            IRepositorioParametroSistema repositorioParametroSistema)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.repositorioParametroSistema = repositorioParametroSistema ??
                                               throw new ArgumentNullException(nameof(repositorioParametroSistema));
        }

        public async Task<bool> Handle(ReplicarParametrosDoSistemaPorAnoCommand request, CancellationToken cancellationToken)
        {
            var parametros = await mediator.Send(new ObterParametroSistemaPorAnoQuery(request.Ano));

            if (parametros != null && !parametros.Any())
            {
                try
                {
                    var parametrosSistemasUltimoAno = await mediator.Send(new ObterParametroSistemaPorAnoQuery(request.Ano - 1));
                    foreach (var parametrosSistema in parametrosSistemasUltimoAno)
                    {
                        await repositorioParametroSistema.ReplicarPorAno(parametrosSistema, request.Ano);
                    }
                }
                catch (Exception ex)
                {
                    await mediator.Send(new SalvarLogViaRabbitCommand($"ReplicarParametrosDoSistemaPorAnoCommandHandler - Não foi possível replicar os parametros do sistema para o ano de {request.Ano}", LogNivel.Critico, LogContexto.CelpGsa, ex.Message, ex.StackTrace));
                    return false;
                }
            }
            return true;
        }
    }
}