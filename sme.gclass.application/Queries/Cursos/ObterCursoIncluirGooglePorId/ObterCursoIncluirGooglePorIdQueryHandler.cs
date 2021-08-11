using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoIncluirGooglePorIdQueryHandler : IRequestHandler<ObterCursoIncluirGooglePorIdQuery, CursoEol>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ObterCursoIncluirGooglePorIdQueryHandler(IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol ?? throw new ArgumentNullException(nameof(repositorioCursoEol));
        }

        public async Task<CursoEol> Handle(ObterCursoIncluirGooglePorIdQuery request, CancellationToken cancellationToken)
            => await repositorioCursoEol.ObterCursoPorIdParaInclusao(request.ComponenteCurricularId, request.TurmaId, request.AnoLetivo, request.ParametrosCargaInicialDto);
    }
}
