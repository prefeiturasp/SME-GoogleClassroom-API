using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoPorEmailNomeQueryHandler : IRequestHandler<ObterCursoPorEmailNomeQuery, CursoGoogle>
    {
        private readonly IRepositorioCurso repositorioCurso;

        public ObterCursoPorEmailNomeQueryHandler(IRepositorioCurso repositorioCurso)
        {
            this.repositorioCurso = repositorioCurso ?? throw new ArgumentNullException(nameof(repositorioCurso));
        }

        public async Task<CursoGoogle> Handle(ObterCursoPorEmailNomeQuery request, CancellationToken cancellationToken)
        {
            var curso = await repositorioCurso.ObterCursoPorEmailNome(request.Email, request.Nome);

            return curso;
        }
    }
}
