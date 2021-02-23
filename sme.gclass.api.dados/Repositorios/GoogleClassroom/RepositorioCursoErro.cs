using Dapper;
using Npgsql;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCursoErro : IRepositorioCursoErro
    {
        private readonly ConnectionStrings ConnectionStrings;

        public RepositorioCursoErro(ConnectionStrings connectionStrings)
        {
            this.ConnectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        public async Task<long> SalvarAsync(CursoErroDto dto)
        {
            var query = @" INSERT INTO cursos_erro 
                            (turma_id, componente_curricular_id, mensagem, execucao_tipo, curso_id, data_inclusao)
                            VALUES 
                            (@TurmaId, @ComponenteCurricularId, @Mensagem, @ExecucaoTipo, @CursoId, @DataInclusao)";

            var parametros = new
            {
                dto.TurmaId,
                dto.ComponenteCurricularId,
                dto.Mensagem,
                ExecucaoTipo = (int)dto.ExecucaoTipo,
                dto.CursoId,
                dto.DataInclusao
            };

            using var conn = new NpgsqlConnection(ConnectionStrings.ConnectionStringGoogleClassroom);
            return await conn.ExecuteAsync(query, parametros);
        }
    }
}
