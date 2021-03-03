using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterAlunosParaCadastrarUseCase
    {
        Task<PaginacaoResultadoDto<AlunoEol>> Executar(int registrosQuantidade, int paginaNumero, DateTime dataReferencia, long codigoEol);
    }
}
