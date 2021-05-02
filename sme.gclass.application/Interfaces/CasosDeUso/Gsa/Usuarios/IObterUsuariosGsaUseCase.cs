using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterUsuariosGsaUseCase
    {
        Task<PaginacaoResultadoDto<UsuarioGsa>> Executar(FiltroObterUsuariosGsaDto filtro);
    }
}
