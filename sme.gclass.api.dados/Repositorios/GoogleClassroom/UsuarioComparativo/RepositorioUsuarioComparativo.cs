using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuarioComparativo : RepositorioGoogle, IRepositorioUsuarioComparativo
    {
        public RepositorioUsuarioComparativo(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }
        public async Task<PaginacaoResultadoDto<UsuarioComparativo>> ObterUsuariosComparativosAsync(Paginacao paginacao, string nome, string email, string organizationPath)
        {
            var queryCompleta = new StringBuilder();

            queryCompleta.AppendLine(MontaQueryObterUsuariosComparativos(false, paginacao, nome, email, organizationPath));
            queryCompleta.AppendLine(MontaQueryObterUsuariosComparativos(false, paginacao, nome, email, organizationPath));

            var retorno = new PaginacaoResultadoDto<UsuarioComparativo>();

            using var conn = ObterConexao();

            var parametros = new
            {
                paginacao,
                nome,
                email,
                organizationPath
            };

            using var multi = await conn.QueryMultipleAsync(queryCompleta.ToString(), parametros);

            retorno.Items = multi.Read<UsuarioComparativo>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        private string MontaQueryObterUsuariosComparativos(bool ehParaPaginacao, Paginacao paginacao, string nome, string email, string organizationPath)
        {
            var queryCompleta = new StringBuilder("SELECT ");

            if (ehParaPaginacao)
                queryCompleta.AppendLine("count(*)");
            else
            {
                queryCompleta.AppendLine(@"UC.ID, 
                                  UC.NOME,
                                  UC.SECAO,
                                  UC.CRIADOR_ID AS CRIADORID,
                                  UC.DESCRICAO,
                                  UC.DATA_INCLUSAO AS DATAINCLUSAO,
                                  UC.INSERIDO_MANUALMENTE_GOOGLE AS INSERIDOMANUALMENTEGOOGLE");
            }

            queryCompleta.AppendLine(@"FROM USUARIO_COMPARATIVO UC");
            queryCompleta.AppendLine(@"WHERE 1=1");

            if (!string.IsNullOrEmpty(nome))
                queryCompleta.AppendLine(@"AND UC.nome like('%" + nome?.Trim().ToLower() + "%')");

            if (!string.IsNullOrEmpty(nome))
                queryCompleta.AppendLine(@"AND UC.email like('%" + email?.Trim().ToLower() + "%')");
            if (!string.IsNullOrEmpty(nome))
                queryCompleta.AppendLine(@"AND UC.organization_path like('%" + organizationPath?.Trim().ToLower() + "%')");

            if (paginacao.QuantidadeRegistros > 0 && !ehParaPaginacao)
                queryCompleta.AppendLine($" OFFSET {paginacao.QuantidadeRegistrosIgnorados} ROWS FETCH NEXT {paginacao.QuantidadeRegistros} ROWS ONLY ; ");

            return queryCompleta.ToString();
        }
    }
}
