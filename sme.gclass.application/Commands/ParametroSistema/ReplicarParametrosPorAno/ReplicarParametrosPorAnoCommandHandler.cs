using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
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

            if (parametros != null && parametros.Any())
            {
                return false;
            }
                
            var utilmoAno = await mediator.Send(new ObterUtilmoParametroSistemaQuery());
            if (utilmoAno == null || utilmoAno == 0)
            {
                return false;
            }

            var parametrosSistemasUltimoAno = await mediator.Send(new ObterParametroSistemaPorAnoQuery(utilmoAno));
            try
            {
                foreach (var parametrosSistema in parametrosSistemasUltimoAno)
                {
                    await repositorioParametroSistema.Salvar(parametrosSistema, request.Ano);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"houve um erro {ex.Message}");
            }
        }
    }
}