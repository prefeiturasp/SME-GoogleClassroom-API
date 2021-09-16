using System;
using System.Threading.Tasks;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioCursoArquivado
    {
        Task Inserir(long cursoId, DateTime dataArquivamento, DateTime dataExtincao, bool extinto);

        Task<PaginacaoResultadoDto<CursoArquivadoDto>> BuscarTodosPorDataExtincao(DateTime dataExtincao,
            Paginacao paginacao);
    }
}
