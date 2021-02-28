﻿using Dapper;
using Npgsql;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCursoErro : IRepositorioCursoErro
    {
        private readonly ConnectionStrings ConnectionStrings;

        public RepositorioCursoErro(ConnectionStrings connectionStrings)
        {
            this.ConnectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        public async Task<long> SalvarAsync(CursoErro entidade)
        {
            var query = @" INSERT INTO cursos_erro 
                            (turma_id, componente_curricular_id, mensagem, execucao_tipo, curso_id, data_inclusao, tipo)
                            VALUES 
                            (@TurmaId, @ComponenteCurricularId, @Mensagem, @ExecucaoTipo, @CursoId, @DataInclusao, @tipo)";

            var parametros = new
            {
                entidade.TurmaId,
                entidade.ComponenteCurricularId,
                entidade.Mensagem,
                entidade.ExecucaoTipo,
                entidade.CursoId,
                entidade.DataInclusao,
                entidade.Tipo
            };

            using var conn = new NpgsqlConnection(ConnectionStrings.ConnectionStringGoogleClassroom);
            return await conn.ExecuteAsync(query, parametros);
        }
    }
}
