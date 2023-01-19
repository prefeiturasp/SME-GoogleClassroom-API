using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Aplicacao.Queries.SME.Pedagogico.Service.Queries;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterTurmasPorUeAnoLetivoQueryHandler : IRequestHandler<ObterTurmasPorUeAnoLetivoQuery, IEnumerable<TurmaComponentesDto>>
    {
        private readonly IRepositorioElasticTurma repositorioElasticTurma;
        //private readonly IComponenteCurricularService componenteCurricularService;
        //private readonly IFuncionarioRepository funcionarioRepository;
        //private readonly IMediator mediator;

        public ObterTurmasPorUeAnoLetivoQueryHandler(IRepositorioElasticTurma repositorioElasticTurma)
        {
            this.repositorioElasticTurma = repositorioElasticTurma ?? throw new ArgumentNullException(nameof(repositorioElasticTurma));
            //this.componenteCurricularService = componenteCurricularService ?? throw new ArgumentNullException(nameof(componenteCurricularService));
            //this.funcionarioRepository = funcionarioRepository ?? throw new ArgumentNullException(nameof(funcionarioRepository));
            //this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<TurmaComponentesDto>> Handle(ObterTurmasPorUeAnoLetivoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioElasticTurma.ObterListaTurmasAsync(
                                                    request.CodigoUe, null, 0, request.AnoLetivo, false, 
                                                    "", false, null, 0);

            /*if (!turmasCacheadas.Any())
                return default;

            var retorno = turmasCacheadas.SelectMany(a => a.Componentes, (turma, componente) => 
                new RetornoConsultaListagemTurmaComponenteDto()
                {
                    TurmaCodigo = turma.CodigoTurma.ToString(),
                    Modalidade = turma.Modalidade.ToString(),
                    NomeTurma = turma.NomeTurma,
                    Ano = turma.AnoTurma,
                    ComplementoTurmaEJA = turma.ComplementoTurmaEJA,
                    NomeComponenteCurricular = componente.NomeComponenteCurricular,
                    Turno = turma.Turno,
                    ComponenteCurricularCodigo = componente.ComponenteCurricularCodigo
                }).GroupBy(g => new { g.TurmaCodigo, g.Modalidade, g.NomeTurma, g.NomeComponenteCurricular, g.Ano, g.ComplementoTurmaEJA, g.Turno, g.ComponenteCurricularCodigo })
                .Select(s => new RetornoConsultaListagemTurmaComponenteDto()
                {
                    TurmaCodigo = s.Key.TurmaCodigo,
                    Modalidade = s.Key.Modalidade,
                    NomeTurma = s.Key.NomeTurma,
                    Ano = s.Key.Ano,
                    ComplementoTurmaEJA = s.Key.ComplementoTurmaEJA,
                    NomeComponenteCurricular = s.Key.NomeComponenteCurricular,
                    Turno = s.Key.Turno,
                    ComponenteCurricularCodigo = s.Key.ComponenteCurricularCodigo
                });

            if (request.AnosInfantilDesconsiderar.Any(a => a != null))
                retorno = retorno.Where(w => !request.AnosInfantilDesconsiderar.Contains(w.Ano));

            var turmasComTerritorioSaber = await TratarComponentesTerritorioSaber(retorno);

            var totalRegistros = turmasComTerritorioSaber.Any() ? turmasComTerritorioSaber.Count() : 0;

            var retornoTurmas = new PaginacaoResultadoDto<RetornoConsultaListagemTurmaComponenteDto>()
            {
                Items = turmasComTerritorioSaber,
                TotalRegistros = totalRegistros,
                TotalPaginas = (int)Math.Ceiling((double)totalRegistros / request.QtdeRegistros)
            };

            return retornoTurmas;*/
        }

        /* private async Task<IEnumerable<RetornoConsultaListagemTurmaComponenteDto>> TratarComponentesTerritorioSaber(IEnumerable<RetornoConsultaListagemTurmaComponenteDto> listagemTurmasComponentes)
         {
             var componentesApiEol = await componenteCurricularService.ObterComponentesCurricularesAPIEol();

             var turmasComponentes = listagemTurmasComponentes.ToList();

             foreach (var turmaComponentes in turmasComponentes
                 .Where(a => componentesApiEol.Any(c => c.IdComponenteCurricular == a.ComponenteCurricularCodigo && c.EhTerritorio))
                 .GroupBy(a => a.TurmaCodigo))
             {
                 var territoriosBanco = await funcionarioRepository.BuscarDisciplinaTerritorioDosSaberesAsync(turmaComponentes.Key.ToString(), turmaComponentes.Select(a => a.ComponenteCurricularCodigo));
                 if (territoriosBanco != null && territoriosBanco.Any())
                 {
                     var turma = turmaComponentes.First();
                     turmasComponentes.RemoveAll(c => territoriosBanco.Any(x => x.CodigoComponenteCurricular == c.ComponenteCurricularCodigo));

                     var territorios = territoriosBanco.GroupBy(c => new { c.CodigoTerritorioSaber, c.CodigoExperienciaPedagogica, c.DataInicio });

                     foreach (var componenteTerritorio in territorios)
                     {
                         var componenteCurricular = turmaComponentes.FirstOrDefault(c => c.ComponenteCurricularCodigo == componenteTerritorio.First().CodigoComponenteCurricular);

                         var componenteCurricularCodigo = componenteTerritorio.FirstOrDefault().ObterCodigoComponenteCurricular(turmaComponentes.Key.ToString());

                         turmasComponentes.Add(new RetornoConsultaListagemTurmaComponenteDto()
                         {
                             ComponenteCurricularCodigo = componenteCurricularCodigo,
                             ComponenteCurricularTerritorioSaberCodigo = componenteTerritorio.FirstOrDefault().CodigoComponenteCurricular,
                             NomeComponenteCurricular = componenteTerritorio.FirstOrDefault().ObterDescricaoComponenteCurricular(),
                             TerritorioSaber = true,
                             Ano = turma.Ano,
                             Id = (turmasComponentes.Where(a => a.TurmaCodigo == turmaComponentes.Key).Count() + 1).ToString(),
                             Modalidade = turma.Modalidade,
                             NomeTurma = turma.NomeTurma,
                             TurmaCodigo = turma.TurmaCodigo,
                             Turno = turma.Turno,
                             ComplementoTurmaEJA = componenteCurricular.ComplementoTurmaEJA
                         });
                     }
                 }
             }
             listagemTurmasComponentes = turmasComponentes;
             return listagemTurmasComponentes;
         }*/
    }
}