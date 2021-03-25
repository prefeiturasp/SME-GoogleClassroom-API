using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionarioParaTratamentoDeErroQueryHandler : IRequestHandler<ObterFuncionarioParaTratamentoDeErroQuery, FuncionarioEol>
    {
        private readonly IRepositorioFuncionarioEol repositorioFuncionarioEol;

        public ObterFuncionarioParaTratamentoDeErroQueryHandler(IRepositorioFuncionarioEol repositorioFuncionarioEol)
        {
            this.repositorioFuncionarioEol = repositorioFuncionarioEol;
        }

        public async Task<FuncionarioEol> Handle(ObterFuncionarioParaTratamentoDeErroQuery request, CancellationToken cancellationToken)
            => await repositorioFuncionarioEol.ObterFuncionarioParaTratamentoDeErroAsync(request.Rf, DateTime.Now.Year);
    }
}