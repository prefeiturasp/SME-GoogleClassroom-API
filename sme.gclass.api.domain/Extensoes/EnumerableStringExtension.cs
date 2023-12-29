using System.Collections.Generic;
using System.Linq;

namespace SME.GoogleClassroom.Dominio
{
    namespace SME.CDEP.Dominio.Extensions
    {
        public static class EnumerableStringExtension
        {
            public static bool PossuiElementos<T>(this IEnumerable<T> items)
            {
                return items.NaoEhNulo() && items.Any();
            }
        
            public static bool NaoPossuiElementos<T>(this IEnumerable<T> items)
            {
                return items.EhNulo() || !items.Any();
            }
        }
    }
}