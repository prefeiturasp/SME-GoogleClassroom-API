using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Aplicacao.Queries.ParametroSistema.ObterParametroSistemaPorTipoEAno
{
    public class ObterParametroSistemaPorTipoEAnoQuery: IRequest<string>
    {
        public int Tipo { get; set; }
        public int Ano { get; set; }
    }
}
