using Dapper;
using Npgsql;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioCurso : IRepositorioCurso
    {
        private readonly ConnectionStrings ConnectionStrings;
        public RepositorioCurso(ConnectionStrings connectionStrings)
        {
            this.ConnectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }
        public async Task<IEnumerable<Curso>> ObterTodosCursos()
        {
            var query = @" SELECT C.ID, 
                                  C.NOME, 
                                  C.SECAO, 
                                  C.TURMA_ID AS TURMAID, 
                                  C.COMPONENTE_CURRICULAR_ID AS COMPONENTECURRICULARID,  
                                  C.DATA_INCLUSAO AS DATAINCLUSAO,
                                  C.DATA_ATUALIZACAO AS DATAATUALIZACAO
                                  FROM CURSO C";           

            using var conn = new NpgsqlConnection(ConnectionStrings.ConnectionStringGoogleClassroom);

            return await conn.QueryAsync<Curso>(query);
        }
    }
}
