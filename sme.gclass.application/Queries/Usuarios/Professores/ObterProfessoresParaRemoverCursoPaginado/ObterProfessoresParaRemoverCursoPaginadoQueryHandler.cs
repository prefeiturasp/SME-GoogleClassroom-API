using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    class ObterProfessoresParaRemoverCursoPaginadoQueryHandler : IRequestHandler<ObterProfessoresParaRemoverCursoPaginadoQuery, PaginacaoResultadoDto<RemoverAtribuicaoProfessorCursoEolDto>>
    {
        private readonly IRepositorioProfessorEol repositorio;

        public ObterProfessoresParaRemoverCursoPaginadoQueryHandler(IRepositorioProfessorEol repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }


        public async Task<PaginacaoResultadoDto<RemoverAtribuicaoProfessorCursoEolDto>> Handle(ObterProfessoresParaRemoverCursoPaginadoQuery request, CancellationToken cancellationToken)
            => await repositorio.ObterProfessoresParaRemoverCursoPaginado(request.TurmaId, request.DataInicio, request.DataFim, request.Paginacao);
    }
}
