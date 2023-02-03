using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Aplicacao.Queries.Usuarios.Funcionarios.ObterFuncionarioExternoEolSgaPorUeAnoLetivo
{
    public class ObterFuncionarioExternoEolSgaPorUeAnoLetivoQueryHandler : IRequestHandler<ObterFuncionarioExternoEolSgaPorUeAnoLetivoQuery,IEnumerable<FuncionarioSgaDto>>
    {
        private IRepositorioFuncionarioEol repositorioFuncionarioEol;

        public ObterFuncionarioExternoEolSgaPorUeAnoLetivoQueryHandler(IRepositorioFuncionarioEol funcionarioEol)
        {
            repositorioFuncionarioEol = funcionarioEol ?? throw new ArgumentNullException(nameof(funcionarioEol));
        }

        public async Task<IEnumerable<FuncionarioSgaDto>> Handle(ObterFuncionarioExternoEolSgaPorUeAnoLetivoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioFuncionarioEol.ObterFuncionariosExternosSga(request.AnoLetivo,request.CodigoEscola);
        }
    }
}