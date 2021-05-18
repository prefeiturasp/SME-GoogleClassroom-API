using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoGooglePorIdQueryHandler : IRequestHandler<ObterCursoGooglePorIdQuery, CursoGoogle>
    {
        private readonly IRepositorioCurso repositorioCurso;

        public ObterCursoGooglePorIdQueryHandler(IRepositorioCurso repositorioCurso)
        {
            this.repositorioCurso = repositorioCurso ?? throw new ArgumentNullException(nameof(repositorioCurso));
        }

        public async Task<CursoGoogle> Handle(ObterCursoGooglePorIdQuery request, CancellationToken cancellationToken)
            => await repositorioCurso.ObterCursoPorId(request.Id);
    }
}
