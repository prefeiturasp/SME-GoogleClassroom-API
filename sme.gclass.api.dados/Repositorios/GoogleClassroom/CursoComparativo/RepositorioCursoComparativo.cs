using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCursoComparativo: RepositorioGoogle, IRepositorioCursoComparativo
    {
        public RepositorioCursoComparativo(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<long> SalvarAsync(CursoComparativo cursoComparativo)
        {
            const string insertQuery = @"insert into public.curso_comparativo
                                        (id, nome, secao, criador_id, descricao, data_inclusao, inserido_manualmente_google)
                                        values
                                        (@id, @nome, @secao, @criadorId, @descricao, @dataInclusao, @inserido_manualmente_google)
                                        RETURNING id";

            var parametros = new
            {
                id = cursoComparativo.Id,
                nome = cursoComparativo.Nome,
                secao = cursoComparativo.Secao,
                criadorId = cursoComparativo.CriadorId,
                descricao = cursoComparativo.Descricao,
                inseridoManualmenteGoogle = cursoComparativo.InseridoManualmenteGoogle,
                dataInclusao = cursoComparativo.DataInclusao
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(insertQuery, parametros);
        }

        public async Task<PaginacaoResultadoDto<CursoComparativoDto>> ObterCursosComparativosAsync(Paginacao paginacao, string secao)
        {
            var queryCompleta = new StringBuilder();

            queryCompleta.AppendLine(MontaQueryObterCursosComparativos(false, paginacao, secao));
            queryCompleta.AppendLine(MontaQueryObterCursosComparativos(true, paginacao, secao));

            var retorno = new PaginacaoResultadoDto<CursoComparativoDto>();

            using var conn = ObterConexao();

            var parametros = new
            {
                paginacao,
                secao
            };

            using var multi = await conn.QueryMultipleAsync(queryCompleta.ToString(), parametros);

            retorno.Items = multi.Read<CursoComparativoDto>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        private string MontaQueryObterCursosComparativos(bool ehParaPaginacao, Paginacao paginacao, string secao)
        {
            var queryCompleta = new StringBuilder("SELECT ");

            if (ehParaPaginacao)
                queryCompleta.AppendLine("count(*)");
            else
            {
                queryCompleta.AppendLine(@"CC.ID, 
                                  CC.NOME,
                                  CC.SECAO,
                                  C.CRIADOR_ID AS CRIADORID,
                                  C.DESCRICAO,
                                  C.DATA_INCLUSAO AS DATAINCLUSAO,
                                  C.INSERIDO_MANUALMENTE_GOOGLE AS INSERIDOMANUALMENTEGOOGLE");
            }

            queryCompleta.AppendLine(@"FROM CURSO_COMPARATIVO CC");
            queryCompleta.AppendLine(@"WHERE 1=1");

            if (!string.IsNullOrEmpty(secao))
                queryCompleta.AppendLine(@"AND C.secao like('%" + secao?.Trim().ToLower() + "%')");

            if (paginacao.QuantidadeRegistros > 0 && !ehParaPaginacao)
                queryCompleta.AppendLine($" OFFSET {paginacao.QuantidadeRegistrosIgnorados} ROWS FETCH NEXT {paginacao.QuantidadeRegistros} ROWS ONLY ; ");

            return queryCompleta.ToString();
        }
    }
}
