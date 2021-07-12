using System;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioAtividade : RepositorioGoogle, IRepositorioAtividade
    {
        public RepositorioAtividade(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
        }


        public async Task<PaginacaoResultadoDto<AtividadeGsa>> ObterAtividadesPorData(Paginacao paginacao,
            DateTime dataReferencia, long? cursoId)
        {
            var queryCompleta = new StringBuilder();

            queryCompleta.AppendLine(MontaQueryObterAvisosPorData(false, paginacao, cursoId));
            queryCompleta.AppendLine(MontaQueryObterAvisosPorData(true, paginacao, cursoId));

            var retorno = new PaginacaoResultadoDto<AtividadeGsa>();

            using var conn = ObterConexao();

            var parametros = new
            {
                dataReferencia,
                cursoId
            };

            using var multi = await conn.QueryMultipleAsync(queryCompleta.ToString(), parametros);
            retorno.Items = multi.Read<AtividadeGsa>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = retorno.TotalRegistros > 0 ? (int) Math.Ceiling((double) retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 0;

            return retorno;
        }


        private string MontaQueryObterAvisosPorData(bool ehParaPaginacao, Paginacao paginacao, long? cursoId)
        {
            var queryCompleta = new StringBuilder("SELECT ");

            if (ehParaPaginacao)
                queryCompleta.AppendLine("count(*)");
            else
            {
                queryCompleta.AppendLine(@" A.id AS Id, 
                                            A.titulo AS Titulo, 
                                            A.descricao AS Descricao,  
                                            A.usuario_id AS UsuarioId,
                                            A.curso_id AS CursoId,
                                            A.data_inclusao AS DataInclusao, 
                                            A.data_alteracao AS DataAlteracao ");
            }

            queryCompleta.AppendLine("FROM atividades A ");
            queryCompleta.AppendLine("INNER JOIN CURSOS U ON U.Id = A.CURSO_ID ");
            queryCompleta.AppendLine("WHERE A.DATA_INCLUSAO = @dataReferencia;");


            if (cursoId.HasValue)
                queryCompleta.AppendLine(@"AND A.ID = @cursoId");

            if (paginacao.QuantidadeRegistros > 0)
                queryCompleta.AppendLine(
                    $" OFFSET {paginacao.QuantidadeRegistrosIgnorados} ROWS FETCH NEXT {paginacao.QuantidadeRegistros} ROWS ONLY ; ");

            return queryCompleta.ToString();
        }
    }
}