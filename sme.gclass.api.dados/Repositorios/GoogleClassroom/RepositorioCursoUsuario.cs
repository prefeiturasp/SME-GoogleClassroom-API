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
    public class RepositorioCursoUsuario : IRepositorioCursoUsuario
    {
        private readonly ConnectionStrings connectionStrings;

        public RepositorioCursoUsuario(ConnectionStrings connectionStrings)
        {
            this.connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
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

            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);
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

            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);
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

            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);
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
                query.AppendLine("and u.id = @rf");

            if (turmaId.HasValue && turmaId > 0)
                query.AppendLine("and c.turma_id = @turmaId");

            if (componenteCurricularId.HasValue && componenteCurricularId > 0)
                query.AppendLine("and c.componente_curricular_id = @componenteCurricularId");

            query.AppendLine(";");

            query.AppendLine("select * into temporary professorTempPaginado from professorTemp");

            if (paginacao.QuantidadeRegistros > 0)
                query.AppendLine($" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY;");

           

            query.AppendLine(@"select t1.rf,
   		                              t1.nome,
   		                              t1.email,
   	                                  c.id,
   		                              c.nome,
   		                              c.secao,
   		                              c.turma_id,
   		                              c.componente_curricular_id
                                 from cursos c
                                inner join cursos_usuarios cu on cu.curso_id = c.id
                                inner join professorTempPaginado t1 on t1.indice = cu.usuario_id;");


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

            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);

            var multiResult = await conn.QueryMultipleAsync(query.ToString(), parametros);

            var dic = new Dictionary<long, ProfessorCursosCadastradosDto>();

            var Result = multiResult.Read<ProfessorCursosCadastradosDto, CursoDto, ProfessorCursosCadastradosDto>(
                (professor, curso) =>
                {
                    
                    if(!dic.TryGetValue(professor.Rf, out var professorResultado))
                    {
                        professor.Cursos.Add(curso);
                        dic.Add(professor.Rf, professor);
                        return professor;
                    }

                    professorResultado.Cursos.Add(curso);

                    return professorResultado;
                }
                );

            retorno.Items = Result;
            retorno.TotalRegistros = multiResult.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }
    }
}
