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
    public class RepositorioCursoUsuario : RepositorioGoogle, IRepositorioCursoUsuario
    {
        public RepositorioCursoUsuario(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<bool> ExisteProfessorCurso(long usuarioId, long cursoId)
        {
            var query = @"SELECT exists(select 1
                           from cursos_usuarios
                          where usuario_id = @usuarioId
                            and curso_id = @cursoId
                            and not excluido limit 1)";

            var parametros = new
            {
                usuarioId,
                cursoId
            };

            using var conn = ObterConexao();
            return (await conn.QueryAsync<bool>(query, parametros)).FirstOrDefault();
        }

        public async Task<bool> ExisteAlunoCurso(long usuarioId, long cursoId)
        {
            var query = @"SELECT exists(select 1
                           from cursos_usuarios
                          where usuario_id = @usuarioId
                            and curso_id = @cursoId
                            and not excluido limit 1)";

            var parametros = new
            {
                usuarioId,
                cursoId
            };

            using var conn = ObterConexao();
            return (await conn.QueryAsync<bool>(query, parametros)).FirstOrDefault();
        }

        public async Task<long> SalvarAsync(CursoUsuario cursoUsuario)
        {
            var query = @"INSERT INTO public.cursos_usuarios
                           (curso_id, usuario_id, data_inclusao, excluido)
                         VALUES
                           (@cursoId, @usuarioId, @dataInclusao, @excluido)
                         RETURNING id";

            var parametros = new
            {
                cursoUsuario.CursoId,
                cursoUsuario.UsuarioId,
                cursoUsuario.DataInclusao,
                cursoUsuario.Excluido
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(query, parametros);
        }

        public async Task<PaginacaoResultadoDto<ProfessorCursosCadastradosDto>> ObterProfessoresCursosAsync(Paginacao paginacao, long? rf, long? turmaId, long? componenteCurricularId)
        {
            try
            {
                var query = new StringBuilder(@"DROP TABLE IF EXISTS professorTemp;
                                            DROP TABLE IF EXISTS professorTempPaginado;
                                            select distinct
                                                   u.indice,
                                                   u.google_classroom_id AS googleclassroomid,
                                                   u.id AS rf,
                                                   u.nome AS nome,
                                                   u.email AS email
                                              into temporary table professorTemp
                                              from usuarios u
                                             inner join cursos_usuarios cu on cu.usuario_id = u.indice
                                             inner join cursos c on c.id = cu.curso_id
                                             where u.usuario_tipo = @tipo
                                               and not cu.excluido");
                if (rf.HasValue && rf > 0)
                    query.AppendLine(" and u.id = @rf");

                if (turmaId.HasValue && turmaId > 0)
                    query.AppendLine(" and c.turma_id = @turmaId");

                if (componenteCurricularId.HasValue && componenteCurricularId > 0)
                    query.AppendLine(" and c.componente_curricular_id = @componenteCurricularId");

                query.AppendLine(";");

                query.AppendLine(" select * into temporary professorTempPaginado from professorTemp");

                if (paginacao.QuantidadeRegistros > 0)
                    query.AppendLine($" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY;");

                query.AppendLine(@"select t1.rf,
                                      cu.Id as CursoUsuarioId,
                                      t1.indice,
   		                              t1.nome,
   		                              t1.email,
                                      t1.googleclassroomid,
                                      c.id,
   	                                  c.id as CursoId,
   		                              c.nome,
                                      c.email,
   		                              c.secao,
   		                              c.turma_id as TurmaId,
   		                              c.componente_curricular_id as ComponenteCurricularId
                                 from cursos c
                                inner join cursos_usuarios cu on cu.curso_id = c.id
                                inner join professorTempPaginado t1 on t1.indice = cu.usuario_id ");

                if (rf.HasValue && rf > 0)
                    query.AppendLine(" and t1.rf = @rf");

                if (turmaId.HasValue && turmaId > 0)
                    query.AppendLine(" and c.turma_id = @turmaId");

                if (componenteCurricularId.HasValue && componenteCurricularId > 0)
                    query.AppendLine(" and c.componente_curricular_id = @componenteCurricularId");

                query.AppendLine(";");

                query.AppendLine("select count(*) from professorTemp");

                var retorno = new PaginacaoResultadoDto<ProfessorCursosCadastradosDto>();

                var parametros = new
                {
                    paginacao.QuantidadeRegistrosIgnorados,
                    paginacao.QuantidadeRegistros,
                    tipo = UsuarioTipo.Professor,
                    rf,
                    turmaId,
                    componenteCurricularId
                };

                using var conn = ObterConexao();

                var multiResult = await conn.QueryMultipleAsync(query.ToString(), parametros);

                var dic = new Dictionary<long, ProfessorCursosCadastradosDto>();

                var Result = multiResult.Read<ProfessorCursosCadastradosDto, CursoDto, ProfessorCursosCadastradosDto>(
                    (professor, curso) =>
                    {
                        if (!dic.TryGetValue(professor.Rf, out var professorResultado))
                        {
                            professor.Cursos.Add(curso);
                            dic.Add(professor.Rf, professor);
                            return professor;
                        }

                        professorResultado.Cursos.Add(curso);

                        return professorResultado;
                    }
                    );

                retorno.Items = dic.Values;
                retorno.TotalRegistros = multiResult.ReadFirst<int>();
                retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

                return retorno;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PaginacaoResultadoDto<AlunoCursosCadastradosDto>> ObterAlunosCursosAsync(Paginacao paginacao, long? codigoAluno, long? turmaId, long? componenteCurricularId)
        {
            var query = new StringBuilder(@"DROP TABLE IF EXISTS alunoTemp;
                                            DROP TABLE IF EXISTS alunoTempPaginado;
                                            select distinct
                                                   u.indice,
                                                   u.id AS codigoAluno,
                                                   u.nome AS nome,
                                                   u.email AS email
                                              into temporary table alunoTemp
                                              from usuarios u
                                             inner join cursos_usuarios cu on cu.usuario_id = u.indice
                                             inner join cursos c on c.id = cu.curso_id
                                             where u.usuario_tipo = @tipo
                                               and not cu.excluido ");
            if (codigoAluno.HasValue && codigoAluno > 0)
                query.AppendLine("and u.id = @codigoAluno ");

            if (turmaId.HasValue && turmaId > 0)
                query.AppendLine("and c.turma_id = @turmaId ");

            if (componenteCurricularId.HasValue && componenteCurricularId > 0)
                query.AppendLine("and c.componente_curricular_id = @componenteCurricularId ");

            query.AppendLine(";");

            query.AppendLine("select * into temporary alunoTempPaginado from alunoTemp");

            if (paginacao.QuantidadeRegistros > 0)
                query.AppendLine($" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY;");

            query.AppendLine(@"select t1.codigoAluno,
   		                              t1.nome,
   		                              t1.email,
   	                                  c.id,
                                      c.id as cursoId,
   		                              c.nome,
   		                              c.secao,
   		                              c.turma_id as turmaId,
   		                              c.componente_curricular_id as componenteCurricularId
                                 from cursos c
                                inner join cursos_usuarios cu on cu.curso_id = c.id
                                inner join alunoTempPaginado t1 on t1.indice = cu.usuario_id ");

            if (codigoAluno.HasValue && codigoAluno > 0)
                query.AppendLine("and t1.codigoAluno = @codigoAluno ");

            if (turmaId.HasValue && turmaId > 0)
                query.AppendLine("and c.turma_id = @turmaId ");

            if (componenteCurricularId.HasValue && componenteCurricularId > 0)
                query.AppendLine("and c.componente_curricular_id = @componenteCurricularId ");

            query.AppendLine(";");

            query.AppendLine("select count(*) from alunoTemp");

            var retorno = new PaginacaoResultadoDto<AlunoCursosCadastradosDto>();

            var parametros = new
            {
                paginacao.QuantidadeRegistrosIgnorados,
                paginacao.QuantidadeRegistros,
                tipo = UsuarioTipo.Aluno,
                codigoAluno,
                turmaId,
                componenteCurricularId
            };

            using var conn = ObterConexao();

            var multiResult = await conn.QueryMultipleAsync(query.ToString(), parametros);

            var dic = new Dictionary<long, AlunoCursosCadastradosDto>();

            multiResult.Read<AlunoCursosCadastradosDto, CursoDto, AlunoCursosCadastradosDto>(
                (aluno, curso) =>
                {
                    if (!dic.TryGetValue(aluno.CodigoAluno, out var alunoResultado))
                    {
                        aluno.Cursos.Add(curso);
                        dic.Add(aluno.CodigoAluno, aluno);
                        return aluno;
                    }

                    alunoResultado.Cursos.Add(curso);

                    return alunoResultado;
                }
                );

            retorno.Items = dic.Values;
            retorno.TotalRegistros = multiResult.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        public async Task<bool> ExisteFuncionarioCurso(long usuarioId, long cursoId)
        {
            var query = @"SELECT exists(select 1
                           from cursos_usuarios
                          where usuario_id = @usuarioId
                            and curso_id = @cursoId
                            and not excluido limit 1)";

            var parametros = new
            {
                usuarioId,
                cursoId
            };

            using var conn = ObterConexao();
            return (await conn.QueryAsync<bool>(query, parametros)).FirstOrDefault();
        }

        public async Task<PaginacaoResultadoDto<FuncionarioCursosCadastradosDto>> ObterFuncionariosCursosAsync(Paginacao paginacao, long? rf, long? turmaId, long? componenteCurricularId)
        {
            var query = new StringBuilder(@"DROP TABLE IF EXISTS funcionarioTemp;
                                            DROP TABLE IF EXISTS funcionarioTempPaginado;
                                            select distinct
                                                   u.indice,
                                                   u.id AS rf,
                                                   u.nome AS nome,
                                                   u.email AS email,
                                                   u.organization_path AS organizationPath
                                              into temporary table funcionarioTemp
                                              from usuarios u
                                             inner join cursos_usuarios cu on cu.usuario_id = u.indice
                                             inner join cursos c on c.id = cu.curso_id
                                             where u.usuario_tipo = @tipo
                                               and not cu.excluido");
            if (rf.HasValue && rf > 0)
                query.AppendLine(" and u.id = @rf");

            if (turmaId.HasValue && turmaId > 0)
                query.AppendLine(" and c.turma_id = @turmaId");

            if (componenteCurricularId.HasValue && componenteCurricularId > 0)
                query.AppendLine(" and c.componente_curricular_id = @componenteCurricularId");

            query.AppendLine(";");

            query.AppendLine(" select * into temporary funcionarioTempPaginado from funcionarioTemp");

            if (paginacao.QuantidadeRegistros > 0)
                query.AppendLine($" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY;");

            query.AppendLine(@"select t1.rf,
   		                              t1.nome,
   		                              t1.email,
                                      t1.organizationPath,
   	                                  c.id,
                                      c.id as cursoId,
   		                              c.nome,
   		                              c.secao,
   		                              c.turma_id as turmaId,
   		                              c.componente_curricular_id as componenteCurricularId
                                 from cursos c
                                inner join cursos_usuarios cu on cu.curso_id = c.id
                                inner join funcionarioTempPaginado t1 on t1.indice = cu.usuario_id");

            if (rf.HasValue && rf > 0)
                query.AppendLine(" and t1.rf = @rf");

            if (turmaId.HasValue && turmaId > 0)
                query.AppendLine(" and c.turma_id = @turmaId");

            if (componenteCurricularId.HasValue && componenteCurricularId > 0)
                query.AppendLine(" and c.componente_curricular_id = @componenteCurricularId");

            query.AppendLine(";");

            query.AppendLine("select count(*) from funcionarioTemp");

            var retorno = new PaginacaoResultadoDto<FuncionarioCursosCadastradosDto>();

            var parametros = new
            {
                paginacao.QuantidadeRegistrosIgnorados,
                paginacao.QuantidadeRegistros,
                tipo = UsuarioTipo.Funcionario,
                rf,
                turmaId,
                componenteCurricularId
            };

            using var conn = ObterConexao();

            var multiResult = await conn.QueryMultipleAsync(query.ToString(), parametros);

            var dic = new Dictionary<long, FuncionarioCursosCadastradosDto>();

            var Result = multiResult.Read<FuncionarioCursosCadastradosDto, CursoDto, FuncionarioCursosCadastradosDto>(
                (funcionario, curso) =>
                {
                    if (!dic.TryGetValue(funcionario.Rf, out var funcionarioResultado))
                    {
                        funcionario.Cursos.Add(curso);
                        dic.Add(funcionario.Rf, funcionario);
                        return funcionario;
                    }

                    funcionarioResultado.Cursos.Add(curso);

                    return funcionarioResultado;
                }
                );

            retorno.Items = dic.Values;
            retorno.TotalRegistros = multiResult.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        public async Task<int> RemoverAsync(long id)
        {
            try
            {
                const string query = "UPDATE public.cursos_usuarios SET excluido = true WHERE id = @id";
                var parametros = new
                {
                    id
                };

                using var conn = ObterConexao();
                return await conn.ExecuteAsync(query, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CursoUsuario> ObterPorUsuarioIdCursoIdAsync(long usuarioId, long cursoId)
        {
            const string query = @"
                SELECT
                    id, 
                    curso_id as CursoId,
                    usuario_id as UsuarioId,
                    data_inclusao as DatInclusao,
                    data_atualizacao as DataAtualizacao,
                    excluido
                FROM
                    public.cursos_usuarios c
                WHERE
                    c.usuario_id = @usuarioId
                    and c.curso_id = @cursoId
                    and not excluido";

            var parametros = new
            {
                usuarioId,
                cursoId
            };

            using var conn = ObterConexao();
            return await conn.QuerySingleOrDefaultAsync<CursoUsuario>(query, parametros);
        }

        public async Task<(IEnumerable<CursoUsuarioDto>, int? totalPaginas)> ObterCursosComResponsaveisPorAno(int anoLetivo, long? cursoId, int? pagina = null, int? quantidadeRegistrosPagina = null)
        {
            var sqlQuery = new StringBuilder();
            sqlQuery.AppendLine("drop table if exists tmp_cursos_usuarios;");
            sqlQuery.AppendLine("create temporary table tmp_cursos_usuarios as");
            sqlQuery.AppendLine("select c.id as CursoId,");
            sqlQuery.AppendLine("       u.google_classroom_id as UsuarioId,");
            sqlQuery.AppendLine("       dense_rank() over (order by c.id) pagina");
            sqlQuery.AppendLine("from cursos c");
            sqlQuery.AppendLine("   inner join cursos_usuarios cu");
            sqlQuery.AppendLine("      on cu.curso_id = c.id");
            sqlQuery.AppendLine("   inner join usuarios u");
            sqlQuery.AppendLine("      on u.indice = cu.usuario_id");
            sqlQuery.AppendLine("where extract(year from c.data_inclusao) = @anoLetivo and");
            sqlQuery.AppendLine($"     u.usuario_tipo <> 1{(cursoId.HasValue ? string.Empty : ";")}");

            if (cursoId.HasValue)
                sqlQuery.AppendLine("and c.id = @cursoId;");

            var paginacao = pagina.HasValue && quantidadeRegistrosPagina.HasValue;

            sqlQuery.AppendLine("select CursoId,");
            sqlQuery.AppendLine("       UsuarioId");
            sqlQuery.AppendLine($"from tmp_cursos_usuarios{(paginacao ? string.Empty : ";")}");

            if (paginacao)
                sqlQuery.AppendLine("where pagina between ((@pagina * @quantidadeRegistrosPagina) - (@quantidadeRegistrosPagina - 1)) and (@pagina * @quantidadeRegistrosPagina);");

            if (pagina.HasValue && pagina.Value.Equals(1))
            {
                sqlQuery.AppendLine("select case when max(pagina) / @quantidadeRegistrosPagina = 0 then 1 else max(pagina) / @quantidadeRegistrosPagina end");
                sqlQuery.AppendLine("   from tmp_cursos_usuarios;");
            }

            using (var conn = ObterConexao())
            {
                var retorno = await conn.QueryMultipleAsync(sqlQuery.ToString(), new
                {
                    anoLetivo,
                    cursoId,
                    usuarioTipo = (int)UsuarioCursoGsaTipo.Estudante,
                    pagina,
                    quantidadeRegistrosPagina
                });

                var lista = retorno.Read<CursoUsuarioDto>();
                var totalPaginas = pagina.HasValue && pagina.Value.Equals(1) ? retorno.ReadFirst<int>() : (int?)null;

                return (lista, totalPaginas);
            }
        }

        public async Task<IEnumerable<UsuarioGoogleDto>> ObterFuncionariosPorCursoId(long cursoId)
        {
            try
            {
                var query = @"
		                    select 
		                        u.id,
		                        u.indice,
			                    u.nome,
		                        u.email,
		                        u.organization_path as organizationPath,
		                        u.google_classroom_id as GoogleClassroomId,
		                        u.existe_google as ExisteGoogle
		                    from cursos_usuarios cu
		                    inner join usuarios u on u.indice = cu.usuario_id
		                    where cu.curso_id = @cursoId
		                     and u.usuario_tipo <> 1
		                     and not cu.excluido";

                using var conn = ObterConexao();
                return await conn.QueryAsync<UsuarioGoogleDto>(query, new { cursoId });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<CursoUsuarioInativarDto>> ObterUsuariosPorIdETurmaId(long usuarioId, long turmaId)
        {
            const string query = @"
                SELECT
                    cu.id as CursoUsuarioId,
                    curso_id as CursoId,
                    usuario_id as UsuarioId,
                    curso_id as CursoGsaId,
                    u.google_classroom_id as UsuarioGsaId
                FROM cursos_usuarios cu
               inner join usuarios u on u.indice = cu.usuario_id 
               inner join cursos c on c.id = cu.curso_id 
               where c.turma_id = @turmaId
                 and u.id = @usuarioId
                 and not excluido";

            var parametros = new
            {
                usuarioId,
                turmaId
            };

            using var conn = ObterConexao();
            return await conn.QueryAsync<CursoUsuarioInativarDto>(query, parametros);

        }

        public async Task<bool> UsuarioEhDonoCurso(long usuarioId, string email)
        {
            const string query = @"SELECT exists(select 1  
                                from cursos_usuarios cu 
                                inner join cursos c on c.id = cu.curso_id 
                                inner join usuarios u on u.indice = cu.usuario_id 
                                where usuario_id = @usuarioId 
                                and c.email = @email
                                and not cu.excluido limit 1) ";

            var parametros = new
            {
                usuarioId,
                email
            };

            using var conn = ObterConexao();
            return (await conn.QueryAsync<bool>(query, parametros)).FirstOrDefault();
        }

        public Task<IEnumerable<CursoUsuarioRemoverDto>> ObterPorUsuarioIdETurmaId(long usuarioId, long turmaId)
        {
            throw new NotImplementedException();
        }
    }
}