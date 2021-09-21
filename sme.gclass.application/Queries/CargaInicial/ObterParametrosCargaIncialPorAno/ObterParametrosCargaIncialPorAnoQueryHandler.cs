using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterParametrosCargaIncialPorAnoQueryHandler : IRequestHandler<ObterParametrosCargaIncialPorAnoQuery, ParametrosCargaInicialDto>
    {
        private readonly IRepositorioCargaInicial repositorioCargaInicial;

        public ObterParametrosCargaIncialPorAnoQueryHandler(IRepositorioCargaInicial repositorioCargaInicial)
        {
            this.repositorioCargaInicial = repositorioCargaInicial ?? throw new System.ArgumentNullException(nameof(repositorioCargaInicial));
        }

        public async Task<ParametrosCargaInicialDto> Handle(ObterParametrosCargaIncialPorAnoQuery request, CancellationToken cancellationToken)
        {
            var cargas = await repositorioCargaInicial.ObterPorAno(request.Ano);

            var parametros = new ParametrosCargaInicialDto();
            foreach(var cargaInicial in cargas)
            {
 
                if (cargaInicial.PossuiTiposUe())
                    parametros.AdicionaTiposUe(cargaInicial.TiposUe);

                if (cargaInicial.PossuiUes())
                    parametros.AdicionaUes(cargaInicial.Ues);

                if (cargaInicial.PossuiTurmas())
                    parametros.AdicionaTurmas(cargaInicial.Turmas);
            }

            return parametros;
        }
    }
}
