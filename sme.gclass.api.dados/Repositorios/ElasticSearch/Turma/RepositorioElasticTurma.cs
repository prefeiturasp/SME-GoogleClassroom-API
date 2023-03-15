using Nest;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioElasticTurma : RepositorioElasticBase<DocumentoElasticTurma>, IRepositorioElasticTurma
    {
        public RepositorioElasticTurma(IElasticClient elasticClient, IServicoTelemetria servicoTelemetria) : base(elasticClient, servicoTelemetria)
        {
        }

        public async Task<IEnumerable<AlunoNaTurmaDTO>> ObterAlunosAtivosNaTurmaAsync(int codigoTurma, DateTime dataAula)
        {

                var tiposSituacoesMatricula = new List<int>() {1, 6, 10, 13};
                QueryContainer query = new QueryContainerDescriptor<AlunoNaTurmaDTO>();

                query = query && new QueryContainerDescriptor<AlunoNaTurmaDTO>().Term(termo => termo.CodigoTurma, codigoTurma);
                query = query && new QueryContainerDescriptor<AlunoNaTurmaDTO>().DateRange(termo => termo.Field(a => a.DataSituacao).LessThanOrEquals(dataAula));

                var alunosTurma = await ObterListaAsync<AlunoNaTurmaDTO>(
                    IndicesElastic.INDICE_ALUNO_TURMA_DRE, _ => query,
                    "Buscar alunos ativos na turma",
                    new { codigoTurma, DataSituacao = dataAula });

                var result = alunosTurma?.GroupBy(aluno => aluno.CodigoAluno)
                    .Select(agrupado =>
                        agrupado.OrderByDescending(aluno => aluno.DataSituacao)
                            .ThenByDescending(aluno => aluno.NumeroAlunoChamada)
                            .First())
                    .Where(aluno => tiposSituacoesMatricula.Contains(aluno.CodigoSituacaoMatricula));

                return result?.ToList();
        }

        
        public async Task<IEnumerable<TurmaComponentesDto>> ObterListaTurmasAsync(
            string codigoUe, int[] tiposEscolaModalidade, long codigoTurma, int anoLetivo,
            bool ehProfessor, string codigoRf, bool consideraHistorico,
            DateTime? periodoEscolarInicio, int modalidade)
        {
            QueryContainer query = new QueryContainerDescriptor<TurmaComponentesDto>();

            query = query && new QueryContainerDescriptor<TurmaComponentesDto>().Term(p => p.CodigoEscola, codigoUe);
            query = query && new QueryContainerDescriptor<TurmaComponentesDto>().Term(termo => termo.Ano, anoLetivo);
            
            if (modalidade > 0)
                query = query && new QueryContainerDescriptor<TurmaComponentesDto>().Term(termo => termo.Modalidade, modalidade);

            if (codigoTurma > 0)
                query = query && new QueryContainerDescriptor<TurmaComponentesDto>().Term(termo => termo.CodigoTurma, codigoTurma);

            if (ehProfessor)
                query = query && new QueryContainerDescriptor<TurmaComponentesDto>().Term(a => a.Componentes.First().RegistroFuncional, codigoRf);

            if (tiposEscolaModalidade != null)
            {
                query = query && new QueryContainerDescriptor<TurmaComponentesDto>().Terms(c => c.Name(IndicesElastic.INDICE_TURMA_COMPONENTES)
                    .Boost(1.1)
                    .Field(p => p.TipoEscola)
                    .Terms(tiposEscolaModalidade));
            }

            if (consideraHistorico && periodoEscolarInicio.HasValue)
            {
                query = query && (new QueryContainerDescriptor<TurmaComponentesDto>().Term(termo => termo.Historica, consideraHistorico)
                                && new QueryContainerDescriptor<TurmaComponentesDto>().MatchPhrase(p => p.Field(f => f.SituacaoTurmaEscola.Equals("C")))
                              || new QueryContainerDescriptor<TurmaComponentesDto>().MatchPhrase(p => p.Field(f => f.SituacaoTurmaEscola.Equals("E")))
                                && new QueryContainerDescriptor<TurmaComponentesDto>().
                                    DateRange(termo => termo.Field(a =>
                                        a.DataStatusTurmaEscola).GreaterThanOrEquals(periodoEscolarInicio)));

            }
            else
                query = query && new QueryContainerDescriptor<TurmaComponentesDto>().Term(termo => termo.Historica, consideraHistorico);

            var listagemTurmas = await ObterListaAsync<TurmaComponentesDto>(IndicesElastic.INDICE_TURMA_COMPONENTES, _ => query, "Buscar listagem de turmas");

            if (listagemTurmas == null)
                return default;

            RemoverRegistrosComDataDisponibilizacao(listagemTurmas);

            ExecuteFiltroComponentePorRf(ehProfessor, codigoRf, listagemTurmas);

            return listagemTurmas;
        }

        private void RemoverRegistrosComDataDisponibilizacao(IEnumerable<TurmaComponentesDto> listagemTurmas)
        {
            foreach (var turma in listagemTurmas)
                turma.Componentes = turma.Componentes.Where(componente => componente.DataDisponibizacao == null).ToList();
        }

        private void ExecuteFiltroComponentePorRf(bool ehProfessor, string codigoRf, IEnumerable<TurmaComponentesDto> lista)
        {
            if (!ehProfessor)
                return;

            foreach (var turma in lista)
            {
                turma.Componentes = turma.Componentes.ToList().FindAll(componente => componente.RegistroFuncional == codigoRf && componente.DataDisponibizacao == null);
            }
        }

       
    }
}
