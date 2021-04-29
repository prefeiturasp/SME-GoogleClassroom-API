﻿using Dapper;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Dominio;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuarioComparativo : RepositorioGoogle, IRepositorioUsuarioComparativo
    {
        public RepositorioUsuarioComparativo(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {

        }

        public async Task<int> ValidarUsuariosExistentesUsuariosComparativosAsync()
        {
            const string updateQuery = @"
               drop table if exists tempUsuariosValidacao;
                    select
                    u.id,
                    not uc.id is null as existe_google
                    into tempUsuariosValidacao
                    from
                    usuarios u
                    left join
                    usuario_comparativo uc
                    on cast(u.id as varchar) = uc.id;

                    update
                    usuarios c
                    set
                    existe_google = t1.existe_google
                    from
                    tempUsuariosValidacao t1
                    where
                    c.id = t1.id;";

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(updateQuery);
        }
        public async Task<PaginacaoResultadoDto<UsuarioComparativo>> ObterUsuariosComparativosAsync(Paginacao paginacao, string nome, string email, string organizationPath)
        {
            var queryCompleta = new StringBuilder();

            queryCompleta.AppendLine(MontaQueryObterUsuariosComparativos(false, paginacao, nome, email, organizationPath));
            queryCompleta.AppendLine(MontaQueryObterUsuariosComparativos(false, paginacao, nome, email, organizationPath));

            var retorno = new PaginacaoResultadoDto<UsuarioComparativo>();

            using var conn = ObterConexao();

            var parametros = new
            {
                paginacao,
                nome,
                email,
                organizationPath
            };

            using var multi = await conn.QueryMultipleAsync(queryCompleta.ToString(), parametros);

            retorno.Items = multi.Read<UsuarioComparativo>();
            retorno.TotalRegistros = multi.ReadFirst<int>();
            retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / paginacao.QuantidadeRegistros);

            return retorno;
        }

        private string MontaQueryObterUsuariosComparativos(bool ehParaPaginacao, Paginacao paginacao, string nome, string email, string organizationPath)
        {
            var queryCompleta = new StringBuilder("SELECT ");

            if (ehParaPaginacao)
                queryCompleta.AppendLine("count(*)");
            else
            {
                queryCompleta.AppendLine(@"UC.ID, 
                                  UC.NOME,
                                  UC.SECAO,
                                  UC.CRIADOR_ID AS CRIADORID,
                                  UC.DESCRICAO,
                                  UC.DATA_INCLUSAO AS DATAINCLUSAO,
                                  UC.INSERIDO_MANUALMENTE_GOOGLE AS INSERIDOMANUALMENTEGOOGLE");
            }

            queryCompleta.AppendLine(@"FROM USUARIO_COMPARATIVO UC");
            queryCompleta.AppendLine(@"WHERE 1=1");

            if (!string.IsNullOrEmpty(nome))
                queryCompleta.AppendLine(@"AND UC.nome like('%" + nome?.Trim().ToLower() + "%')");

            if (!string.IsNullOrEmpty(nome))
                queryCompleta.AppendLine(@"AND UC.email like('%" + email?.Trim().ToLower() + "%')");
            if (!string.IsNullOrEmpty(nome))
                queryCompleta.AppendLine(@"AND UC.organization_path like('%" + organizationPath?.Trim().ToLower() + "%')");

            if (paginacao.QuantidadeRegistros > 0 && !ehParaPaginacao)
                queryCompleta.AppendLine($" OFFSET {paginacao.QuantidadeRegistrosIgnorados} ROWS FETCH NEXT {paginacao.QuantidadeRegistros} ROWS ONLY ; ");

            return queryCompleta.ToString();
        }

        public async Task<bool> SalvarAsync(UsuarioComparativo usuarioComparativo)
        {
            const string insertQuery = @"insert into public.usuario_comparativo
                                        (id, nome, email, data_inclusao, data_ultimo_login, eh_admin, organization_path)
                                        values
                                        (@id, @nome, @email, @dataInclusao, @dataUltimoLogin, @EhAdmin, @OrganizationPath)
                                        RETURNING id";

            var parametros = new
            {
                usuarioComparativo.Id,
                usuarioComparativo.Nome,
                usuarioComparativo.Email,
                usuarioComparativo.DataInclusao,
                usuarioComparativo.DataUltimoLogin,
                usuarioComparativo.EhAdmin,
                usuarioComparativo.OrganizationPath,
            };

            using var conn = ObterConexao();
            await conn.ExecuteAsync(insertQuery, parametros);

            return true;
        }
    }
}
