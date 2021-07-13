using Dapper;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioAtividade : RepositorioGoogle, IRepositorioAtividade
    {
        public RepositorioAtividade(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
        }

        public async Task<long> AlterarAtividade(AtividadeGsa atividadeGsa)
        {
            const string updateQuery = @"update public.atividades
                                            set curso_id = @cursoId
                                              , usuario_id = @usuarioId
                                              , titulo = @titulo
                                              , descricao = @descricao
                                              , data_inclusao = @dataInclusao
                                              , data_alteracao = @dataAlteracao
                                        where id = @id";

            var parametros = new
            {
                id = atividadeGsa.Id,
                usuarioId = atividadeGsa.UsuarioId,
                cursoId = atividadeGsa.CursoId,
                titulo = atividadeGsa.Titulo,
                descricao = atividadeGsa.Descricao,
                dataInclusao = atividadeGsa.DataInclusao,
                dataAlteracao = atividadeGsa.DataAlteracao,
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(updateQuery, parametros);
        }

        public async Task<long> InserirAtividade(AtividadeGsa avisoGsa)
        {
            const string insertQuery = @"insert into public.atividades
                                        (id, titulo, descricao, usuario_id, curso_id, data_inclusao, data_alteracao)
                                        values
                                        (@id, @titulo, @descricao, @usuarioId, @cursoId, @dataInclusao, @dataAlteracao)";

            var parametros = new
            {
                id = avisoGsa.Id,
                titulo = avisoGsa.Titulo,
                descricao = avisoGsa.Descricao,
                usuarioId = avisoGsa.UsuarioId,
                cursoId = avisoGsa.CursoId,
                dataInclusao = avisoGsa.DataInclusao,
                dataAlteracao = avisoGsa.DataAlteracao,
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(insertQuery, parametros);
        }

        public async Task<bool> RegistroExiste(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
