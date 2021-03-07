using Dapper;
using Npgsql;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCursoUsuarioErro : IRepositorioCursoUsuarioErro
    {
        private readonly ConnectionStrings ConnectionStrings;

        public RepositorioCursoUsuarioErro(ConnectionStrings connectionStrings)
        {
            this.ConnectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        public async Task<long> SalvarAsync(CursoUsuarioErro cursoUsuarioErro)
        {
            var query = @" INSERT INTO cursos_usuarios_erro
                            (rf, turma_id, componente_curricular_id, mensagem, execucao_tipo, curso_id, data_inclusao, tipo)
                            VALUES
                            (@rf, @turmaId, @componenteCurricularId, @execucaoTipo, @tipo, @mensagem, @dataInclusao)
                            RETURNING id";

            var parametros = new
            {
                cursoUsuarioErro.Rf,
                cursoUsuarioErro.TurmaId,
                cursoUsuarioErro.ComponenteCurricularId,
                cursoUsuarioErro.ExecucaoTipo,
                cursoUsuarioErro.Tipo,
                cursoUsuarioErro.Mensagem
            };

            using var conn = new NpgsqlConnection(ConnectionStrings.ConnectionStringGoogleClassroom);
            return  await conn.ExecuteAsync(query, parametros);
        }
    }
}