using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IObterFuncionariosParaIncluirGoogleUseCase
    {
        Task<PaginacaoResultadoDto<FuncionarioParaIncluirGoogleDto>> Executar(int registrosQuantidade, int paginaNumero, DateTime ultimaAtualizacao);
    }
}