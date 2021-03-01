using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterCursosParaIncluirGoogleUseCase
    {
        Task<PaginacaoResultadoDto<CursoParaInclusaoDto>> Executar(int registrosQuantidade, int paginaNumero, DateTime ultimaAtualizacao);
    }
}
