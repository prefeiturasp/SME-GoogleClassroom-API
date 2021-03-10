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

        public async Task<PaginacaoResultadoDto<AlunoGoogle>> ObterAlunosAsync(Paginacao paginacao, long? codigoEol, string email)
        {
            var query = new StringBuilder(@"SELECT 
                                                   u.indice,
                                                   u.id AS Codigo, 
                                                   u.nome AS Nome,
                                                   u.email AS Email,
                                                   u.organization_path as organizationpath,
                                                   u.data_inclusao as datainclusao,
                                                   u.data_atualizacao as dataatualizacao
                                              FROM usuarios u 
                                             WHERE u.usuario_tipo = @tipo ");
            if (codigoEol.HasValue && codigoEol > 0)
                query.AppendLine("AND u.id = @codigoEol");

            if(!string.IsNullOrEmpty(email))
                query.AppendLine("AND u.email = @email");

            if (paginacao.QuantidadeRegistros > 0)
                query.AppendLine($" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY ");

            query.AppendLine(";");

            query.AppendLine($"SELECT count(*) from usuarios u WHERE u.usuario_tipo = @tipo ");
            if (codigoEol.HasValue && codigoEol > 0)
                query.AppendLine($"and u.id = @codigoEol");

            var retorno = new PaginacaoResultadoDto<AlunoGoogle>();

            var parametros = new
            {
                paginacao.QuantidadeRegistrosIgnorados,
                paginacao.QuantidadeRegistros,
                tipo = UsuarioTipo.Aluno,  
                codigoEol,
                email
            };

            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);

            using var alunos = await conn.QueryMultipleAsync(query.ToString(), parametros);

            retorno.Items = alunos.Read<AlunoGoogle>();
            retorno.TotalRegistros = alunos.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        public async Task<bool> ExisteAlunoPorRf(long rf)
        {
            var query = @"SELECT exists(SELECT 1 from usuarios where id = @rf and usuario_tipo = @usuarioTipo limit 1)";
            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);
            return (await conn.QueryAsync<bool>(query, new { rf, usuarioTipo = UsuarioTipo.Aluno })).FirstOrDefault();
        }

        public async Task<string> ObterEmailUsuarioPorTipo(string email, int usuarioTipo)
        {
            var query = @"SELECT email from usuarios where email = @email and usuario_tipo = @usuarioTipo";
            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);
            return (await conn.QueryFirstOrDefaultAsync<string>(query, new { email, usuarioTipo }));
        }

        public async Task<PaginacaoResultadoDto<FuncionarioGoogle>> ObterFuncionariosAsync(Paginacao paginacao, long? rf, string email)
        {
            var query = new StringBuilder(@"SELECT 
                                                   u.indice,
                                                   u.id AS Rf, 
                                                   u.nome AS Nome,
                                                   u.email AS Email,
                                                   u.organization_path as OrganizationPath,
                                                   u.data_inclusao as DataInclusao,
                                                   u.data_atualizacao as DataAtualizacao
                                              FROM usuarios u 
                                             WHERE usuario_tipo = @tipo ");
            if (rf.HasValue && rf > 0)
                query.AppendLine($"AND u.id = @rf");

            if (!string.IsNullOrEmpty(email))
                query.AppendLine($"AND u.email = @email");

            if (paginacao.QuantidadeRegistros > 0)
                query.AppendLine($" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY ");

            query.AppendLine(";");

            query.AppendLine("SELECT count(*) from usuarios u where usuario_tipo = @tipo");

            var retorno = new PaginacaoResultadoDto<FuncionarioGoogle>();

            var parametros = new
            {
                paginacao.QuantidadeRegistrosIgnorados,
                paginacao.QuantidadeRegistros,
                tipo = UsuarioTipo.Professor,
                rf,
                email
            };

            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);

            using var funcionarios = await conn.QueryMultipleAsync(query.ToString(), parametros);

            retorno.Items = funcionarios.Read<FuncionarioGoogle>();
            retorno.TotalRegistros = funcionarios.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        public async Task<PaginacaoResultadoDto<ProfessorGoogle>> ObterProfessoresAsync(Paginacao paginacao, long? rf, string email)
        {
            var query = new StringBuilder(@"SELECT 
                                                   u.indice,
                                                   u.id AS Rf, 
                                                   u.nome AS Nome,
                                                   u.email AS Email,
                                                   u.organization_path as OrganizationPath,
                                                   u.data_inclusao as DataInclusao,
                                                   u.data_atualizacao as DataAtualizacao
                                              FROM usuarios u 
                                             WHERE usuario_tipo = @tipo ");

            if (rf.HasValue && rf > 0)
                query.AppendLine($"AND u.id = @rf");

            if (!string.IsNullOrEmpty(email))
                query.AppendLine($"AND u.email = @email");

            if (paginacao.QuantidadeRegistros > 0)
                query.AppendLine($" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY ");

            query.AppendLine(";");


            query.AppendLine("SELECT count(*) from usuarios u WHERE usuario_tipo = @tipo");

            var retorno = new PaginacaoResultadoDto<ProfessorGoogle>();

            var parametros = new
            {
                paginacao.QuantidadeRegistrosIgnorados,
                paginacao.QuantidadeRegistros,
                tipo = UsuarioTipo.Professor,
                rf,
                email
            };

            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);

            using var professores = await conn.QueryMultipleAsync(query.ToString(), parametros);

            retorno.Items = professores.Read<ProfessorGoogle>();
            retorno.TotalRegistros = professores.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }


        public async Task<IEnumerable<FuncionarioGoogle>> ObterFuncionariosPorRfs(long[] rfs)
        {
            var query = @"SELECT 
                                 u.indice,
                                 u.id as Rf, 
                                 u.usuario_tipo as usuariotipo,
                                 u.email,
                                 u.organization_path as organizationpath,
                                 u.data_inclusao as datainclusao,
                                 u.data_atualizacao as dataatualizacao
                            FROM usuarios u 
                           WHERE usuario_tipo = @tipo
                             and id = any(@rfs)";

            var parametros = new 
            { 
                rfs,
                tipo = UsuarioTipo.Funcionario
            };

            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);
            return await conn.QueryAsync<FuncionarioGoogle>(query, parametros);

        }

        public async Task<bool> ExisteFuncionarioPorRf(long rf)
        {
            var query = @"SELECT count(id) from usuarios where id = @rf and usuario_tipo = @tipo";
            var parametros = new
            {
                rf,
                tipo = UsuarioTipo.Funcionario
            };
            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);
            return (await conn.QueryAsync<bool>(query, parametros)).FirstOrDefault();
        }


        public async Task<IEnumerable<ProfessorGoogle>> ObterProfessoresPorRfs(long[] rfs)
        {
            var query = @"SELECT 
                                 u.indice,
                                 u.id as Rf, 
                                 u.usuario_tipo as usuariotipo,
                                 u.email,
                                 u.organization_path as organizationpath,
                                 u.data_inclusao as datainclusao,
                                 u.data_atualizacao as dataatualizacao
                            FROM usuarios u 
                           WHERE usuario_tipo = @tipo
                             and id = any(@rfs)";

            var parametros = new
            {
                rfs,
                tipo = UsuarioTipo.Professor
            };

            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);

            return await conn.QueryAsync<ProfessorGoogle>(query, parametros);
        }

        public async Task<bool> ExisteProfessorPorRf(long rf)
        {
            var query = @"SELECT count(id) from usuarios where id = @rf and usuario_tipo = @tipo";
            var parametros = new
            {
                rf,
                tipo = UsuarioTipo.Professor
            };
            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);
            return (await conn.QueryAsync<bool>(query, parametros)).FirstOrDefault();
        }

        public async Task<long> SalvarAsync(long id, string nome, string email, UsuarioTipo tipo, string organizationPath, DateTime dataInclusao, DateTime? dataAtualizacao)
        {
            const string insertQuery = @"insert into public.usuarios
                                        (id, nome, email, usuario_tipo, organization_path, data_inclusao, data_atualizacao)
                                        values
                                        (@id, @nome, @email, @tipo, @organizationPath, @dataInclusao, @dataAtualizacao)
                                        RETURNING indice";

            var parametros = new
            {
                id,
                nome,
                email,
                tipo,
                organizationPath,
                dataInclusao,
                dataAtualizacao
            };

            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);
            return await conn.ExecuteAsync(insertQuery, parametros);
        }
    }
}
