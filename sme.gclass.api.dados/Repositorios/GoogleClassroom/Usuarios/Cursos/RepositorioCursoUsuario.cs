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
            var query = new StringBuilder(@"DROP TABLE IF EXISTS professorTemp;
                                            DROP TABLE IF EXISTS professorTempPaginado;
                                            select distinct
                                                   u.indice,
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
   		                              t1.nome,
   		                              t1.email,
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
            const string query = "DELETE FROM public.cursos_usuarios WHERE id = @id";
            var parametros = new
            {
                id
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(query, parametros);
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

        public async Task<IEnumerable<CursoUsuarioDto>> ObterCursosComResponsaveisPorAno(int anoLetivo, long? cursoId)
        {
            var query = @"select c.id as CursoId
	                    , u.google_classroom_id as UsuarioId
                      from cursos c
                     inner join cursos_usuarios cu on cu.curso_id = c.id
                     inner join usuarios u on u.indice = cu.usuario_id and u.usuario_tipo <> 1
                     where extract(year from c.data_inclusao) = @anoLetivo ";

            if (cursoId.HasValue)
                query += "and c.id = @cursoId ";

            using var conn = ObterConexao();
                return await conn.QueryAsync<CursoUsuarioDto>(query, new { anoLetivo, cursoId });
        }

        public async Task<IEnumerable<UsuarioGoogle>> ObterFuncionariosPorCursoId(long cursoId)
        {
            var query = @"
                    select 
                        u.id,
                        u.indice,
	                    u.nome,
                        u.email,
                        u.organization_path as organizationPath,
                        u.google_classroom_id as GoogleClassroomId,
                        u.existe_google as GoogleClassroomId
                    from cursos_usuarios cu
                    inner join usuarios u on u.indice = cu.usuario_id
                    where cu.curso_id = @cursoId
                    and u.usuario_tipo <> 1
                    and not cu.excluido";

            using var conn = ObterConexao();
            return await conn.QueryAsync<UsuarioGoogle>(query, new { cursoId });
        }

    }
}