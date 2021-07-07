using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterAlunosCursosRemovidosUseCase
    {
        Task<PaginacaoResultadoDto<UsuarioCursoRemovidoGsa>> Executar(FiltroObterAlunosCursosRemovidosDto filtro);
    }
}
