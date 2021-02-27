using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterProfessoresGoogleUseCase
    {
        Task<PaginacaoResultadoDto<UsuarioDto>> Executar(int registrosQuantidade, int paginaNumero);
    }
}