using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExcluirCursoErroCommandHandler : IRequestHandler<ExcluirCursoErroCommand, bool>
    {
        private readonly IRepositorioCursoErro repositorioCursoErro;

        public ExcluirCursoErroCommandHandler(IRepositorioCursoErro repositorioCursoErro)
        {
            this.repositorioCursoErro = repositorioCursoErro ?? throw new ArgumentNullException(nameof(repositorioCursoErro));
        }

        public async Task<bool> Handle(ExcluirCursoErroCommand request, CancellationToken cancellationToken)
        {
            await repositorioCursoErro.Excluir(request.Id);
            return true;
        }
    }
}
