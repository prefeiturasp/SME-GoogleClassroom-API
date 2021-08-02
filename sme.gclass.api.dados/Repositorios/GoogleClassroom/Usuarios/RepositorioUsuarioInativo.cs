using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuarioInativo : RepositorioGoogle, IRepositorioUsuarioInativo
    {
        public RepositorioUsuarioInativo(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<bool> InativarUsuarioAsync(long usuarioId, UsuarioTipo tipo, DateTime inativadoEm)
        {
            try
            {
                const string insertQuery = @"insert into public.usuario_inativo 
                                        (usuario_id, usuario_tipo, inativado_em)
                                        values (@usuarioId, @tipo, @inativadoEm) ";

                var parametros = new
                {
                    usuarioId,
                    tipo,
                    inativadoEm
                };

                using var conn = ObterConexao();
                await conn.ExecuteAsync(insertQuery, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public async Task LimparAsync()
        {
            const string query = @"DELETE FROM usuario_inativo";
            using var conn = ObterConexao();
            await conn.ExecuteAsync(query);
        }

        public async Task<PaginacaoResultadoDto<UsuarioInativo>> ObterUsuariosInativosPorTipo(Paginacao paginacao, UsuarioTipo[] tiposDeUsuarios = null)
        {
            try
            {
                var tiposDeUsuariosPadroes = new UsuarioTipo[] { 
                    UsuarioTipo.Aluno, 
                    UsuarioTipo.Funcionario, 
                    UsuarioTipo.FuncionarioIndireto, 
                    UsuarioTipo.Professor 
                };

                var tiposDeUsuarioParametro = tiposDeUsuarios == null ? tiposDeUsuariosPadroes : tiposDeUsuarios;

                var query = new StringBuilder(@"SELECT
                                                   ui.id as Id, 
                                                   ui.usuario_id UsuarioId,
                                                   ui.usuario_tipo UsuarioTipo,
                                                   ui.inativado_em InativadoEm 
                                              FROM usuario_inativo ui 
                                              WHERE ui.usuario_tipo = ANY(@tiposDeUsuarioParametro)");

                var queryCount = new StringBuilder("SELECT count(*) from usuario_inativo ui  WHERE ui.usuario_tipo = ANY(@tiposDeUsuarioParametro)");

                if (paginacao.QuantidadeRegistros > 0)
                    query.AppendLine($" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY ");

                query.AppendLine(";");
                query.AppendLine(queryCount.ToString());

                var retorno = new PaginacaoResultadoDto<UsuarioInativo>();
                
                var parametros = new
                {
                    paginacao.QuantidadeRegistrosIgnorados,
                    paginacao.QuantidadeRegistros,
                    tiposDeUsuarioParametro = Array.ConvertAll(tiposDeUsuarioParametro, value => (short)value)
                };

                using var conn = ObterConexao();

                using var registros = await conn.QueryMultipleAsync(query.ToString(), parametros);

                retorno.Items = registros.Read<UsuarioInativo>();
                retorno.TotalRegistros = registros.ReadFirst<int>();
                retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
