using Dapper;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCursoUsuarioRemovidoGsa : RepositorioGoogle, IRepositorioCursoUsuarioRemovidoGsa
    {
        public RepositorioCursoUsuarioRemovidoGsa(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<PaginacaoResultadoDto<CursoUsuarioRemovidoConsultaDto>> ObterAlunosCursosRemovidosPorCursoId(Paginacao paginacao, string cursoId)
        {
            var query = new StringBuilder(@"SELECT
                                                   ucr.usuario_id UsuarioId,
                                                   ucr.curso_id CursoId,
                                                   ucr.removido_em RemovidoEm,
                                                   u.google_classroom_id UsuarioGsaId,
                                                   u.email EmailUsuario,
                                                   u.nome NomeUsuario,
                                                   c.nome NomeCurso
                                              FROM curso_usuario_removido_gsa ucr
                                              inner join cursos c on c.id = ucr.curso_id 
                                              inner join usuarios u on u.indice = ucr.usuario_id 
                                             WHERE ucr.usuario_tipo = @tipo ");

            var queryCount = new StringBuilder("SELECT count(*) from curso_usuario_removido_gsa ucr WHERE ucr.usuario_tipo = @tipo ");

            if (!string.IsNullOrEmpty(cursoId))
            {
                query.AppendLine("AND ucr.curso_id = @cursoId");
                queryCount.AppendLine("AND ucr.curso_id = @cursoId");
            }

            if (paginacao.QuantidadeRegistros > 0)
                query.AppendLine($" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY ");

            query.AppendLine(";");
            query.AppendLine(queryCount.ToString());

            var retorno = new PaginacaoResultadoDto<CursoUsuarioRemovidoConsultaDto>();

            var parametros = new
            {
                quantidadeRegistrosIgnorados = paginacao.QuantidadeRegistrosIgnorados,
                quantidadeRegistros = paginacao.QuantidadeRegistros,
                tipo = UsuarioTipo.Aluno,
                cursoId
            };

            using var conn = ObterConexao();

            using var registros = await conn.QueryMultipleAsync(query.ToString(), parametros);

            retorno.Items = registros.Read<CursoUsuarioRemovidoConsultaDto>();
            retorno.TotalRegistros = registros.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        public async Task<PaginacaoResultadoDto<CursoUsuarioRemovidoConsultaDto>> ObterProfessoresRemovidosCursosPorId(Paginacao paginacao, long cursoId)
        {
            try
            {
                var query = new StringBuilder(@"SELECT
                                                   ucr.usuario_id UsuarioId,
                                                   ucr.curso_id CursoId,
                                                   ucr.removido_em RemovidoEm,
                                                   u.google_classroom_id UsuarioGsaId,
                                                   u.email EmailUsuario,
                                                   u.nome NomeUsuario,
                                                   c.nome NomeCurso
                                              FROM curso_usuario_removido_gsa ucr
                                              inner join cursos c on c.id = ucr.curso_id 
                                              inner join usuarios u on u.indice = ucr.usuario_id 
                                             WHERE ucr.usuario_tipo = @tipo ");

                var queryCount = new StringBuilder("SELECT count(*) from curso_usuario_removido_gsa ucr WHERE ucr.usuario_tipo = @tipo ");

                if (cursoId > 0)
                {
                    query.AppendLine("AND ucr.curso_id = @cursoId");
                    queryCount.AppendLine("AND ucr.curso_id = @cursoId");
                }

                if (paginacao.QuantidadeRegistros > 0)
                    query.AppendLine($" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY ");

                query.AppendLine(";");
                query.AppendLine(queryCount.ToString());

                var retorno = new PaginacaoResultadoDto<CursoUsuarioRemovidoConsultaDto>();

                var parametros = new
                {
                    quantidadeRegistrosIgnorados = paginacao.QuantidadeRegistrosIgnorados,
                    quantidadeRegistros = paginacao.QuantidadeRegistros,
                    tipo = UsuarioTipo.Professor,
                    cursoId
                };

                using var conn = ObterConexao();

                using var registros = await conn.QueryMultipleAsync(query.ToString(), parametros);

                retorno.Items = registros.Read<CursoUsuarioRemovidoConsultaDto>();
                retorno.TotalRegistros = registros.ReadFirst<int>();
                retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<long> SalvarAsync(CursoUsuarioRemovidoGsa entidade)
        {
            var query = @"INSERT INTO public.curso_usuario_removido_gsa
                           (curso_id, usuario_id, removido_em, usuario_tipo)
                         VALUES
                           (@cursoId, @usuarioId, @removidoEm, @usuarioTipo)
                         RETURNING id";

            var parametros = new
            {
                entidade.CursoId,
                entidade.UsuarioId,
                entidade.RemovidoEm,
                entidade.UsuarioTipo
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(query, parametros);
        }

        public async Task LimparAsync()
        {
            const string query = @"DELETE FROM curso_usuario_removido_gsa";
            using var conn = ObterConexao();
            await conn.ExecuteAsync(query);
        }

        
    }
}