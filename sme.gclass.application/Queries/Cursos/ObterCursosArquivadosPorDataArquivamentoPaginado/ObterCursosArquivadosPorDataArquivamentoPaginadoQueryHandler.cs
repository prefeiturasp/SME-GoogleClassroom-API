using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Queries.Cursos.ObterCursosArquivadosPorDataArquivamentoPaginado
{
    public class ObterCursosArquivadosPorDataArquivamentoPaginadoQueryHandler : IRequestHandler<ObterCursosArquivadosPorDataArquivamentoPaginadoQuery, PaginacaoResultadoDto<CursoArquivadoDto>>
    {
        private readonly IRepositorioCursoArquivado _repositorioCursoArquivado;

        public ObterCursosArquivadosPorDataArquivamentoPaginadoQueryHandler(IRepositorioCursoArquivado repositorioCursoArquivado)
        {
            _repositorioCursoArquivado = repositorioCursoArquivado ?? throw new ArgumentNullException(nameof(repositorioCursoArquivado));
        }

        public async Task<PaginacaoResultadoDto<CursoArquivadoDto>> Handle(
            ObterCursosArquivadosPorDataArquivamentoPaginadoQuery request, CancellationToken cancellationToken)
            => await _repositorioCursoArquivado.BuscarTodosPorDataExtincao(request.DataArquivamento, request.Paginacao);

    }
}