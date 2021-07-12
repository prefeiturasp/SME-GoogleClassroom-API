using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosPorAnoQuery : IRequest<IEnumerable<CursoDto>>
    {
        public ObterCursosPorAnoQuery(int anoLetivo)
        {
            AnoLetivo = anoLetivo;
        }

        public int AnoLetivo { get; }
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
