using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroCursoErroDto
    {
        public FiltroCursoErroDto(CursoErro cursoErro, FiltroCargaInicialDto filtroCargaInicial)
        {
            CursoErro = cursoErro;
            FiltroCargaInicial = filtroCargaInicial;
        }

        public CursoErro CursoErro { get; set; }
        public FiltroCargaInicialDto FiltroCargaInicial { get; set; }
    }
}
