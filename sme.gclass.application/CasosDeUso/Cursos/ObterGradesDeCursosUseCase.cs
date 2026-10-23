using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Curso;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterGradesDeCursosUseCase : IObterGradesDeCursosUseCase
    {
        private readonly IMediator mediator;

        public ObterGradesDeCursosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<GradeCursoEolDto>> Executar(FiltroObterGradesDeCursosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);

            var parametros = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));
            var grades = await mediator.Send(new ObterGradesDeCursosQuery(filtro.DataReferencia, paginacao, filtro.TurmaId, filtro.ComponenteCurricularId, parametros));


            return new PaginacaoResultadoDto<GradeCursoEolDto>
            {
                Items = grades.Items.Select(g => new GradeCursoEolDto
                {
                    Nome = g.Nome,
                    Secao = g.Secao,
                    ComponenteCurricularId = g.ComponenteCurricularId,
                    TurmaId = g.TurmaId,
                    UeCodigo = g.UeCodigo,
                    DataInicioGrade = g.DataInicioGrade,
                    Email = g.Email
                }),
                TotalRegistros = grades.TotalRegistros,
                TotalPaginas = grades.TotalPaginas
            };
        }
    }
}