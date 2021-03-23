using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCursoErro : RepositorioGoogle, IRepositorioCursoErro
    {
        public RepositorioCursoErro(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        //public Task<IEnumerable<CursoErro>> ObterTodos()
        //{
        //    //TODO: Funcionarios;
        //    var query = @"select ce.turma_id as TurmaId,  from public.cursos_erro ce";

        //    using var conn = new NpgsqlConnection(ConnectionStrings.ConnectionStringGoogleClassroom);

        //    return (await conn.QueryFirstOrDefaultAsync<CursoErro>(query, parametros)) > 0;
        //}

        public async Task<long> SalvarAsync(CursoErro entidade)
        {
            var query = @" INSERT INTO cursos_erro
                            (turma_id, componente_curricular_id, mensagem, execucao_tipo, curso_id, data_inclusao, tipo)
                            VALUES
                            (@TurmaId, @ComponenteCurricularId, @Mensagem, @ExecucaoTipo, @CursoId, @DataInclusao, @tipo)";

            var parametros = new
            {
                entidade.TurmaId,
                entidade.ComponenteCurricularId,
                entidade.Mensagem,
                entidade.ExecucaoTipo,
                entidade.CursoId,
                entidade.DataInclusao,
                entidade.Tipo
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(query, parametros);
        }
    }
}