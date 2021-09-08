using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroPaginacaoDto : FiltroPaginacaoBaseDto
    {
        public FiltroPaginacaoDto(int pagina, int registros)
        {
            PaginaNumero = pagina;
            RegistrosQuantidade = registros;
        }
    }
}
