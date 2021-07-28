using FluentValidation;
using MediatR;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterIdsCursosPorTurmaQuery : IRequest<IEnumerable<long>>
    {
        public ObterIdsCursosPorTurmaQuery(long turmaId)
        {
            TurmaId = turmaId;
        }

        public long TurmaId { get; }
    }

    public class ObterIdsCursosPorTurmaQueryValidator : AbstractValidator<ObterIdsCursosPorTurmaQuery>
    {
        public ObterIdsCursosPorTurmaQueryValidator()
        {
            RuleFor(a => a.TurmaId)
                .NotEmpty()
                .WithMessage("O código da turma deve ser informado para consulta de seus cursos");
        }
    }
}
