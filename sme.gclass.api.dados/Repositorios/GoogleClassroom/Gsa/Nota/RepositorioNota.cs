using Dapper;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioNota : RepositorioGoogle, IRepositorioNota
    {
        public RepositorioNota(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
        }

        public async Task<long> AlterarNota(NotaGsa notaGsa)
        {
            const string updateQuery = @"update public.notas
                                            set atividade_id = @atividadeId
                                              , usuario_id = @usuarioId
                                              , nota = @nota
                                              , status = @status
                                              , data_importacao = @dataImportacao
                                              , data_inclusao = @dataInclusao
                                              , data_alteracao = @dataAlteracao
                                        where id = @id";

            var parametros = new
            {
                id = notaGsa.Id,
                atividadeId = notaGsa.AtividadeId,
                usuarioId = notaGsa.UsuarioId,
                nota = notaGsa.Nota,
                status = (int)notaGsa.Status,
                dataImportacao = notaGsa.DataImportacao,
                dataInclusao = notaGsa.DataInclusao,
                dataAlteracao = notaGsa.DataAlteracao,
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(updateQuery, parametros);
        }

        public async Task<long> InserirNota(NotaGsa notaGsa)
        {
            const string insertQuery = @"insert into public.notas
                                        (id, atividade_id, usuario_id, nota, status, data_importacao, data_inclusao, data_alteracao)
                                        values
                                        (@id, @atividadeId, @usuarioId, @nota, @status, @dataImportacao, @dataInclusao, @dataAlteracao)";

            var parametros = new
            {
                id = notaGsa.Id,
                atividadeId = notaGsa.AtividadeId,
                usuarioId = notaGsa.UsuarioId,
                nota = notaGsa.Nota,
                status = (int)notaGsa.Status,
                dataImportacao = notaGsa.DataImportacao,
                dataInclusao = notaGsa.DataInclusao,
                dataAlteracao = notaGsa.DataAlteracao,
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(insertQuery, parametros);
        }

        public async Task<bool> RegistroExiste(string id)
        {
            using var conn = ObterConexao();
            return await conn.QueryFirstOrDefaultAsync<bool>("select 1 from notas where id = @id", new { id });
        }


        public async Task<PaginacaoResultadoDto<NotasAtividadesDto>> ObterNotasAtividadesPorData(Paginacao paginacao, DateTime dataReferencia, long? atividadeId)
        {
            var queryCompleta = new StringBuilder();

            queryCompleta.AppendLine(MontaQueryObterNotasPorData(false, paginacao, atividadeId));
            queryCompleta.AppendLine(MontaQueryObterNotasPorData(true, paginacao, atividadeId));

            var retorno = new PaginacaoResultadoDto<NotasAtividadesDto>();

            using var conn = ObterConexao();

            var parametros = new
            {
                dataReferencia,
                atividadeId
            };

            using var multi = await conn.QueryMultipleAsync(queryCompleta.ToString(), parametros);
            retorno.Items = multi.Read<NotasAtividadesDto>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = retorno.TotalRegistros > 0 ? (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros) : 0;

            return retorno;
        }


        private string MontaQueryObterNotasPorData(bool ehParaPaginacao, Paginacao paginacao, long? atividadeId)
        {
            var queryCompleta = new StringBuilder("SELECT ");

            if (ehParaPaginacao)
                queryCompleta.AppendLine("count(*) ");
            else
                queryCompleta.AppendLine(@" n.id AS Id,
		                                    a.data_inclusao as dataAvaliacao,
		                                    a.titulo,
                                            n.atividade_id AS AtividadeId,                                              
                                            n.usuario_id AS UsuarioId,
                                            n.nota,
                                            n.status,
                                            c.nome as cursoNome,
                                            c.secao cursoSecao,
                                            n.data_inclusao AS DataInclusao, 
                                            n.data_alteracao AS DataAlteracao ");

            queryCompleta.AppendLine("FROM notas n ");
            queryCompleta.AppendLine(@"INNER JOIN atividades a on a.id = n.atividade_id
                                       INNER JOIN cursos c on c.id = a.curso_id ");
            queryCompleta.AppendLine("WHERE n.data_importacao = @dataReferencia ");


            if (atividadeId.HasValue)
                queryCompleta.AppendLine("AND n.atividade_id = @atividadeId");

            if (paginacao.QuantidadeRegistros > 0 && !ehParaPaginacao)
                queryCompleta.AppendLine(
                    $" OFFSET {paginacao.QuantidadeRegistrosIgnorados} ROWS FETCH NEXT {paginacao.QuantidadeRegistros} ROWS ONLY ");

            queryCompleta.AppendLine(";");

            return queryCompleta.ToString();
        }
    }
}
