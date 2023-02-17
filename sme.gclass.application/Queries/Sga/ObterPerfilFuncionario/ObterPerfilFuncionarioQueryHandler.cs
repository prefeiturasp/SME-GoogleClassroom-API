using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Aplicacao.Queries.Sga.ObterPerfilUsuario
{
    public class ObterPerfilFuncionarioQueryHandler : IRequestHandler<ObterPerfilFuncionarioQuery,IEnumerable<PerfilFuncionarioDto>>
    {
        private IRepositorioFuncionarioEol repositorioFuncionarioEol;

        public ObterPerfilFuncionarioQueryHandler(IRepositorioFuncionarioEol funcionarioEol)
        {
            repositorioFuncionarioEol = funcionarioEol ?? throw new ArgumentNullException(nameof(funcionarioEol));
        }

        public async Task<IEnumerable<PerfilFuncionarioDto>> Handle(ObterPerfilFuncionarioQuery request, CancellationToken cancellationToken)
        {
            var retorno = request.EhFuncionarioExterno ? await repositorioFuncionarioEol.ObterPerfilFuncionarioExternoPorFuncao(request.CodigosFuncao)
                                                       : await repositorioFuncionarioEol.ObterPerfilFuncionarioPorFuncao(request.CodigosFuncao);
            return retorno;
        }
    }
}