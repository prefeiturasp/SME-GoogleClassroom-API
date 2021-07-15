using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterDadosTesteUseCase
    {
        Task<IEnumerable<CursoGoogle>> Executar(int satus);
    }
}
