﻿using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCursoComparativo: RepositorioGoogle, IRepositorioCursoComparativo
    {
        public RepositorioCursoComparativo(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<long> SalvarAsync(CursoComparativo cursoComparativo)
        {
            const string insertQuery = @"insert into public.curso_comparativo
                                        (id, nome, secao, criador_id, descricao, data_inclusao, inserido_manualmente_google)
                                        values
                                        (@id, @nome, @secao, @criadorId, @descricao, @dataInclusao, @inseridoManualmenteGoogle)
                                        RETURNING id";

            var parametros = new
            {
                id = cursoComparativo.Id,
                nome = cursoComparativo.Nome,
                secao = cursoComparativo.Secao,
                criadorId = cursoComparativo.CriadorId,
                descricao = cursoComparativo.Descricao,
                inseridoManualmenteGoogle = cursoComparativo.InseridoManualmenteGoogle,
                dataInclusao = cursoComparativo.DataInclusao
            };

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(insertQuery, parametros);
        }

        public async Task<PaginacaoResultadoDto<CursoComparativoDto>> ObterCursosComparativosAsync(Paginacao paginacao, string secao, string nome, string descricao)
        {
            var queryCompleta = new StringBuilder();

            queryCompleta.AppendLine(MontaQueryObterCursosComparativos(false, paginacao, secao, nome, descricao));
            queryCompleta.AppendLine(MontaQueryObterCursosComparativos(true, paginacao, secao, nome, descricao));

            var retorno = new PaginacaoResultadoDto<CursoComparativoDto>();

            using var conn = ObterConexao();

            var parametros = new
            {
                paginacao,
                secao
            };

            using var multi = await conn.QueryMultipleAsync(queryCompleta.ToString(), parametros);

            retorno.Items = multi.Read<CursoComparativoDto>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        private string MontaQueryObterCursosComparativos(bool ehParaPaginacao, Paginacao paginacao, string secao, string nome, string descricao)
        {
            var queryCompleta = new StringBuilder("SELECT ");

            if (ehParaPaginacao)
                queryCompleta.AppendLine("count(*)");
            else
            {
                queryCompleta.AppendLine(@"CC.ID, 
                                  CC.NOME,
                                  CC.SECAO,
                                  CC.CRIADOR_ID AS CRIADORID,
                                  CC.DESCRICAO,
                                  CC.DATA_INCLUSAO AS DATAINCLUSAO,
                                  CC.INSERIDO_MANUALMENTE_GOOGLE AS INSERIDOMANUALMENTEGOOGLE");
            }

            queryCompleta.AppendLine(@"FROM CURSO_COMPARATIVO CC");
            queryCompleta.AppendLine(@"WHERE 1=1");


            if (!string.IsNullOrEmpty(nome))
                queryCompleta.AppendLine(@"AND CC.nome like('%" + nome?.Trim().ToLower() + "%')");

            if (!string.IsNullOrEmpty(descricao))
                queryCompleta.AppendLine(@"AND CC.descricao like('%" + descricao?.Trim().ToLower() + "%')");

            if (!string.IsNullOrEmpty(secao))
                queryCompleta.AppendLine(@"AND CC.secao like('%" + secao?.Trim().ToLower() + "%')");

            if (paginacao.QuantidadeRegistros > 0 && !ehParaPaginacao)
                queryCompleta.AppendLine($" OFFSET {paginacao.QuantidadeRegistrosIgnorados} ROWS FETCH NEXT {paginacao.QuantidadeRegistros} ROWS ONLY ; ");

            return queryCompleta.ToString();
        }

        public async Task<int> ValidarCursosExistentesCursosComparativosAsync()
        {
            const string updateQuery = @"
                drop table if exists tempCursosValidacao;
                select 
                    c.id,
                    not cc.id is null as existe_google
                into tempCursosValidacao
                from 
                    cursos c
                left join
                    curso_comparativo cc
                    on cast(c.id as varchar) = cc.id;
   
                update 
                    cursos c
                set
                    existe_google = t1.existe_google
                from 
                    tempCursosValidacao t1
                where
                    c.id = t1.id;";

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(updateQuery);
        }
    }
}