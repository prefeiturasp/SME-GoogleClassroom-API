using Dapper;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace SME.GoogleClassroom.Dados
{
    public static class DapperExtensionMethods
    {
        private static IServicoTelemetria servicoTelemetria;

        public static void Init(IServicoTelemetria servicoTelemetriaSgp)
        {
            servicoTelemetria = servicoTelemetriaSgp;
        }

        public static IEnumerable<dynamic> Query(this IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null, string queryName = "query")
        {

            throw new NotImplementedException("Telemtria não implementada para esta função;");

            //var result = servicoTelemetria.RegistrarAsync( async () => await Task.FromResult(SqlMapper.Query(cnn, sql, param, transaction, buffered, commandTimeout, commandType)), "Postgres", "Query", sql);


            //return default;
            //var inicioOperacao = DateTime.UtcNow;
            //var timer = System.Diagnostics.Stopwatch.StartNew();
            //IEnumerable<dynamic> result = default;
            //try
            //{
            //    var transactionElk = Agent.Tracer.CurrentTransaction;

            //    transactionElk.CaptureSpan("Query", "Postgres", () =>
            //    {
            //        result = SqlMapper.Query(cnn, sql, param, transaction, buffered, commandTimeout, commandType);
            //    });                

            //    timer.Stop();

            //    insightsClient?.TrackDependency("PostgreSQL", "Query", sql, inicioOperacao, timer.Elapsed, true);

            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    insightsClient?.TrackDependency("PostgreSQL", "Query", $"{sql} -> erro: {ex.Message}", inicioOperacao, timer.Elapsed, false);
            //    throw ex;
            //}

        }

        public static IEnumerable<T> Query<T>(this IDbConnection Connection, string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null, string queryName = "")
        {
            var result = servicoTelemetria.RegistrarComRetorno<T>(() => SqlMapper.Query<T>(Connection, sql, param, transaction, buffered, commandTimeout, commandType), "Postgres", $"Query {queryName}", sql);

            return result;
        }

        public static async Task<GridReader> QueryMultipleAsync(this IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, string queryName = "")
        {
            var result = await servicoTelemetria.RegistrarComRetornoAsync<GridReader>(async () => await SqlMapper.QueryMultipleAsync(cnn, sql, param, transaction, commandTimeout, commandType), "Postgres", $"Query {queryName}", sql);

            return result;
        }

        public static async Task<T> QuerySingleOrDefaultAsync<T>(this IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, string queryName = "")
        {
            var result = await servicoTelemetria.RegistrarComRetornoAsync<T>(async () => await SqlMapper.QuerySingleOrDefaultAsync<T>(cnn, sql, param, transaction, commandTimeout, commandType), "Postgres", $"Query {queryName}", sql);

            return result;
        }

        public static async Task<IEnumerable<T>> QueryAsync<T>(this IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, string queryName = "")
        {
            var result = await servicoTelemetria.RegistrarComRetornoAsync<T>(async () => await SqlMapper.QueryAsync<T>(cnn, sql, param, transaction, commandTimeout, commandType), "Postgres", $"Query {queryName}", sql);

            return result;
        }

        public static async Task<T> QueryFirstOrDefaultAsync<T>(this IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, string queryName = "Query Postgres")
        {
            var result = await servicoTelemetria.RegistrarComRetornoAsync<T>(async () => await SqlMapper.QueryFirstOrDefaultAsync<T>(cnn, sql, param, transaction, commandTimeout, commandType), "Postgres", $"Query {queryName}", sql);

            return result;
        }

        public static IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, string queryName = "Query Postgres")
        {
            var result = servicoTelemetria.RegistrarComRetorno<TReturn>(() => SqlMapper.Query(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType), "Postgres", $"Query {queryName}", sql);

            return result;
        }

        public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, string queryName = "Query Postgres")
        {
            var result = servicoTelemetria.RegistrarComRetorno<TReturn>(() => SqlMapper.Query(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType), "Postgres", $"Query {queryName}", sql);

            return result;
        }
        public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, string queryName = "Query Postgres")
        {
            var result = servicoTelemetria.RegistrarComRetorno<TReturn>(() => SqlMapper.Query(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType), "Postgres", $"Query {queryName}", sql);

            return result;
        }
        public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, string queryName = "Query Postgres")
        {
            var result = servicoTelemetria.RegistrarComRetorno<TReturn>(() => SqlMapper.Query(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType), "Postgres", $"Query {queryName}", sql);

            return result;
        }
        public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, string queryName = "Query Postgres")
        {
            var result = servicoTelemetria.RegistrarComRetorno<TReturn>(() => SqlMapper.Query(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType), "Postgres", $"Query {queryName}", sql);

            return result;
        }

        public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, string queryName = "Query Postgres")
        {
            var result = servicoTelemetria.RegistrarComRetorno<TReturn>(() => SqlMapper.Query(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType), "Postgres", $"Query {queryName}", sql);

            return result;
        }

        public static async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, string queryName = "Query Postgres")
        {
            var result = await servicoTelemetria.RegistrarComRetornoAsync<TReturn>(async () => await SqlMapper.QueryAsync(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType), "Postgres", $"Query {queryName}", sql);

            return result;
        }
        public static async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, string queryName = "Query Postgres")
        {
            var result = await servicoTelemetria.RegistrarComRetornoAsync<TReturn>(async () => await SqlMapper.QueryAsync(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType), "Postgres", $"Query {queryName}", sql);

            return result;
        }

        public static async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, string queryName = "Query Postgres")
        {
            var result = await servicoTelemetria.RegistrarComRetornoAsync<TReturn>(async () => await SqlMapper.QueryAsync(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType), "Postgres", $"Query {queryName}", sql);

            return result;
        }

        public static async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, string queryName = "Query Postgres")
        {
            var result = await servicoTelemetria.RegistrarComRetornoAsync<TReturn>(async () => await SqlMapper.QueryAsync(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType), "Postgres", $"Query {queryName}", sql);

            return result;
        }

        public static async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, string queryName = "Query Postgres")
        {
            var result = await servicoTelemetria.RegistrarComRetornoAsync<TReturn>(async () => await SqlMapper.QueryAsync(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType), "Postgres", $"Query {queryName}", sql);

            return result;
        }
        public static async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null, string queryName = "Query Postgres")
        {
            var result = await servicoTelemetria.RegistrarComRetornoAsync<TReturn>(async () => await SqlMapper.QueryAsync(cnn, sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType), "Postgres", $"Query {queryName}", sql);

            return result;
        }

        public static int Execute(this IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, string queryName = "Command Postgres")
        {
            var result = servicoTelemetria.RegistrarComRetorno<int>(() => SqlMapper.Execute(cnn, sql, param, transaction, commandTimeout, commandType), "Postgres", $"Command {queryName}", sql);

            return result;
        }

        public static int Execute(this IDbConnection cnn, CommandDefinition command, string queryName = "Command Postgres")
        {
            var result = servicoTelemetria.RegistrarComRetorno<int>(() => SqlMapper.Execute(cnn, command), "Postgres", $"Command {queryName}", command.ToString());

            return result;
        }
    }
}
