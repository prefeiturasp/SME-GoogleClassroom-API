using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IObterCursosArquivadosPaginadoUseCase : IUseCase<FiltroCursoArquivadoDto, PaginacaoResultadoDto<CursoArquivadoDto>>
    {
    }
}
