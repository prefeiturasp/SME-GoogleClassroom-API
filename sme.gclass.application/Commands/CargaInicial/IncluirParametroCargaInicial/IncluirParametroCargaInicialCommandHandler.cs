using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Commands.CargaInicial.IncluirParametroCargaInicial
{
    public class IncluirParametroCargaInicialCommandHandler : IRequestHandler<IncluirParametroCargaInicialCommand, ParametrosCargaInicialDto>
    {

        private readonly IRepositorioCargaInicial repositorio;
        private readonly IMediator mediator;

        public IncluirParametroCargaInicialCommandHandler(IRepositorioCargaInicial repositorio, IMediator mediator)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<ParametrosCargaInicialDto> Handle(IncluirParametroCargaInicialCommand request, CancellationToken cancellationToken)
        {
            var parametros = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(request.Ano));
            List<int> tiposUes = new List<int>();
            List<long> ues = new List<long>();
            List<long> turmas = new List<long>();

            #region Validações
            if (request.TiposUes != null && request.TiposUes.Count > 0)
            {
                foreach (var tipoUe in request.TiposUes)
                {
                    if (!parametros.TiposUes.Contains(tipoUe))
                    {
                        tiposUes.Add(tipoUe);
                    }
                }
            }

            if (request.Ues != null && request.Ues.Count > 0)
            {
                foreach (var ue in request.Ues)
                {
                    if (!parametros.Ues.Contains(ue))
                    {
                        ues.Add(ue);
                    }
                }
            }

            if (request.Turmas != null && request.Turmas.Count > 0)
            {
                foreach (var turma in request.Turmas)
                {
                    if (!parametros.Turmas.Contains(turma))
                    {
                        turmas.Add(turma);
                    }
                }
            }
            #endregion


            try
            {
                if ((tiposUes != null && tiposUes.Count > 0) || (ues != null && ues.Count > 0) || (turmas != null && turmas.Count > 0))
                {
                    var tiposUesConvertidas = String.Join(",", tiposUes);
                    var uesConvertidas = String.Join(",", ues);
                    var turmasConvertidas = String.Join(",", turmas);

                    var anoInserido = await repositorio.InserirCargaInicial(request.Ano, tiposUesConvertidas, uesConvertidas, turmasConvertidas);
                    return await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(anoInserido));
                }
            }
            catch(Exception ex)
            {
                return null; 
            }
           
            return parametros;
        }
    }
}
