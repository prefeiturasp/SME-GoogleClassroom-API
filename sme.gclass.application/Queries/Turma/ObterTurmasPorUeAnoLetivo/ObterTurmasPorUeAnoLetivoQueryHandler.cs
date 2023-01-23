using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Aplicacao.Queries.SME.Pedagogico.Service.Queries;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dados.Interfaces;
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
                return default;
          
            var turmasComTerritorioSaber = await TratarComponentesTerritorioSaber(turmasCacheadas.ToList());
            return turmasComTerritorioSaber;
        }

        private async Task<IEnumerable<TurmaComponentesDto>> TratarComponentesTerritorioSaber(List<TurmaComponentesDto> turmasComponentes)
         {
            var componentesTerritorioApiEol = (await componenteCurricularRepository.ObterDisciplinasAsync()).Where(componente => componente.EhTerritorio);
            Dictionary<long, List<DisciplinaTerritorioSaberDTO>> disciplinasTerritoriosTurmaMemory = new Dictionary<long, List<DisciplinaTerritorioSaberDTO>>();
            List<DisciplinaTerritorioSaberDTO> territoriosBanco = null;

            foreach (var turma in 
                      turmasComponentes.Where(turma => 
                                                turma.Componentes.Any(componente => 
                                                                        componentesTerritorioApiEol.Any(componenteEol => 
                                                                                                componenteEol.IdComponenteCurricular == componente.ComponenteCurricularCodigo))))
             {
                if (!disciplinasTerritoriosTurmaMemory.ContainsKey(turma.CodigoTurma))
                {
                   var codigosDisciplinasTerritorio = turma.Componentes.Where(componente => componentesTerritorioApiEol.Any(componenteEol =>
                                                                                                    componenteEol.IdComponenteCurricular == componente.ComponenteCurricularCodigo))
                                                                                            .Select(componente => componente.ComponenteCurricularCodigo);
                    disciplinasTerritoriosTurmaMemory.Add(turma.CodigoTurma,
                                                    (await componenteCurricularRepository.ObterDisciplinaTerritorioDosSaberesAsync(turma.CodigoTurma.ToString(), codigosDisciplinasTerritorio)).ToList());
                }
                territoriosBanco = disciplinasTerritoriosTurmaMemory.GetValueOrDefault(turma.CodigoTurma);

                 if (territoriosBanco != null && territoriosBanco.Any())
                 {
                    var territorios = territoriosBanco.GroupBy(c => new { c.CodigoTerritorioSaber, c.CodigoExperienciaPedagogica, c.DataInicio });

                    var componentesTurma = turma.Componentes.Where(componente =>
                                                            componentesTerritorioApiEol.Any(componenteEol =>
                                                                                    componenteEol.IdComponenteCurricular == componente.ComponenteCurricularCodigo)).ToList();
                    foreach (var componenteTurma in
                                componentesTurma)
                    {
                        turma.Componentes.RemoveAll(componente => 
                                                             componente.ComponenteCurricularCodigo == componenteTurma.ComponenteCurricularCodigo
                                                             && componente.RegistroFuncional == componenteTurma.RegistroFuncional);
                        
                        foreach (var componenteTerritorio in territorios)
                        {
                            var codigoComponenteCurricular = componenteTerritorio.FirstOrDefault().ObterCodigoComponenteCurricular(turma.CodigoTurma.ToString());
                            if (!turma.Componentes.Any(componente =>
                                                             componente.ComponenteCurricularCodigo == codigoComponenteCurricular
                                                             && componente.RegistroFuncional == componenteTurma.RegistroFuncional))
                                turma.Componentes.Add(new ComponenteTurmaDto()
                            {
                                ComponenteCurricularCodigo = codigoComponenteCurricular,
                                NomeComponenteCurricular = componenteTerritorio.FirstOrDefault().ObterDescricaoComponenteCurricular(),
                                RegistroFuncional = componenteTurma.RegistroFuncional,
                                DataDisponibizacao = componenteTurma.DataDisponibizacao,
                            });
                        }
                    }                      
                 }
             }
             return turmasComponentes;
         }

    }
}