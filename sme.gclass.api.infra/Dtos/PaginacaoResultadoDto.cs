using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class PaginacaoResultadoDto<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalPaginas { get; set; }
        public int TotalRegistros { get; set; }
    }
}
