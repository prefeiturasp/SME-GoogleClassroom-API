using Dapper;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SME.GoogleClassroom.Dados.Help
{
    public static class FiltroCargaInicialSql
    {
        public const string TabelaTiposUe = "#filtroTiposUe";
        public const string TabelaUes = "#filtroUes";
        public const string TabelaTurmas = "#filtroTurmas";

        public static StringBuilder AdicionarTabelasFiltroCargaInicial(this StringBuilder query, ParametrosCargaInicialDto p)
        {
            query.AdicionarTabelaFiltro(p?.TiposUes, TabelaTiposUe, "tiposUesCsv", "INT");
            query.AdicionarTabelaFiltro(p?.Ues, TabelaUes, "uesCsv", "VARCHAR(10)");
            query.AdicionarTabelaFiltro(p?.Turmas, TabelaTurmas, "turmasCsv", "INT");
            return query;
        }

        public static StringBuilder AdicionarCondicoesCargaInicial(this StringBuilder query, ParametrosCargaInicialDto p,
            string colunaTipoUe, string colunaUe, string colunaTurma)
        {
            query.AdicionarCondicaoInTabela(p?.TiposUes, colunaTipoUe, TabelaTiposUe);
            query.AdicionarCondicaoInTabela(p?.Ues, colunaUe, TabelaUes);
            query.AdicionarCondicaoInTabela(p?.Turmas, colunaTurma, TabelaTurmas);
            return query;
        }

        public static DynamicParameters ObterParametrosCargaInicial(ParametrosCargaInicialDto p)
        {
            var parametros = new DynamicParameters();
            parametros.Add("tiposUesCsv", Juntar(p?.TiposUes));
            parametros.Add("uesCsv", Juntar(p?.Ues));
            parametros.Add("turmasCsv", Juntar(p?.Turmas));
            return parametros;
        }

        private static void AdicionarTabelaFiltro<T>(this StringBuilder query, IEnumerable<T> valores,
            string tabela, string parametro, string tipoSql)
        {
            if (valores == null || !valores.Any()) return;

            query.AppendLine($"IF OBJECT_ID('tempdb..{tabela}') IS NOT NULL DROP TABLE {tabela};");
            query.AppendLine($@"SELECT DISTINCT CAST(LTRIM(RTRIM(item.c.value('.', 'VARCHAR(50)'))) AS {tipoSql}) AS valor
                        INTO {tabela}
                        FROM (SELECT CAST('<i>' + REPLACE(CAST(@{parametro} AS NVARCHAR(MAX)), ',', '</i><i>') + '</i>' AS XML) AS x) lista
                        CROSS APPLY lista.x.nodes('/i') item(c)
                        WHERE LTRIM(RTRIM(item.c.value('.', 'VARCHAR(50)'))) <> '';");
        }

        private static void AdicionarCondicaoInTabela<T>(this StringBuilder query, IEnumerable<T> valores,
            string coluna, string tabela)
        {
            if (valores == null || !valores.Any()) return;
            query.AppendLine($" AND {coluna} IN (SELECT valor FROM {tabela})");
        }

        private static string Juntar<T>(IEnumerable<T> valores)
            => valores == null ? string.Empty : string.Join(",", valores);

        public static string ObterScriptTabelasFiltroCargaInicial(ParametrosCargaInicialDto p)
            => new StringBuilder().AdicionarTabelasFiltroCargaInicial(p).ToString();
    }
}
