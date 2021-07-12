using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosComResponsaveisPorAnoQuery : IRequest<IEnumerable<CursoResponsavelDto>>
    {
        public ObterCursosComResponsaveisPorAnoQuery(int anoLetivo)
        {
            AnoLetivo = anoLetivo;
        }

        public int AnoLetivo { get; }
    }

    public class ObterCursosComResponsaveisPorAnoQueryValidator : AbstractValidator<ObterCursosComResponsaveisPorAnoQuery>
    {
        public ObterCursosComResponsaveisPorAnoQueryValidator()
        {
            RuleFor(a => a.AnoLetivo)
                .NotEmpty()
                .WithMessage("O ano deve ser informado para consulta de turmas");
        }
    }
}
