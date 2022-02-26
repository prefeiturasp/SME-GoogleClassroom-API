using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioComponenteCurricularFormacaoCidade
    {
        IEnumerable<SalaComponenteModalidadeDto> ObterComponenteCurricular();
    }
}
