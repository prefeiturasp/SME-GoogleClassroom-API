using Dapper;
using Npgsql;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
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
        public async Task<PaginacaoResultadoDto<UsuarioDto>> ObterUsuarios(UsuarioTipo usuarioTipo, Paginacao paginacao)
        {
            try
            {

            
            var query = @" select id,
	                               usuario_tipo as UsuarioTipo,
	                               email,
	                               organization_path as OrganizationPath,
	                               data_inclusao as DataInclusao,
	                               data_atualizacao as DataAtualizacao
                              from usuarios 
                             where usuario_tipo = @usuarioTipo
                             limit 1";

            using var conn = new NpgsqlConnection(connectionStrings.ConnectionStringGoogleClassroom);
            using var multi = await conn.QueryMultipleAsync(query,
                new
                {
                    usuarioTipo = (int)usuarioTipo,
                    paginacao.QuantidadeRegistros,
                    paginacao.QuantidadeRegistrosIgnorados
                });
            var retorno = new PaginacaoResultadoDto<UsuarioDto>();

            retorno.Items = multi.Read<UsuarioDto>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
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
