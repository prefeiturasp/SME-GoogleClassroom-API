using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
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
            return true;
        }

        public async Task LimparAsync()
        {
            const string query = @"DELETE FROM usuario_inativo";
            using var conn = ObterConexao();
            await conn.ExecuteAsync(query);
        }

        public async Task<PaginacaoResultadoDto<UsuarioInativoDto>> ObterUsuariosInativosPorTipo(Paginacao paginacao, UsuarioTipo usuarioTipo)
        {
            var query = new StringBuilder(@"SELECT
                                               ui.id as Id, 
                                               ui.usuario_id UsuarioId,
                                               ui.usuario_tipo UsuarioTipo,
                                               ui.inativado_em InativadoEm,
                                               u.nome,
                                               u.email,
                                               u.organization_path as UnidadeOrganizacional,
                                               u.google_classroom_id as GoogleClassroomId 
                                          FROM usuario_inativo ui 
                                          inner join usuarios u on u.indice = ui.usuario_id  
                                          WHERE ui.usuario_tipo = @usuarioTipo ");

            var queryCount = new StringBuilder("SELECT count(*) from usuario_inativo ui WHERE ui.usuario_tipo = @usuarioTipo ");

            if (paginacao.QuantidadeRegistros > 0)
                query.AppendLine($" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY ");

            query.AppendLine(";");
            query.AppendLine(queryCount.ToString());

            var retorno = new PaginacaoResultadoDto<UsuarioInativoDto>();

            var parametros = new
            {
                paginacao.QuantidadeRegistrosIgnorados,
                paginacao.QuantidadeRegistros,
                usuarioTipo
            };

            using var conn = ObterConexao();

            using var registros = await conn.QueryMultipleAsync(query.ToString(), parametros);

            retorno.Items = registros.Read<UsuarioInativoDto>();
            retorno.TotalRegistros = registros.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }
    }
}