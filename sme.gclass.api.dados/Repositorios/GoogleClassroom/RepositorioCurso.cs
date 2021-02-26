using Dapper;
using Npgsql;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCurso : IRepositorioCurso
    {
        private readonly ConnectionStrings ConnectionStrings;
        public RepositorioCurso(ConnectionStrings connectionStrings)
        {
            this.ConnectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }
        private string MontaQueryObterTodosOsCursos(bool ehParaPaginacao, Paginacao paginacao)
        {
            var queryCompleta = new StringBuilder("SELECT ");

            if (ehParaPaginacao)
                queryCompleta.AppendLine("count(*)");
            else
            {
                queryCompleta.AppendLine(@"C.ID, 
                                  C.NOME,
                                  C.SECAO,
                                  C.TURMA_ID AS TURMAID,
                                  C.COMPONENTE_CURRICULAR_ID AS COMPONENTECURRICULARID,
                                  C.DATA_INCLUSAO AS DATAINCLUSAO,
                                  C.DATA_ATUALIZACAO AS DATAATUALIZACAO,
                                  C.EMAIL ");
            }

            queryCompleta.AppendLine(@"FROM CURSOS C");

            if (paginacao.QuantidadeRegistros > 0 && !ehParaPaginacao)
                queryCompleta.AppendLine($" OFFSET {paginacao.QuantidadeRegistrosIgnorados} ROWS FETCH NEXT {paginacao.QuantidadeRegistros} ROWS ONLY ; ");

            return queryCompleta.ToString();
        }
        public async Task<PaginacaoResultadoDto<Curso>> ObterTodosCursosAsync(Paginacao paginacao)
        {
            var queryCompleta = new StringBuilder();

            queryCompleta.AppendLine(MontaQueryObterTodosOsCursos(false, paginacao));
            queryCompleta.AppendLine(MontaQueryObterTodosOsCursos(true, paginacao));

            var retorno = new PaginacaoResultadoDto<Curso>();

            using var conn = new NpgsqlConnection(ConnectionStrings.ConnectionStringGoogleClassroom);

            using var multi = await conn.QueryMultipleAsync(queryCompleta.ToString());

            retorno.Items = multi.Read<Curso>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }
    }
}
