using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Aplicacao.Queries.Usuarios.Funcionarios.ObterFuncionarioEolPorUeAnoLetivo
{
    public class ObterFuncionarioEolPorUeAnoLetivoQueryHandler : IRequestHandler<ObterFuncionarioEolPorUeAnoLetivoQuery,IEnumerable<FuncionarioDto>>
    {
        private IRepositorioFuncionarioEol repositorioFuncionarioEol;

        public ObterFuncionarioEolPorUeAnoLetivoQueryHandler(IRepositorioFuncionarioEol funcionarioEol)
        {
            repositorioFuncionarioEol = funcionarioEol ?? throw new ArgumentNullException(nameof(funcionarioEol));
        }

        public async Task<IEnumerable<FuncionarioDto>> Handle(ObterFuncionarioEolPorUeAnoLetivoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioFuncionarioEol.ObterFuncionarioEolPorUeAnoLetivo(request.AnoLetivo,request.CodigoEscola,request.EscolaEhCieja);
        }
    }
}