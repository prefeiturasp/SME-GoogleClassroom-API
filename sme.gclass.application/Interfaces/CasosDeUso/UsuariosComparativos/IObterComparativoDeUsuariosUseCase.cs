using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterComparativoDeUsuariosUseCase
    {
        Task<PaginacaoResultadoDto<UsuarioComparativo>> Executar(FiltroObterComparativoUsuarioDto filtro);
    }
}
