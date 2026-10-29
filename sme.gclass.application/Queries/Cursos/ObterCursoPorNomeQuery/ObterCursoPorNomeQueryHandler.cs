using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoPorNomeQueryHandler : IRequestHandler<ObterCursoPorNomeQuery, CursoGoogle>
    {
        private readonly IRepositorioCurso repositorioCurso;

        public ObterCursoPorNomeQueryHandler(IRepositorioCurso repositorioCurso)
        {
            this.repositorioCurso = repositorioCurso ?? throw new ArgumentNullException(nameof(repositorioCurso));
        }

        public Task<CursoGoogle> Handle(ObterCursoPorNomeQuery request, CancellationToken cancellationToken)
            => repositorioCurso.ObterCursoPorNome(request.Nome);
    }
}