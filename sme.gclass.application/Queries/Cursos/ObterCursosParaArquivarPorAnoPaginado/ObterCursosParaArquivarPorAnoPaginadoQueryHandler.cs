using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosParaArquivarPorAnoPaginadoQueryHandler : IRequestHandler<ObterCursosParaArquivarPorAnoPaginadoQuery, PaginacaoResultadoDto<CursoArquivarEolDto>>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;

        public ObterCursosParaArquivarPorAnoPaginadoQueryHandler(IRepositorioCursoEol repositorioCursoEol)
        {
            this.repositorioCursoEol = repositorioCursoEol ?? throw new ArgumentNullException(nameof(repositorioCursoEol));
        }

        public async Task<PaginacaoResultadoDto<CursoArquivarEolDto>> Handle(ObterCursosParaArquivarPorAnoPaginadoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCursoEol.ObterCursosParaArquivarPorAnoPaginado(request.AnoLetivo, request.Semestre, request.Paginacao);
        }
    }
}
