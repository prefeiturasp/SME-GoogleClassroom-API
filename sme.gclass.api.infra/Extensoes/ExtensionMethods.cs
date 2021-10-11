using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Infra
{
    public static class ExtensionMethods
    {
        public static async Task<object> InvokeAsync(this MethodInfo @this, object obj, params object[] parameters)
        {
            dynamic awaitable = @this.Invoke(obj, parameters);
            await awaitable;
            return awaitable.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Total de blocos da lista de acordo com a quantidade de itens definido por bloco.
        /// </summary>
        /// <typeparam name="T">Objeto da lista.</typeparam>
        /// <param name="lista">Lista a ser divida em blocos.</param>
        /// <param name="quantidadeRegistrosPorBloco">Quantidade de registros definido por bloco.</param>
        /// <returns>Total de blocos.</returns>
        public static int TotalBlocos<T>(this List<T> lista, int quantidadeRegistrosPorBloco)
        {
            if (lista == null || !lista.Any() || quantidadeRegistrosPorBloco < 1)
                return 0;

            return (int)System.Math.Ceiling((double)lista.Count / (double)quantidadeRegistrosPorBloco);
        }

        /// <summary>
        /// Obtém um bloco específicoda lista de acordo com a quantidade de registros determinada por bloco.
        /// </summary>
        /// <typeparam name="T">Objeto da lista.</typeparam>
        /// <param name="lista">Lista a ser divida em blocos.</param>
        /// <param name="bloco">Número do bloco a ser obtido. Considere base 0.</param>
        /// <param name="quantidadeRegistrosPorBloco">Quantidade de registros para cada bloco.</param>
        /// <returns>Lista de itens de acordo com o bloco definido.</returns>
        public static List<T> ObterBloco<T>(this List<T> lista, int bloco, int quantidadeRegistrosPorBloco)
        {
            if (lista == null || !lista.Any() || quantidadeRegistrosPorBloco < 1)
                return new List<T>();

            var indiceUltimoRegistro = lista.IndexOf(lista.Last());
            var indiceInicialRange = bloco * quantidadeRegistrosPorBloco;
            var quantidadeRegistros = (indiceInicialRange + quantidadeRegistrosPorBloco) > lista.Count ? (indiceUltimoRegistro - indiceInicialRange) + 1 : quantidadeRegistrosPorBloco;

            if (quantidadeRegistros < 1)
                return new List<T>();

            return lista.GetRange(indiceInicialRange, quantidadeRegistros);
        }
    }
}
