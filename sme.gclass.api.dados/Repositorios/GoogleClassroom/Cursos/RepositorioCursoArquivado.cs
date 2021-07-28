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

        public async Task Inserir(long cursoId, DateTime dataArquivamento, DateTime dataExtincao, bool extinto)
        {
            var query = @" INSERT INTO public.cursos_arquivado
                            (curso_id, data_arquivamento, data_extincao, extinto)
                            values
                            (@cursoId, @dataArquivamento, @dataExtincao, @extinto)";

            using var conn = ObterConexao();
            await conn.ExecuteAsync(query, new { cursoId, dataArquivamento, dataExtincao, extinto });
        }

        public async Task<PaginacaoResultadoDto<CursoArquivadoDto>> BuscarTodosPorDataExtincao(DateTime dataExtincao, Paginacao paginacao)
        {
            var query = MontaQueryCursosExtintosPaginado(true, false);
            query += MontaQueryCursosExtintosPaginado( false, true);
  
            using var conn = ObterConexao();
            using var multi = await conn.QueryMultipleAsync(query, new { dataArquivamento = dataExtincao.Date, quantidadeRegistrosIgnorados =  paginacao.QuantidadeRegistrosIgnorados, quantidadeRegistros = paginacao.QuantidadeRegistros });

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
                @"Select c.nome as Curso,
                         data_arquivamento as DataArquivamento,
                         data_arquivamento as DataExtincao 
                 ";

            query += @" from cursos_arquivado inner join cursos c on c.id = cursos_arquivado.curso_id where data_extincao = @dataArquivamento";

           
            if (!paginado)
                query += " order by data_arquivamento ";

            if (paginacao)
                query += " OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY ";

            query += "; ";

            return query;
        }
    }
}