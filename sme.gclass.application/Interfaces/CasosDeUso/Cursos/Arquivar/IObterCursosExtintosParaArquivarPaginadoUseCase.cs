using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IObterCursosExtintosParaArquivarPaginadoUseCase : IUseCase<FiltroTurmasExtintasArquivarDto, PaginacaoResultadoDto<CursoExtintoEolDto>>
    {
    }
}
