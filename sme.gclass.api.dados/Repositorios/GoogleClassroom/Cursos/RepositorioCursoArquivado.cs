using Dapper;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCursoArquivado : RepositorioGoogle, IRepositorioCursoArquivado
    {
        public RepositorioCursoArquivado(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task Inserir(long cursoId, DateTime dataArquivamento, bool extinto)
        {
            var query = @" INSERT INTO public.cursos_arquivado
                            (curso_id, data_arquivamento, extinto)
                            values
                            (@cursoId, @dataArquivamento, @extinto)";

            using var conn = ObterConexao();
            await conn.ExecuteAsync(query, new {cursoId, dataArquivamento, extinto});
        }

        public async Task<PaginacaoResultadoDto<CursoArquivadoDto>> BuscarTodosPorDataArquivodo(DateTime dataArquivamento, Paginacao paginacao)
        {
            var query = MontaQueryCursosExtintosPaginado(true, false);
            query += MontaQueryCursosExtintosPaginado( false, true);
  
            using var conn = ObterConexao();
            using var multi = await conn.QueryMultipleAsync(query, new { dataArquivamento,  paginacao.QuantidadeRegistrosIgnorados, paginacao.QuantidadeRegistros });

            var retorno = new PaginacaoResultadoDto<CursoArquivadoDto>();

            retorno.Items = multi.Read<CursoArquivadoDto>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }
        
        
        private string MontaQueryCursosExtintosPaginado(bool paginacao,  bool paginado)
        {
            string query = paginado ? 
                "select count(*) " : 
                @"Select curso_id as CursoId,
                         data_arquivamento as DataExtincao ";

            query += @" from cursos_arquivado where data_arquivamento = @dataArquivamento";

           
            if (!paginado)
                query += " order by data_arquivamento ";

            if (paginacao)
                query += " OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY ";

            query += "; ";

            return query;
        }
    }
}