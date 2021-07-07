﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<PaginacaoResultadoDto<AvisoGsa>> ObterAvisosPorData(Paginacao paginacao, DateTime dataReferencia, string usuarioId, long? cursoId)
        {
            var queryCompleta = new StringBuilder();

            queryCompleta.AppendLine(MontaQueryObterAvisosPorData(false, paginacao, usuarioId, cursoId));
            queryCompleta.AppendLine(MontaQueryObterAvisosPorData(true, paginacao, usuarioId, cursoId));

            var retorno = new PaginacaoResultadoDto<AvisoGsa>();

            using var conn = ObterConexao();

            var parametros = new
            {
                dataReferencia,
                usuarioId,
                cursoId
            };

            var multi = await conn.QueryAsync<AvisoGsa>(queryCompleta.ToString(), parametros);
            retorno.Items = multi;
            retorno.TotalRegistros = multi.ToList().Count();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

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

        private string MontaQueryObterAvisosPorData(bool ehParaPaginacao, Paginacao paginacao, string usuarioId, long? cursoId)
        {
            var queryCompleta = new StringBuilder("SELECT ");

            if (ehParaPaginacao)
                queryCompleta.AppendLine("count(*)");
            else
            {
                queryCompleta.AppendLine(@"A.id, 
                                A.texto, 
                                A.data_inclusao, 
                                A.usuario_id, 
                                A.curso_id");
            }

            queryCompleta.AppendLine("FROM AVISOS A");
            queryCompleta.AppendLine("WHERE A.DATA_INCLUSAO = @dataReferencia");

            if (!string.IsNullOrEmpty(usuarioId))
                queryCompleta.AppendLine($"AND A.usuario_id = @usuarioId");

            if (cursoId.HasValue)
                queryCompleta.AppendLine(@"AND C.Id = @cursoId");

            if (paginacao.QuantidadeRegistros > 0)
                queryCompleta.AppendLine($" OFFSET {paginacao.QuantidadeRegistrosIgnorados} ROWS FETCH NEXT {paginacao.QuantidadeRegistros} ROWS ONLY ; ");

            return queryCompleta.ToString();
        }
    }
}