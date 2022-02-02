using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroUsuarioErroDto
    {
        public FiltroUsuarioErroDto(UsuarioErro usuarioErro, FiltroCargaInicialDto filtroCargaInicial)
        {
            UsuarioErro = usuarioErro;
            FiltroCargaInicial = filtroCargaInicial;
        }

        public UsuarioErro UsuarioErro { get; set; }
        public FiltroCargaInicialDto FiltroCargaInicial { get; set; }
    }
}
