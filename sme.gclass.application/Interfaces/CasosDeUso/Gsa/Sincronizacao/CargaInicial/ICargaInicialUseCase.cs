using SME.GoogleClassroom.Infra.Dtos.Gsa.Carga_Inicial;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces.CasosDeUso.Gsa.Sincronizacao.CargaInicial
{
    public interface ICargaInicialUseCase
    {
        Task<bool> Executar(FiltroCargaInicial filtro);
    }
}
