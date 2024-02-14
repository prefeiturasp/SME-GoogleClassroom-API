

using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class VerificarSeExisteAlunoPorCfpOuRaQueryHandler : IRequestHandler<VerificarSeExisteAlunoPorCfpOuRaQuery, bool>
    {
        public VerificarSeExisteAlunoPorCfpOuRaQueryHandler(IRepositorioAlunoEol repositorioAlunoEol)
        {
            this.repositorioAlunoEol = repositorioAlunoEol ?? throw new ArgumentNullException(nameof(repositorioAlunoEol));
        }
        private readonly IRepositorioAlunoEol repositorioAlunoEol;
        public async Task<bool> Handle(VerificarSeExisteAlunoPorCfpOuRaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAlunoEol.VerificarSeExisteAlunoPorCpfOuRA(request.RaAluno,request.Cpf);
        }
    }
}
