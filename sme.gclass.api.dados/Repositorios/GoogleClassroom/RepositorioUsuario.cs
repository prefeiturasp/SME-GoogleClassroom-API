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
        private readonly ConnectionStrings connectionStrings;

        public RepositorioUsuario(ConnectionStrings connectionStrings)
        {
            this.connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        public async Task<PaginacaoResultadoDto<UsuarioDto>> ObterFuncionariosAsync(Paginacao paginacao)
        {
            var query = new StringBuilder(@"SELECT u.id, 
                                                   u.usuario_tipo as usuariotipo,
                                                   u.email,
                                                   u.organization_path as organizationpath,
                                                   u.data_inclusao as datainclusao,
                                                   u.data_atualizacao as dataatualizacao
                                              FROM usuarios u 
                                             WHERE usuario_tipo = 3");
            if (paginacao.QuantidadeRegistros > 0)
            {
                query.AppendLine($" OFFSET {paginacao.QuantidadeRegistrosIgnorados} ROWS FETCH NEXT {paginacao.QuantidadeRegistros} ROWS ONLY ; ");
            }
            else
            {
                query.AppendLine(";");
            }

            query.AppendLine("SELECT count(*) from usuarios u where usuario_tipo = 3");

            var retorno = new PaginacaoResultadoDto<UsuarioDto>();

            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);

            using var funcionarios = await conn.QueryMultipleAsync(query.ToString());

            retorno.Items = funcionarios.Read<UsuarioDto>();
            retorno.TotalRegistros = funcionarios.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        public async Task<PaginacaoResultadoDto<UsuarioDto>> ObterProfessoresAsync(Paginacao paginacao)
        {
            var query = new StringBuilder(@"SELECT u.id, 
                                                   u.usuario_tipo as usuariotipo,
                                                   u.email,
                                                   u.organization_path as organizationpath,
                                                   u.data_inclusao as datainclusao,
                                                   u.data_atualizacao as dataatualizacao
                                              FROM usuarios u 
                                             WHERE usuario_tipo = 2");
            if (paginacao.QuantidadeRegistros > 0)
            {
                query.AppendLine($" OFFSET {paginacao.QuantidadeRegistrosIgnorados} ROWS FETCH NEXT {paginacao.QuantidadeRegistros} ROWS ONLY ; ");
            }
            else
            {
                query.AppendLine(";");
            }

            query.AppendLine("SELECT count(*) from usuarios u");

            var retorno = new PaginacaoResultadoDto<UsuarioDto>();

            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);

            using var professores = await conn.QueryMultipleAsync(query.ToString());

            retorno.Items = professores.Read<UsuarioDto>();
            retorno.TotalRegistros = professores.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }
        

        public async Task<IEnumerable<UsuarioDto>> ObterFuncionariosPorRfs(long[] rfs)
        {
            var query = @"SELECT u.id, 
                                 u.usuario_tipo as usuariotipo,
                                 u.email,
                                 u.organization_path as organizationpath,
                                 u.data_inclusao as datainclusao,
                                 u.data_atualizacao as dataatualizacao
                            FROM usuarios u 
                           WHERE usuario_tipo = 3
                             and id = any(@rfs)";

            var parametros = new { rfs };

            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);

            return await conn.QueryAsync<UsuarioDto>(query, parametros);

        }
        public async Task<bool> ExisteFuncionarioPorRf(long rf)
        {
            var query = @"SELECT count(id) from usuarios ";
            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);
            return (await conn.QueryAsync<bool>(query, new { rf })).FirstOrDefault();
        }
    }
}
