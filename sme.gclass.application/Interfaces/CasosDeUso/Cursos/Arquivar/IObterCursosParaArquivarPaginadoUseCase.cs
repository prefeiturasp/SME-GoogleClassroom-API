using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IObterCursosParaArquivarPaginadoUseCase : IUseCase<FiltroTurmasArquivarDto, PaginacaoResultadoDto<CursoArquivarEolDto>>
    {
    }
}
