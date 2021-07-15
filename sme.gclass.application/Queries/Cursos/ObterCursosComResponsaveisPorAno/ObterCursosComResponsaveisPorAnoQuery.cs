using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosComResponsaveisPorAnoQuery : IRequest<IEnumerable<CursoUsuarioDto>>
    {
        public ObterCursosComResponsaveisPorAnoQuery(int anoLetivo, long? cursoId = null)
        {
            AnoLetivo = anoLetivo;
            CursoId = cursoId;
        }

        public int AnoLetivo { get; }
        public long? CursoId { get; }
    }

    public class ObterCursosPorAnoQueryValidator : AbstractValidator<ObterCursosComResponsaveisPorAnoQuery>
    {
        public ObterCursosPorAnoQueryValidator()
        {
            RuleFor(a => a.AnoLetivo)
                .NotEmpty()
                .WithMessage("O ano deve ser informado para consulta de turmas");
        }
    }
}
