using Dapper;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioAlunoInativoErro : RepositorioGoogle, IRepositorioAlunoInativoErro
    {
        public RepositorioAlunoInativoErro(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<long> SalvarAsync(AlunoInativoErro alunoInativoErro)
        {
            var query = @"INSERT INTO public.aluno_inativo_erro  
                           (usuario_id, mensagem, execucao_tipo, data_inclusao)
                         VALUES
                           (@usuarioId, @mensagem, @execucaoTipo, @dataInclusao)
                         RETURNING id";

            var parametros = new
            {
                alunoInativoErro.UsuarioId,
                alunoInativoErro.Mensagem,
                alunoInativoErro.ExecucaoTipo,
                alunoInativoErro.DataInclusao
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(query, parametros);
        }

        public async Task<PaginacaoResultadoDto<CursoUsuarioRemovidoConsultaDto>> ObterAlunosCursosRemovidosPorCursoId(Paginacao paginacao, string cursoId)
        {
            var query = new StringBuilder(@"SELECT
                                                   ui.usuario_id UsuarioId,
                                                   ui.removido_em RemovidoEm,
                                                   u.google_classroom_id UsuarioGsaId,
                                                   u.email EmailUsuario,
                                                   u.nome NomeUsuario
                                              FROM usuario_inativado_gsa ui
                                              inner join usuarios u on u.indice = ui.usuario_id 
                                             WHERE ui.usuario_tipo = @tipo ");

            var queryCount = new StringBuilder("SELECT count(*) from usuario_inativado_gsa u WHERE u.usuario_tipo = @tipo ");

            if (!string.IsNullOrEmpty(cursoId))
            {
                query.AppendLine("AND u.curso_id = @cursoId");
                queryCount.AppendLine("AND u.curso_id = @cursoId");
            }

            if (paginacao.QuantidadeRegistros > 0)
                query.AppendLine($" OFFSET @quantidadeRegistrosIgnorados ROWS FETCH NEXT @quantidadeRegistros ROWS ONLY ");

            query.AppendLine(";");
            query.AppendLine(queryCount.ToString());

            var retorno = new PaginacaoResultadoDto<CursoUsuarioRemovidoConsultaDto>();

            var parametros = new
            {
                quantidadeRegistrosIgnorados = paginacao.QuantidadeRegistrosIgnorados,
                quantidadeRegistros = paginacao.QuantidadeRegistros,
                tipo = UsuarioTipo.Aluno,
                cursoId
            };

            using var conn = ObterConexao();

            using var registros = await conn.QueryMultipleAsync(query.ToString(), parametros);

            retorno.Items = registros.Read<CursoUsuarioRemovidoConsultaDto>();
            retorno.TotalRegistros = registros.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }
    }
}