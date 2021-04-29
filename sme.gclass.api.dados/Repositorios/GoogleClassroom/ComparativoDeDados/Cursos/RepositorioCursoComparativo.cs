using Dapper;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
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
                                        (@id, @nome, @secao, @criadorId, @descricao, @dataInclusao, @inserido_manualmente_google)
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
	                c.existe_google = t1.existe_google
                from 
	                tempCursosValidacao t1
                where
	                c.id = t1.id;";

            using var conn = ObterConexao();
            return await conn.ExecuteAsync(updateQuery);
        }
    }
}
