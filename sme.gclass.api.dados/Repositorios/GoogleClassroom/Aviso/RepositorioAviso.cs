using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioAviso : RepositorioGoogle, IRepositorioAviso
    {
        public RepositorioAviso(ConnectionStrings connectionStrings) : base(connectionStrings)
        {
        }

        public async Task<IEnumerable<AvisoGsa>> ObterAvisosAsync(long usuarioId)
        {
            using var conn = ObterConexao();
            return await conn.QueryAsync<AvisoGsa>("select * from avisos where usuario_id = @usuario_id");        
        }

        public async Task<PaginacaoResultadoDto<AvisoGsa>> ObterAvisosPorData(Paginacao paginacao, DateTime dateReferencia, string usuarioId, long? cursoId)
        {
            //using var conn = ObterConexao();
            //return await conn.QueryAsync<AvisoGsa>("select * from avisos where usuario_id = @usuario_id");

            //var queryCompleta = new StringBuilder();

            //queryCompleta.AppendLine(MontaQueryObterTodosOsCursos(false, paginacao, turmaId, componenteCurricularId, cursoId, emailCriador));
            //queryCompleta.AppendLine(MontaQueryObterTodosOsCursos(true, paginacao, turmaId, componenteCurricularId, cursoId, emailCriador));

            var retorno = new PaginacaoResultadoDto<AvisoGsa>();

            using var conn = ObterConexao();

            var parametros = new
            {
                dateReferencia,
                usuarioId,
                cursoId
            };

            try
            {

                using var multi = await conn.QueryMultipleAsync("select * from avisos", parametros);
                retorno.Items = multi.Read<AvisoGsa>();
                retorno.TotalRegistros = multi.ReadFirst<int>();
                retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return retorno;
        }

        public async Task<int> SalvarAsync(AvisoGsa avisoGsa)
        {
            const string insertQuery = @"insert into public.avisos
                                        (id, data_inclusao,curso_id,texto, usuario_id)
                                        values
                                        (@id, @data_inclusao, @curso_id, @texto, @usuario_id)";

            var parametros = new
            {
                id = avisoGsa.Id,
                dataInclusao = avisoGsa.DataInclusao,
                cursoId = avisoGsa.CursoId,
                texto = avisoGsa.Texto,
                usuarioId = avisoGsa.UsuarioId                
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(insertQuery, parametros);
        }
    }
}