using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterFuncionariosIndiretosQueSeraoInativadosQueryHandler : IRequestHandler<ObterFuncionariosIndiretosQueSeraoInativadosQuery, IEnumerable<string>>
    {
        private readonly IRepositorioFuncionarioIndiretoEol repositorio;

        public ObterFuncionariosIndiretosQueSeraoInativadosQueryHandler(IRepositorioFuncionarioIndiretoEol repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<IEnumerable<string>> Handle(ObterFuncionariosIndiretosQueSeraoInativadosQuery request, CancellationToken cancellationToken)
        {
            return await repositorio.ObterFuncionariosIndiretosQueSeraoInativados(request.Cpf);
        }
    }
}
