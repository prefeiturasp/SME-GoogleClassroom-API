using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuario : RepositorioGoogle, IRepositorioUsuario
    {
        public RepositorioUsuario(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
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
                                                   u.data_atualizacao as dataatualizacao,
                                                   u.google_classroom_id as GoogleClassroomId
                                              FROM usuarios u
                                             WHERE u.usuario_tipo = @tipo ");

            var queryCount = new StringBuilder("SELECT count(*) from usuarios u WHERE u.usuario_tipo = @tipo ");

            if (codigoEol.HasValue && codigoEol > 0)
            {
                query.AppendLine("AND u.id = @codigoEol");
                queryCount.AppendLine("AND u.id = @codigoEol");
            }

            if (!string.IsNullOrEmpty(email))
            {
                query.AppendLine("AND u.email = @email");
                queryCount.AppendLine("AND u.email = @email");
            }

            if (paginacao.QuantidadeRegistros > 0)
                query.AppendLine($" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY ");

            query.AppendLine(";");
            query.AppendLine(queryCount.ToString());

            var retorno = new PaginacaoResultadoDto<AlunoGoogle>();

            var parametros = new
            {
                paginacao.QuantidadeRegistrosIgnorados,
                paginacao.QuantidadeRegistros,
                tipo = UsuarioTipo.Aluno,
                codigoEol,
                email = email?.Trim().ToLower()
            };

            using var conn = ObterConexao();

            using var alunos = await conn.QueryMultipleAsync(query.ToString(), parametros);

            retorno.Items = alunos.Read<AlunoGoogle>();
            retorno.TotalRegistros = alunos.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        public async Task<bool> ExisteAlunoPorRf(long rf)
        {
            var query = @"SELECT exists(SELECT 1 from usuarios where id = @rf and usuario_tipo = @usuarioTipo limit 1)";
            using var conn = ObterConexao();
            return (await conn.QueryAsync<bool>(query, new { rf, usuarioTipo = UsuarioTipo.Aluno })).FirstOrDefault();
        }

        public async Task<bool> ExisteEmailUsuarioPorTipo(string email, UsuarioTipo usuarioTipo)
        {
            var query = @"SELECT exists(SELECT 1 from usuarios where email = @email and usuario_tipo = @usuarioTipo limit 1)";
            using var conn = ObterConexao();
            return (await conn.QueryFirstOrDefaultAsync<bool>(query, new { email, usuarioTipo }));
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
                                                   u.data_atualizacao as DataAtualizacao,
                                                   u.google_classroom_id as GoogleClassroomId
                                              FROM usuarios u
                                             WHERE usuario_tipo = @tipo ");
            var queryCount = new StringBuilder("SELECT count(*) from usuarios u where usuario_tipo = @tipo ");

            if (rf.HasValue && rf > 0)
            {
                query.AppendLine($"AND u.id = @rf");
                queryCount.AppendLine($"AND u.id = @rf");
            }

            if (!string.IsNullOrEmpty(email))
            {
                query.AppendLine($"AND u.email = @email");
                queryCount.AppendLine($"AND u.email = @email");
            }

            if (paginacao.QuantidadeRegistros > 0)
                query.AppendLine($" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY ");

            query.AppendLine(";");

            query.AppendLine(queryCount.ToString());

            var retorno = new PaginacaoResultadoDto<FuncionarioGoogle>();

            var parametros = new
            {
                paginacao.QuantidadeRegistrosIgnorados,
                paginacao.QuantidadeRegistros,
                tipo = UsuarioTipo.Funcionario,
                rf,
                email = email?.Trim().ToLower()
            };

            using var conn = ObterConexao();

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
                                                   u.data_atualizacao as DataAtualizacao,
                                                   u.google_classroom_id as GoogleClassroomId
                                              FROM usuarios u
                                             WHERE usuario_tipo = @tipo ");

            var queryCount = new StringBuilder("SELECT count(*) from usuarios u WHERE usuario_tipo = @tipo ");

            if (rf.HasValue && rf > 0)
            {
                query.AppendLine($"AND u.id = @rf");
                queryCount.AppendLine($"AND u.id = @rf");
            }

            if (!string.IsNullOrEmpty(email))
            {
                query.AppendLine($"AND u.email = @email");
                queryCount.AppendLine($"AND u.email = @email");
            }

            if (paginacao.QuantidadeRegistros > 0)
                query.AppendLine($" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY ");

            query.AppendLine(";");

            query.AppendLine(queryCount.ToString());

            var retorno = new PaginacaoResultadoDto<ProfessorGoogle>();

            var parametros = new
            {
                paginacao.QuantidadeRegistrosIgnorados,
                paginacao.QuantidadeRegistros,
                tipo = UsuarioTipo.Professor,
                rf,
                email = email?.Trim().ToLower()
            };

            using var conn = ObterConexao();

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
                                 u.data_atualizacao as dataatualizacao,
                                 u.google_classroom_id as GoogleClassroomId
                            FROM usuarios u
                           WHERE usuario_tipo = @tipo
                             and id = any(@rfs)";

            var parametros = new
            {
                rfs,
                tipo = UsuarioTipo.Funcionario
            };

            using var conn = ObterConexao();
            return await conn.QueryAsync<FuncionarioGoogle>(query, parametros);
        }

        public async Task<bool> ExisteFuncionarioPorRf(long rf)
        {
            var query = @"SELECT exists(SELECT 1 from usuarios where id = @rf and usuario_tipo = @usuarioTipo limit 1)";
            var parametros = new
            {
                rf,
                usuarioTipo = UsuarioTipo.Funcionario
            };
            using var conn = ObterConexao();
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
                                 u.data_atualizacao as dataatualizacao,
                                 u.google_classroom_id as GoogleClassroomId
                            FROM usuarios u
                           WHERE usuario_tipo = any(@tipos)
                             and id = any(@rfs)";

            var parametros = new
            {
                rfs,
                tipos = new[] { (short)UsuarioTipo.Professor, (short)UsuarioTipo.Funcionario }
            };

            using var conn = ObterConexao();
            return await conn.QueryAsync<ProfessorGoogle>(query, parametros);
        }

        // TO DO: Alterar para utilizar classe abstrata quando fizermos a separação
        public async Task<PaginacaoResultadoDto<ProfessorGoogle>> ObterProfessoresFuncionariosPaginadoPorRfs(Paginacao paginacao, long[] rfs)
        {
            var query = new StringBuilder(@"SELECT
                                                 u.indice,
                                                 u.nome,
                                                 u.id as Rf,
                                                 u.usuario_tipo as usuariotipo,
                                                 u.email,
                                                 u.organization_path as organizationpath,
                                                 u.data_inclusao as datainclusao,
                                                 u.data_atualizacao as dataatualizacao,
                                                 u.google_classroom_id as GoogleClassroomId
                                            FROM usuarios u
                                           WHERE usuario_tipo = any(@tipos)
                                             and id = any(@rfs)");

            if (paginacao.QuantidadeRegistros > 0)
                query.AppendLine($" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY ;");

            query.AppendLine("SELECT count(*) from usuarios u WHERE usuario_tipo = any(@tipos) and id = any(@rfs)");

            var retorno = new PaginacaoResultadoDto<ProfessorGoogle>();

            var parametros = new
            {
                paginacao.QuantidadeRegistrosIgnorados,
                paginacao.QuantidadeRegistros,
                rfs,
                tipos = new[] { (short)UsuarioTipo.Professor, (short)UsuarioTipo.Funcionario }
            };

            using var conn = ObterConexao();

            using var professores = await conn.QueryMultipleAsync(query.ToString(), parametros);

            retorno.Items = professores.Read<ProfessorGoogle>();
            retorno.TotalRegistros = professores.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        public async Task<bool> ExisteProfessorPorRf(long rf)
        {
            var query = @"SELECT exists(SELECT 1 from usuarios where id = @rf and usuario_tipo = @usuarioTipo limit 1)";
            var parametros = new
            {
                rf,
                usuarioTipo = UsuarioTipo.Professor
            };
            using var conn = ObterConexao();
            return (await conn.QueryAsync<bool>(query, parametros)).FirstOrDefault();
        }

        public async Task<long> SalvarAsync(long? id, string cpf, string nome, string email, UsuarioTipo tipo, string organizationPath, DateTime dataInclusao, DateTime? dataAtualizacao, string googleClassroomId)
        {
            const string insertQuery = @"insert into public.usuarios
                                        (id, cpf, nome, email, usuario_tipo, organization_path, data_inclusao, data_atualizacao, google_classroom_id)
                                        values
                                        (@id, @cpf, @nome, @email, @tipo, @organizationPath, @dataInclusao, @dataAtualizacao, @googleClassroomId)
                                        RETURNING indice";

            var parametros = new
            {
                id,
                cpf,
                nome,
                email,
                tipo,
                organizationPath,
                dataInclusao,
                dataAtualizacao,
                googleClassroomId
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(insertQuery, parametros);
        }

        public async Task<IEnumerable<AlunoGoogle>> ObterAlunosPorCodigos(long[] CodigosAluno)
        {
            var query = @"SELECT
                                 u.indice,
                                 u.id as Codigo,
                                 u.usuario_tipo as usuariotipo,
                                 u.email,
                                 u.organization_path as organizationpath,
                                 u.data_inclusao as datainclusao,
                                 u.data_atualizacao as dataatualizacao,
                                 u.google_classroom_id as GoogleClassroomId
                            FROM usuarios u
                           WHERE usuario_tipo = @tipo
                             and id = any(@CodigosAluno)";

            var parametros = new
            {
                CodigosAluno,
                tipo = UsuarioTipo.Aluno
            };

            using var conn = ObterConexao();

            return await conn.QueryAsync<AlunoGoogle>(query, parametros);
        }

        public async Task<PaginacaoResultadoDto<AlunoGoogle>> ObterAlunosPaginadoPorCodigos(Paginacao paginacao, long[] codigosAluno)
        {
            var query = new StringBuilder(@"SELECT
                                                 u.indice,
                                                 u.nome,
                                                 u.id as Codigo,
                                                 u.usuario_tipo as usuariotipo,
                                                 u.email,
                                                 u.organization_path as organizationpath,
                                                 u.data_inclusao as datainclusao,
                                                 u.data_atualizacao as dataatualizacao,
                                                 u.google_classroom_id as GoogleClassroomId
                                            FROM usuarios u
                                            WHERE usuario_tipo = @tipo
                                            and id = any(@codigosAluno)");

            if (paginacao.QuantidadeRegistros > 0)
                query.AppendLine($" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY ;");

            query.AppendLine("SELECT count(*) from usuarios u WHERE usuario_tipo = @tipo and id = any(@codigosAluno)");

            var retorno = new PaginacaoResultadoDto<AlunoGoogle>();

            var parametros = new
            {
                paginacao.QuantidadeRegistrosIgnorados,
                paginacao.QuantidadeRegistros,
                codigosAluno,
                tipo = UsuarioTipo.Aluno
            };

            using var conn = ObterConexao();

            using var professores = await conn.QueryMultipleAsync(query.ToString(), parametros);

            retorno.Items = professores.Read<AlunoGoogle>();
            retorno.TotalRegistros = professores.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        public async Task<FuncionarioGoogle> ObterFuncionarioPorEmail(string email)
        {
            var query = @"SELECT
                                 u.indice,
                                 u.id as Rf,
                                 u.usuario_tipo as usuariotipo,
                                 u.email,
                                 u.organization_path as organizationpath,
                                 u.data_inclusao as datainclusao,
                                 u.data_atualizacao as dataatualizacao,
                                 u.google_classroom_id as GoogleClassroomId
                            FROM usuarios u
                           WHERE usuario_tipo = @tipo
                             and email = @email";

            var parametros = new
            {
                email,
                tipo = UsuarioTipo.Funcionario
            };

            using var conn = ObterConexao();
            return await conn.QueryFirstOrDefaultAsync<FuncionarioGoogle>(query, parametros);
        }

        public async Task<bool> ExisteFuncionarioIndiretoPorCpf(string cpf)
        {
            var query = @"SELECT exists(SELECT 1 from usuarios where cpf = @cpf and usuario_tipo = @usuarioTipo limit 1)";
            using var conn = ObterConexao();
            return (await conn.QueryAsync<bool>(query, new { cpf, usuarioTipo = UsuarioTipo.FuncionarioIndireto })).FirstOrDefault();
        }

        public async Task<PaginacaoResultadoDto<FuncionarioIndiretoGoogle>> ObterFuncionariosIndiretoAsync(Paginacao paginacao, string cpf, string email)
        {
            var query = new StringBuilder(@"SELECT
                                                   u.indice,
                                                   u.id AS Rf,
                                                   u.cpf AS Cpf,
                                                   u.nome AS Nome,
                                                   u.email AS Email,
                                                   u.organization_path as OrganizationPath,
                                                   u.data_inclusao as DataInclusao,
                                                   u.data_atualizacao as DataAtualizacao,
                                                   u.google_classroom_id as GoogleClassroomId
                                              FROM usuarios u
                                             WHERE usuario_tipo = @tipo ");
            var queryCount = new StringBuilder("SELECT count(*) from usuarios u where usuario_tipo = @tipo ");

            if (!string.IsNullOrWhiteSpace(cpf))
            {
                query.AppendLine($"AND u.cpf = @cpf");
                queryCount.AppendLine($"AND u.cpf = @cpf");
            }

            if (!string.IsNullOrEmpty(email))
            {
                query.AppendLine($"AND u.email = @email");
                queryCount.AppendLine($"AND u.email = @email");
            }

            if (paginacao.QuantidadeRegistros > 0)
                query.AppendLine($" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY ");

            query.AppendLine(";");

            query.AppendLine(queryCount.ToString());

            var retorno = new PaginacaoResultadoDto<FuncionarioIndiretoGoogle>();

            var parametros = new
            {
                paginacao.QuantidadeRegistrosIgnorados,
                paginacao.QuantidadeRegistros,
                tipo = UsuarioTipo.FuncionarioIndireto,
                cpf,
                email = email?.Trim().ToLower()
            };

            using var conn = ObterConexao();

            using var funcionarios = await conn.QueryMultipleAsync(query.ToString(), parametros);

            retorno.Items = funcionarios.Read<FuncionarioIndiretoGoogle>();
            retorno.TotalRegistros = funcionarios.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        public async Task<int> AtualizarAsync(long id, string nome, string organizationPath)
        {
            const string updateQuery = @"update public.usuarios
                                         set
                                            nome = @nome, organization_path = @organizationPath
                                         where
                                            indice = @id";

            var parametros = new
            {
                id,
                nome,
                organizationPath
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(updateQuery, parametros);
        }

        public async Task<int> AtualizarUsuarioGoogleClassroomIdAsync(long usuarioId, string googleClassroomId)
        {
            const string updateQuery = @"update public.usuarios
                                         set
                                            google_classroom_id = @googleClassroomId
                                         where
                                            indice = @usuarioId";

            var parametros = new
            {
                usuarioId,
                googleClassroomId
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(updateQuery, parametros);
        }

        public async Task<PaginacaoResultadoDto<UsuarioParaAtualizacaoGoogleClassroomIdDto>> ObterUsuariosSemGoogleClassroomIdPorTipoAsync(Paginacao paginacao)
        {
            const string query = @"
                SELECT
                    u.indice AS UsuarioId,
                    u.email
                FROM usuarios u
                WHERE u.google_classroom_id is null
                OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY;

                SELECT count(*) FROM usuarios u WHERE u.google_classroom_id is null;";

            var parametros = new
            {
                paginacao.QuantidadeRegistrosIgnorados,
                paginacao.QuantidadeRegistros
            };

            using var conn = ObterConexao();

            using var usuarios = await conn.QueryMultipleAsync(query, parametros);

            var retorno = new PaginacaoResultadoDto<UsuarioParaAtualizacaoGoogleClassroomIdDto>();
            retorno.Items = usuarios.Read<UsuarioParaAtualizacaoGoogleClassroomIdDto>();
            retorno.TotalRegistros = usuarios.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }
    }
}