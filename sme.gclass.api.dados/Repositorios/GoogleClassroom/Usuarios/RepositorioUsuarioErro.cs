﻿using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioUsuarioErro : RepositorioGoogle, IRepositorioUsuarioErro
    {
        public RepositorioUsuarioErro(ConnectionStrings connectionStrings)
            : base(connectionStrings)
        {
        }

        public async Task<long> SalvarAsync(long? usuarioId, string email, string mensagem, UsuarioTipo usuarioTipo, ExecucaoTipo execucaoTipo, DateTime dataInclusao)
        {
            var query = @" INSERT INTO public.usuarios_erro
                                  (usuario_id, email, mensagem, usuario_tipo, execucao_tipo, data_inclusao)
                           VALUES (@usuarioId, @email, @mensagem, @usuarioTipo, @execucaoTipo, @dataInclusao)
                           RETURNING id";

            using (var conn = ObterConexao())
            {
                return await conn.ExecuteScalarAsync<long>(query, new { usuarioId, email, mensagem, usuarioTipo, execucaoTipo, dataInclusao });
            }
        }
    }
}