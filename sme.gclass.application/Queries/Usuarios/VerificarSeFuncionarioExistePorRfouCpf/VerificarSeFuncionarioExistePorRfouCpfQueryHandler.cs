using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dados.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class VerificarSeFuncionarioExistePorRfouCpfQueryHandler : IRequestHandler<VerificarSeFuncionarioExistePorRfouCpfQuery, bool>
    {
        private readonly IRepositorioFuncionarioEol repositorioFuncionarioEol;
        public VerificarSeFuncionarioExistePorRfouCpfQueryHandler(IRepositorioFuncionarioEol repositorioFuncionarioEol)
        {
            this.repositorioFuncionarioEol = repositorioFuncionarioEol ?? throw new ArgumentNullException(nameof(repositorioFuncionarioEol));
        }
        public async Task<bool> Handle(VerificarSeFuncionarioExistePorRfouCpfQuery request, CancellationToken cancellationToken)
        {
            return await repositorioFuncionarioEol.VerificarSeFuncionarioExistePorRfouCpf(request.RF,request.Cpf);
        }

    }
}
