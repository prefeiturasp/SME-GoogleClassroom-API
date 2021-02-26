using Dapper;
using Npgsql;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCurso : IRepositorioCurso
    {
        private readonly ConnectionStrings ConnectionStrings;

        public RepositorioCurso(ConnectionStrings connectionStrings)
        {
            ConnectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        public async Task<long> SalvarAsync(long id, string email, string nome, string secao, long turmaId, long componenteCurricularId, DateTime dataInclusao, DateTime? dataAtualizacao)
        {
            var query = @" INSERT INTO public.cursos
                            (id, email, nome, secao, turma_id, componente_curricular_id, data_inclusao, data_atualizacao)
                            values
                            (@Id, @Email, @Nome, @Secao, @TurmaId, @ComponenteCurricularId, @DataInclusao, @DataAtualizacao)";

            var parametros = new
            {
                id,
                email,
                nome,
                secao,
                turmaId,
                componenteCurricularId,
                dataInclusao,
                dataAtualizacao
            };

            using var conn = new NpgsqlConnection(ConnectionStrings.ConnectionStringGoogleClassroom);
            return await conn.ExecuteAsync(query, parametros);
        }
    }
}
