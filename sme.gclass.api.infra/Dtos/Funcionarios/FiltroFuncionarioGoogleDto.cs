using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroFuncionarioGoogleDto
    {
        public FiltroFuncionarioGoogleDto(FuncionarioGoogle funcionarioGoogle, ParametrosCargaInicialDto parametrosCargaInicial)
        {
            FuncionarioGoogle = funcionarioGoogle;
            ParametrosCargaInicial = parametrosCargaInicial;
        }

        public FuncionarioGoogle FuncionarioGoogle { get; set; }
        public ParametrosCargaInicialDto ParametrosCargaInicial { get; set; }
    }
}
