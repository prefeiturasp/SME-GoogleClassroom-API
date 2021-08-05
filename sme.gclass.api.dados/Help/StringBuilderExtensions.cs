using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SME.GoogleClassroom.Dados.Help
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AdicionarCondicaoIn<T>(this StringBuilder query, IList<T> parametros,
            string coluna, string parametrosSql)
        {
            if (!parametros.Any())
            {
                return query;
            }
            
            query.AppendLine($" AND {coluna.Trim()} in @{parametrosSql}");
            return query;
        }
    }
}