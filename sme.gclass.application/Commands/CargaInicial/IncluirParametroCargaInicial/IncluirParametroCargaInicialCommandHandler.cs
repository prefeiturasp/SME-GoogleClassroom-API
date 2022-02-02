using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sentry;
using SME.GoogleClassroom.Dados.Interfaces;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirParametroCargaInicialCommandHandler : IRequestHandler<IncluirParametroCargaInicialCommand, bool>
    {
        private readonly IRepositorioCargaInicial repositorio;
        private readonly IMediator mediator;

        public IncluirParametroCargaInicialCommandHandler(IRepositorioCargaInicial repositorio, IMediator mediator)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(IncluirParametroCargaInicialCommand request, CancellationToken cancellationToken)
        {
            var parametros = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(request.Ano));
            var tiposUes = new List<int>();
            var ues = new List<long>();
            var turmas = new List<long>();

            #region Validações

            if (request.TiposUes != null && request.TiposUes.Count > 0)
            {
                tiposUes.AddRange(request.TiposUes.Where(tipoUe => !parametros.TiposUes.Contains(tipoUe)));
            }

            if (request.Ues != null && request.Ues.Count > 0)
            {
                ues.AddRange(request.Ues.Where(ue => !parametros.Ues.Contains(ue)));
            }

            if (request.Turmas != null && request.Turmas.Count > 0)
            {
                turmas.AddRange(request.Turmas.Where(turma => !parametros.Turmas.Contains(turma)));
            }

            #endregion


            try
            {
                if ((tiposUes != null && tiposUes.Count > 0) || (ues != null && ues.Count > 0) ||
                    (turmas != null && turmas.Count > 0))
                {
                    var tiposUesConvertidas = string.Join(",", tiposUes);
                    var uesConvertidas = string.Join(",", ues);
                    var turmasConvertidas = string.Join(",", turmas);

                    await repositorio.InserirCargaInicial(request.Ano, tiposUesConvertidas, uesConvertidas,
                        turmasConvertidas);
                }
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureMessage(
                    $"Não foi possível incluir os parametros da carga inicial. {ex.Message}");

                return false;
            }

            return true;
        }
    }
}