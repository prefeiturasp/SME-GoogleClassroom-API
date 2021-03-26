using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteProfessorPorRfQueryHandler : IRequestHandler<ExisteProfessorPorRfQuery, bool>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ExisteProfessorPorRfQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<bool> Handle(ExisteProfessorPorRfQuery request, CancellationToken cancellationToken)
        {
            var existe = await repositorioUsuario.ExisteProfessorPorRf(request.Rf);
            return existe;
        }
    }
}
