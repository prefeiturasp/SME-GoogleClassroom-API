using Dapper;
using Npgsql;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCursoErro : RepositorioGoogle, IRepositorioCursoErro
    {
        public RepositorioCursoErro(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<IEnumerable<CursoErro>> ObterTodos()
        {            
            var query = @"select id,
	                             turma_id as TurmaId,
	                             componente_curricular_id as ComponenteCurricularId,
	                             mensagem,
	                             execucao_tipo as ExecucaoTipo,
	                             curso_id as CursoId,
	                             data_inclusao as DataInclusao,
	                             tipo 
                            from cursos_erro ce";

            using var conn = ObterConexao();
            return await conn.QueryAsync<CursoErro>(query);
        }

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