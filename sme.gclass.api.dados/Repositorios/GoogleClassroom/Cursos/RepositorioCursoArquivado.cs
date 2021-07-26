using Dapper;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCursoArquivado : RepositorioGoogle, IRepositorioCursoArquivado
    {
        public RepositorioCursoArquivado(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<long> Arquivar(long cursoId, DateTime dataArquivamento, bool extinto)
        {
            var query = @" INSERT INTO public.cursos_arquivado
                            (curso_id, data_arquivamento, extinto)
                            values
                            (@CursoId, @DataArquivamento, @Extinto)";

            var parametros = new
            {
                cursoId,
                dataArquivamento,
                extinto
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(query, parametros);
        }
    }
}