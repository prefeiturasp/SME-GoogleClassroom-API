using SME.GoogleClassroom.Dominio.Entidades.Gsa.Mural;
using SME.GoogleClassroom.Infra.Dtos.Aviso;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces.CasosDeUso.Avisos
{
    public interface IObterAvisoUseCase
    {
        Task<IEnumerable<AvisoGsa>> Executar(FiltroObterAvisoDto filtro);
    }
}