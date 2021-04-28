using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroCargaUsuariosGoogleDto
    {
        public FiltroCargaUsuariosGoogleDto(string tokenProximaPagina)
        {
            TokenProximaPagina = tokenProximaPagina;
        }

        public string TokenProximaPagina { get; set; }
    }
}
