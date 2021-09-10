using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterPeriodoFechamentoVigentePorAnoModalidadeQuery : IRequest<PeriodoFechamentoVigenteDto>
    {
        public ObterPeriodoFechamentoVigentePorAnoModalidadeQuery(int anoLetivo, int? modalidadeTipoCalendario = null)
        {
            AnoLetivo = anoLetivo;
            ModalidadeTipoCalendario = modalidadeTipoCalendario;
        }

        public int AnoLetivo { get; }
        public int? ModalidadeTipoCalendario { get; }
    }
}
