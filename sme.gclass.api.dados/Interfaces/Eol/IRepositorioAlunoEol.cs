using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioAlunoEol
    {
        Task<PaginacaoResultadoDto<AlunoDto>> ObterAlunosAsync(Paginacao paginacao, int anoLetivo, DateTime dataReferencia);
    }
}
