using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Aplicacao.Queries.SME.Pedagogico.Service.Queries;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.Pedagogico.Interface.DTO.RetornoQueryDTO;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterTurmasPorUeAnoLetivoQueryHandler : IRequestHandler<ObterTurmasPorUeAnoLetivoQuery, IEnumerable<TurmaComponentesDto>>
    {
        private readonly IRepositorioElasticTurma repositorioElasticTurma;
        private readonly IRepositorioComponenteCurricularEol componenteCurricularRepository;

        public ObterTurmasPorUeAnoLetivoQueryHandler(IRepositorioElasticTurma repositorioElasticTurma, IRepositorioComponenteCurricularEol componenteCurricularRepository)
        {
            this.repositorioElasticTurma = repositorioElasticTurma ?? throw new ArgumentNullException(nameof(repositorioElasticTurma));
            this.componenteCurricularRepository = componenteCurricularRepository ?? throw new ArgumentNullException(nameof(componenteCurricularRepository));
        }

        public async Task<IEnumerable<TurmaComponentesDto>> Handle(ObterTurmasPorUeAnoLetivoQuery request, CancellationToken cancellationToken)
        {
            var turmasCacheadas = await repositorioElasticTurma.ObterListaTurmasAsync(
                                                    request.CodigoUe, null, 0, request.AnoLetivo, false, 
                                                    "", false, null, 0);

            if (!turmasCacheadas.Any())
                return new List<TurmaComponentesDto>();
          
            var retorno = turmasCacheadas.ToList();
            await AdicionarComponentesTerritorioAsync(retorno);
            return retorno;
        }

        public async Task AdicionarComponentesTerritorioAsync(List<TurmaComponentesDto> turmasComponentes)
        {
            var componentesTerritorioApiEol = (await componenteCurricularRepository.ObterDisciplinasAsync()).Where(componente => componente.EhTerritorio);

            foreach (var turma in turmasComponentes.Where(turma =>
                                                turma.Componentes.Any(componente =>
                                                                        componentesTerritorioApiEol.Any(componenteEol =>
                                                                                                componenteEol.IdComponenteCurricular == componente.ComponenteCurricularCodigo))))
            {
                var codigosComponentesCurricularesTerritorio = turma.Componentes.Where(cc => componentesTerritorioApiEol.Any(cct => cct.IdComponenteCurricular == cc.ComponenteCurricularCodigo))
                                                                                      .Select(cc => cc.ComponenteCurricularCodigo);
                if (!codigosComponentesCurricularesTerritorio.Any())
                    continue;

                var componentesTerritorioTurma = await componenteCurricularRepository.ObterDisciplinaTerritorioDosSaberesAsync(turma.CodigoTurma.ToString(), codigosComponentesCurricularesTerritorio);
                foreach (var informacoesComponenteTerritorioSaber in componentesTerritorioTurma)
                {
                    var tipoEscola = turma.TipoEscola;

                    turma.Componentes.RemoveAll(cc => cc.ComponenteCurricularCodigo == informacoesComponenteTerritorioSaber.CodigoComponenteCurricular);

                    var agrupamentosTerritorioSaber = await ObterAgrupamentosTerritorioSaber(turma.CodigoTurma, informacoesComponenteTerritorioSaber.CodigoTerritorioSaber,
                                                                                            informacoesComponenteTerritorioSaber.CodigoExperienciaPedagogica,
                                                                                            informacoesComponenteTerritorioSaber.CodigoComponenteCurricular,
                                                                                            string.Empty);

                    foreach (var agrupamentoTerritorioSaber in agrupamentosTerritorioSaber)
                    {
                        if (!turma.Componentes.Any(cc => cc.ComponenteCurricularCodigo == agrupamentoTerritorioSaber.CodigoAgrupamento))
                        {
                            turma.Componentes.Add(new ComponenteTurmaDto()
                            {
                                ComponenteCurricularCodigo = agrupamentoTerritorioSaber.CodigoAgrupamento,
                                DataDisponibizacao = agrupamentoTerritorioSaber.DtFimAtribuicao,
                                NomeComponenteCurricular = informacoesComponenteTerritorioSaber.ObterDescricaoComponenteCurricular(),
                                RegistroFuncional = agrupamentoTerritorioSaber.RfProfessor
                            });
                        }
                    }

                    if (!turma.Componentes.Any(cc => cc.ComponenteCurricularCodigo == informacoesComponenteTerritorioSaber.CodigoComponenteCurricular))
                    {
                        var agrupamentoTerritorioSaberMaisRecente = agrupamentosTerritorioSaber.FirstOrDefault();
                        var atribuicaoNaoAgrupada = await ObterComponenteCurricularTerritorioAtribuicaoNaoAgrupadaQuery(
                                                                                        turma.CodigoTurma,
                                                                                        informacoesComponenteTerritorioSaber.CodigoComponenteCurricular,
                                                                                        string.Empty);

                        var possuiAtribuicaoUnica = !(atribuicaoNaoAgrupada is null);
                        var possuiAtribuicaoAgrupamento = !(agrupamentoTerritorioSaberMaisRecente is null);
                        var ehFiltroGestor = true;

                        if (possuiAtribuicaoUnica ||
                            (!possuiAtribuicaoAgrupamento && ehFiltroGestor))
                            turma.Componentes.Add(new ComponenteTurmaDto()
                            {
                                ComponenteCurricularCodigo = informacoesComponenteTerritorioSaber.CodigoComponenteCurricular,
                                DataDisponibizacao = atribuicaoNaoAgrupada?.DataDisponibilizacao,
                                NomeComponenteCurricular = informacoesComponenteTerritorioSaber.ObterDescricaoComponenteCurricular(),
                                RegistroFuncional = atribuicaoNaoAgrupada?.RfProfessor
                            });
                    }
                }
            }
        }

        private async Task<ComponenteCurricularTerritorioAtribuidoTurmaDTO> ObterComponenteCurricularTerritorioAtribuicaoNaoAgrupadaQuery(long codigoTurma, long codigoComponenteCurricular,
                                                                             string codigoRf = null,
                                                                             DateTime? dataBaseVigencia = null)
        {
            var componentesCurricularesAtribuidosTurma = await componenteCurricularRepository.ObterComponentesCurricularesTerritorioAtribuidos(codigoTurma, codigoRf);
            var componentesCurricularesAtribuidosTurmaAgrupados = componentesCurricularesAtribuidosTurma.GroupBy(aa => new { aa.TurmaCodigo, aa.CodigoTerritorioSaber, aa.CodigoExperienciaPedagogica, aa.RfProfessor, aa.DataAtribuicao })
                              .Where(aa => aa.Count() == 1)
                              .SelectMany(grp => grp.ToList())
                              .OrderByDescending(aa => aa.DataAtribuicao)
                              .ThenByDescending(aa => aa.DataDisponibilizacao is null)
                              .Where(cc => cc.CodigoComponenteCurricular == codigoComponenteCurricular
                                    && (dataBaseVigencia == null || cc.DataAtribuicao <= dataBaseVigencia));
            return componentesCurricularesAtribuidosTurmaAgrupados.FirstOrDefault();
        }

        private async Task<IEnumerable<AgrupamentoAtribuicaoTerritorioSaber>> ObterAgrupamentosTerritorioSaber(long codigoTurma, long codigoTerritorioSaber, long codigoExperienciaPegagogica, long codigoComponenteCurricular, string rfProf)
        {
            var agrupamentosTerritorio = (await componenteCurricularRepository.ObterAgrupamentosTerritorioSaber(codigoTurma, codigoTerritorioSaber, codigoExperienciaPegagogica, codigoComponenteCurricular))
                                                                                        .OrderByDescending(aa => aa.DtInicioAtribuicao)
                                                                                        .ThenByDescending(aa => aa.DtFimAtribuicao is null);

            var retorno = new List<AgrupamentoAtribuicaoTerritorioSaber>();
            foreach (var item in agrupamentosTerritorio.Where(aa => aa.RfProfessor.Equals(rfProf) || string.IsNullOrEmpty(rfProf)))
            {
                if (!retorno.Any(r => r.RfProfessor.Equals(item.RfProfessor) &&
                                      r.CodigosComponentesCurriculares.Equals(item.CodigosComponentesCurriculares)))
                {
                    retorno.Add(item);
                }
            }
            return retorno;
        }

    }
}