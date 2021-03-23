using Dapper;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCursoUsuarioErro : RepositorioGoogle, IRepositorioCursoUsuarioErro
    {
        public RepositorioCursoUsuarioErro(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<long> SalvarAsync(CursoUsuarioErro cursoUsuarioErro)
        {
            var query = @" INSERT INTO cursos_usuarios_erro
                            (rf, Email, turma_id, componentecurricular_id, execucao_tipo, erro_tipo, mensagem, data_inclusao)
                            VALUES
                            (@rf, @email, @turmaId, @componenteCurricularId, @execucaoTipo, @tipo, @mensagem, @dataInclusao)
                            RETURNING id";

            var parametros = new
            {
                cursoUsuarioErro.Rf,
                cursoUsuarioErro.Email,
                cursoUsuarioErro.TurmaId,
                cursoUsuarioErro.ComponenteCurricularId,
                cursoUsuarioErro.ExecucaoTipo,
                cursoUsuarioErro.Tipo,
                cursoUsuarioErro.Mensagem,
                cursoUsuarioErro.DataInclusao
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(query, parametros);
        }
    }
}