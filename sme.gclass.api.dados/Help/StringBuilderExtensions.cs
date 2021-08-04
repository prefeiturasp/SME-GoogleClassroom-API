using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SME.GoogleClassroom.Dados.Help
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AdicionarParametrosCargaInicial<T>(this StringBuilder query, IList<T> parametros,
            string coluna)
        {
            if (!parametros.Any())
            {
                return query;
            }
            
            var parametro = string.Join(",", parametros).Trim();
            query.AppendLine($"AND {coluna.Trim()} in ({parametro}) ");
            return query;
        }
    }
}