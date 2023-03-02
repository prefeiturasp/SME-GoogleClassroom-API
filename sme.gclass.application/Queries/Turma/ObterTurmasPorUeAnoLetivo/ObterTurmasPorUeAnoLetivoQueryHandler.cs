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
                return new List<TurmaComponentesDto>();
          
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
                    var componentesTurma = turma.Componentes.Where(componente => componentesTerritorioApiEol.
                        Any(componenteEol => componenteEol.IdComponenteCurricular == componente.ComponenteCurricularCodigo)).ToList();

                    var componentesTerritorio = from componenteTurma in componentesTurma
                        join territorioBanco in territoriosBanco on componenteTurma.ComponenteCurricularCodigo equals territorioBanco.CodigoComponenteCurricular
                        select new ComponenteTerritorioTurmaDto()
                        {
                            ComponenteCurricularCodigo = territorioBanco.ObterCodigoComponenteCurricular(turma.CodigoTurma.ToString()),
                            ComponenteCurricularCodigoUnico = territorioBanco.ObterCodigoComponenteCurricularComComponente(turma.CodigoTurma.ToString(), componenteTurma.ComponenteCurricularCodigo),
                            ComponenteCurricularCodigoEol = componenteTurma.ComponenteCurricularCodigo,
                            DataDisponibizacao = componenteTurma.DataDisponibizacao,
                            RegistroFuncional = componenteTurma.RegistroFuncional,
                            NomeComponenteCurricular = territorioBanco.ObterDescricaoComponenteCurricular()
                        };

                    var turmaComponentesTerritorio = new List<ComponenteTerritorioTurmaDto>();
                    
                    foreach (var componente in componentesTerritorio)
                    {
                        turma.Componentes.RemoveAll(c => c.ComponenteCurricularCodigo == componente.ComponenteCurricularCodigoEol
                                                                            && c.RegistroFuncional == componente.RegistroFuncional);
                        
                        if (!turmaComponentesTerritorio.Any(c => c.ComponenteCurricularCodigo == componente.ComponenteCurricularCodigo && c.RegistroFuncional == componente.RegistroFuncional))
                        {
                            turmaComponentesTerritorio.Add(new ComponenteTerritorioTurmaDto()
                            {
                                ComponenteCurricularCodigo = componente.ComponenteCurricularCodigo,
                                ComponenteCurricularCodigoUnico = componente.ComponenteCurricularCodigoUnico,
                                NomeComponenteCurricular = $"{componente.ComponenteCurricularCodigoUnico} - {componente.NomeComponenteCurricular}",
                                RegistroFuncional = componente.RegistroFuncional,
                                DataDisponibizacao = componente.DataDisponibizacao,
                            });
                        }
                    }

                    if (turmaComponentesTerritorio.Any())
                    {
                        turma.Componentes.AddRange(turmaComponentesTerritorio.Select(s=> new ComponenteTurmaDto()
                        {
                            ComponenteCurricularCodigo = s.ComponenteCurricularCodigo,
                            ComponenteCurricularCodigoUnico = s.ComponenteCurricularCodigoUnico,
                            NomeComponenteCurricular = s.NomeComponenteCurricular,
                            DataDisponibizacao = s.DataDisponibizacao,
                            RegistroFuncional = s.RegistroFuncional
                        }));
                    }
                 }
             }
             return turmasComponentes;
         }

    }
}