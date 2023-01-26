using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioParametrosEol
    {
        Task<ParametroAPIEol> ObterParametroAPIPorNome(string nome);
    }
}
