using Dapper;
using Npgsql;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly ConnectionStrings ConnectionStrings;

        public RepositorioUsuario(ConnectionStrings connectionStrings)
        {
            this.ConnectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        public async Task<PaginacaoResultadoDto<Usuario>> ObterAlunosAsync(Paginacao paginacao)
        {
            var query = new StringBuilder(@"SELECT u.id, 
                                                   u.usuario_tipo as usuariotipo,
                                                   u.email,
                                                   u.organization_path as organizationpath,
                                                   u.data_inclusao as datainclusao,
                                                   u.data_atualizacao as dataatualizacao
                                              FROM usuarios u 
                                             WHERE usuario_tipo = 1"); 
            if (paginacao.QuantidadeRegistros > 0)
                query.AppendLine($" OFFSET {paginacao.QuantidadeRegistrosIgnorados} ROWS FETCH NEXT {paginacao.QuantidadeRegistros} ROWS ONLY ; ");

            query.AppendLine("SELECT count(*) from usuarios u");

            var retorno = new PaginacaoResultadoDto<Usuario>();

            using var conn = new NpgsqlConnection(ConnectionStrings.ConnectionStringGoogleClassroom);

            using var alunos = await conn.QueryMultipleAsync(query.ToString());

            retorno.Items = alunos.Read<Usuario>();
            retorno.TotalRegistros = alunos.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        public async Task<bool> ExisteAlunoPorRf(long rf)
        {
            var query = @"SELECT count(id) from usuarios where id = @rf";
            using var conn = new NpgsqlConnection(ConnectionStrings.ConnectionStringGoogleClassroom);
            return (await conn.QueryAsync<bool>(query, new { rf })).FirstOrDefault();
        }

        public async Task<string> ObterEmailUsuarioPorTipo(string email, int usuarioTipo)
        {
            var query = @"SELECT email from usuarios where email = @email and usuario_tipo = @usuarioTipo";
            using var conn = new NpgsqlConnection(ConnectionStrings.ConnectionStringGoogleClassroom);
            return (await conn.QueryFirstOrDefaultAsync<string>(query, new { email, usuarioTipo }));
        }
    }
}
