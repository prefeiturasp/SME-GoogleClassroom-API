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
                                                .Where(aluno => aluno.CodigoSituacaoMatricula != (int)TipoSituacaoMatricula.VinculoIndevido);

            return result?.ToList();
        }

        public async Task<IEnumerable<AlunoNaTurmaDTO>> ObterMatriculasTurmaDoAlunoAsync(string codigoAluno, DateTime? dataAula, int? anoLetivo)
        {
            QueryContainer query = new QueryContainerDescriptor<AlunoNaTurmaDTO>();

            query = query && new QueryContainerDescriptor<AlunoNaTurmaDTO>().Term(termo => termo.CodigoAluno, codigoAluno);
            if (dataAula != null)
                query = query && new QueryContainerDescriptor<AlunoNaTurmaDTO>().DateRange(termo => termo.Field(a => a.DataSituacao).LessThanOrEquals(dataAula));
            if ((anoLetivo ?? 0) > 0)
                query = query && new QueryContainerDescriptor<AlunoNaTurmaDTO>().Term(termo => termo.Ano, anoLetivo);

            var alunosTurma = await ObterListaAsync<AlunoNaTurmaDTO>(
                        IndicesElastic.INDICE_ALUNO_TURMA_DRE, _ => query,
                        "Buscar turmas do aluno",
                        new { codigoAluno, DataSituacao = dataAula, AnoLetivo = anoLetivo });

            var result = alunosTurma?.GroupBy(aluno => aluno.CodigoMatricula)
                                                .Select(agrupado =>
                                                    agrupado.OrderByDescending(aluno => aluno.DataSituacao)
                                                    .ThenByDescending(aluno => aluno.NumeroAlunoChamada)
                                                    .First());

            return result?.ToList();
        }

        public async Task<IEnumerable<AlunoNaTurmaDTO>> ObterAlunosNaTurmaAsync(int codigoTurma, int? anoLetivo)
        {
            QueryContainer query = new QueryContainerDescriptor<AlunoNaTurmaDTO>();

            query = query && new QueryContainerDescriptor<AlunoNaTurmaDTO>().Term(termo => termo.CodigoTurma, codigoTurma);

            if ((anoLetivo ?? 0) > 0)
                query = query && new QueryContainerDescriptor<AlunoNaTurmaDTO>().Term(termo => termo.Ano, anoLetivo);

            var alunosTurma = await ObterListaAsync<AlunoNaTurmaDTO>(
                        IndicesElastic.INDICE_ALUNO_TURMA_DRE, _ => query,
                        "Busca alunos na turma",
                        new { codigoTurma });

            var result = alunosTurma?.GroupBy(aluno => aluno.CodigoAluno)
                                                .Select(agrupado =>
                                                    agrupado.OrderByDescending(aluno => aluno.DataSituacao)
                                                            .ThenByDescending(aluno => aluno.NumeroAlunoChamada)
                                                            .First());

            return result?.ToList();
        }

        public async Task<IReadOnlyList<AlunoNaTurmaDTO>> ObterAlunosPorTurmaAsync(int codigoTurma, int codigoAluno, bool consideraInativos = false)
        {
            QueryContainer query = new QueryContainerDescriptor<AlunoNaTurmaDTO>();

            query = query && new QueryContainerDescriptor<AlunoNaTurmaDTO>().Term(termo => termo.CodigoTurma, codigoTurma);

            if (codigoAluno > 0)
                query = query && new QueryContainerDescriptor<AlunoNaTurmaDTO>().Term(termo => termo.CodigoAluno, codigoAluno);

            var alunosTurma = await ObterListaAsync<AlunoNaTurmaDTO>(
                                    IndicesElastic.INDICE_ALUNO_TURMA_DRE, _ => query,
                                    "Busca alunos por turma",
                                    new { codigoTurma, codigoAluno, consideraInativos });

            var result = alunosTurma?.GroupBy(aluno => aluno.CodigoAluno)
                                                .Select(agrupado =>
                                                    agrupado.OrderByDescending(aluno => aluno.DataSituacao)
                                                            .ThenByDescending(aluno => aluno.NumeroAlunoChamada)
                                                            .First());
            if (!consideraInativos)
                result = result.Where(aluno => new List<int> { 1, 2, 3, 5, 6, 10, 13 }.Contains(aluno.CodigoSituacaoMatricula));
            return result?.ToList();
        }

        public async Task<IEnumerable<AlunoNaTurmaDTO>> ObterAlunosPorTurmaMultiplexConnetionAsync(int codigoTurma)
        {
            QueryContainer query = new QueryContainerDescriptor<AlunoNaTurmaDTO>();

            query = query && new QueryContainerDescriptor<AlunoNaTurmaDTO>().Term(termo => termo.CodigoTurma, codigoTurma);

            var alunosTurma = await ObterListaAsync<AlunoNaTurmaDTO>(
                                IndicesElastic.INDICE_ALUNO_TURMA_DRE, _ => query,
                                "Busca alunos por turma multiplex",
                                new { codigoTurma });

            var result = alunosTurma?.GroupBy(aluno => aluno.CodigoAluno)
                                                .Select(agrupado =>
                                                    agrupado.OrderByDescending(aluno => aluno.DataSituacao)
                                                            .ThenByDescending(aluno => aluno.NumeroAlunoChamada)
                                                            .First());

            return result?.ToList();
        }

        public async Task<IEnumerable<AlunoNaTurmaDTO>> ObterMatriculasAlunoNaTurma(int codigoTurma, int codigoAluno)
        {
            QueryContainer query = new QueryContainerDescriptor<AlunoNaTurmaDTO>();

            query = query && new QueryContainerDescriptor<AlunoNaTurmaDTO>().Term(termo => termo.CodigoTurma, codigoTurma);
            query = query && new QueryContainerDescriptor<AlunoNaTurmaDTO>().Term(termo => termo.CodigoAluno, codigoAluno);

            var alunosTurma = await ObterListaAsync<AlunoNaTurmaDTO>(
                                IndicesElastic.INDICE_ALUNO_TURMA_DRE, _ => query,
                                "Busca matricula aluno na turma",
                                new { codigoTurma, codigoAluno });

            var result = alunosTurma?.GroupBy(aluno => aluno.CodigoMatricula)
                                                .Select(agrupado =>
                                                    agrupado.OrderByDescending(aluno => aluno.DataSituacao)
                                                    .ThenByDescending(aluno => aluno.NumeroAlunoChamada)
                                                    .First());

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

            ExecuteFiltroComponentePorRf(ehProfessor, codigoRf, listagemTurmas);

            return listagemTurmas;
        }

        private void ExecuteFiltroComponentePorRf(bool ehProfessor, string codigoRf, IEnumerable<TurmaComponentesDto> lista)
        {
            if (!ehProfessor)
                return;

            foreach (var turma in lista)
            {
                turma.Componentes = turma.Componentes.ToList().FindAll(componente => componente.RegistroFuncional == codigoRf);
            }
        }

        public async Task<IReadOnlyList<AlunoNaTurmaDTO>> ObterTodosAlunosNaTurmaAsync(int codigoTurma, int? codigoAluno)
        {
            QueryContainer query = new QueryContainerDescriptor<AlunoNaTurmaDTO>();

            query = query && new QueryContainerDescriptor<AlunoNaTurmaDTO>().Term(termo => termo.CodigoTurma, codigoTurma);

            if (codigoAluno.HasValue)
                query = query && new QueryContainerDescriptor<AlunoNaTurmaDTO>().Term(termo => termo.CodigoAluno, codigoAluno);

            var alunosTurma = await ObterListaAsync<AlunoNaTurmaDTO>(
                IndicesElastic.INDICE_ALUNO_TURMA_DRE, _ => query,
                "Busca matricula aluno na turma",
                new { codigoTurma, codigoAluno });

            return alunosTurma?
                .OrderByDescending(a => a.DataSituacao)
                .GroupBy(aluno => aluno.CodigoMatricula)
                .Select(agrupado =>
                    new AlunoNaTurmaDTO()
                    {
                        CodigoAluno = agrupado.First().CodigoAluno,
                        NomeAluno = agrupado.First().NomeAluno,
                        DataNascimento = agrupado.First().DataNascimento,
                        NomeSocialAluno = agrupado.First().NomeSocialAluno,
                        CodigoSituacaoMatricula = agrupado.First().CodigoSituacaoMatricula,
                        SituacaoMatricula = agrupado.First().SituacaoMatricula,
                        DataSituacao = agrupado.First().DataSituacao,
                        DataMatricula = agrupado.Last().DataSituacao,
                        NumeroAlunoChamada = agrupado.First().NumeroAlunoChamada,
                        PossuiDeficiencia = agrupado.First().PossuiDeficiencia,
                        Transferencia_Interna = agrupado.First().Transferencia_Interna,
                        Remanejado = agrupado.First().Remanejado,
                        EscolaTransferencia = agrupado.First().EscolaTransferencia,
                        TurmaTransferencia = agrupado.First().TurmaTransferencia,
                        TurmaRemanejamento = agrupado.First().TurmaRemanejamento,
                        ParecerConclusivo = agrupado.First().ParecerConclusivo,
                        NomeResponsavel = agrupado.First().NomeResponsavel,
                        TipoResponsavel = agrupado.First().TipoResponsavel,
                        CelularResponsavel = agrupado.First().CelularResponsavel,
                        DataAtualizacaoContato = agrupado.First().DataAtualizacaoContato,
                        CodigoMatricula = agrupado.First().CodigoMatricula,
                        Sequencia = agrupado.First().Sequencia
                    }).ToList();
        }
    }
}
