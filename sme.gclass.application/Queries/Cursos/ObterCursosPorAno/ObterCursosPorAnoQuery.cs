using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosPorAnoQuery : IRequest<(IEnumerable<CursoDto> cursos, int? totalPaginas)>
    {
        public ObterCursosPorAnoQuery(int anoLetivo, long? cursoId, int? pagina = null, int? quantidadeRegistrosPagina = null)
        {
            AnoLetivo = anoLetivo;
            CursoId = cursoId;
            Pagina = pagina;
            QuantidadeRegistrosPagina = quantidadeRegistrosPagina;
        }

        public int AnoLetivo { get; }
        public long? CursoId { get; }
        public int? Pagina { get; set; }
        public int? QuantidadeRegistrosPagina { get; set; }
    }

    public class ObterCursosPorAnoQueryValidator : AbstractValidator<ObterCursosPorAnoQuery>
    {
        public ObterCursosPorAnoQueryValidator()
        {
            RuleFor(a => a.AnoLetivo)
                .NotEmpty()
                .WithMessage("O ano deve ser informado para consulta de cursos");
        }
    }
}
