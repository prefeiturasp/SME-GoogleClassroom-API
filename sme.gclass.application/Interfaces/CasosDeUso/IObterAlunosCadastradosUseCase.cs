using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterAlunosCadastradosUseCase
    {
        Task<PaginacaoResultadoDto<Usuario>> Executar(int registrosQuantidade, int paginaNumero, long? codigoEol, string email);
    }
}
