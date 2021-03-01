using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterProfessoresParaIncluirGoogleUseCase
    {
        Task<PaginacaoResultadoDto<ProfessorEol>> Executar(int registrosQuantidade, int paginaNumero, DateTime ultimaAtualizacao);
    }
}