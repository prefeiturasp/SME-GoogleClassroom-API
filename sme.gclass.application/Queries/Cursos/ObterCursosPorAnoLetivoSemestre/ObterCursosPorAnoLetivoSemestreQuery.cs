using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosPorAnoLetivoSemestreQuery: IRequest<IEnumerable<CursoEolDto>>
    {
        public ObterCursosPorAnoLetivoSemestreQuery(int anoLetivo, int? semestre = 0)
        {
            AnoLetivo = anoLetivo;
            Semestre = semestre;
        }

        public int AnoLetivo { get; set; }
        public int? Semestre { get; set; }
    }

    public class ObterCursosPorAnoSemestreQueryValidator : AbstractValidator<ObterCursosPorAnoLetivoSemestreQuery>
    {
        public ObterCursosPorAnoSemestreQueryValidator()
        {
            RuleFor(a => a.AnoLetivo)
                .NotEmpty()
                .WithMessage("O Ano deve ser informada");
        }
    }
}
