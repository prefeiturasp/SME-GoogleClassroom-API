using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterProfessoresParaIncluirGoogleUseCase
    {
        Task<PaginacaoResultadoDto<ProfessorParaIncluirGoogleDto>> Executar(int registrosQuantidade, int paginaNumero, DateTime ultimaAtualizacao);
    }
}