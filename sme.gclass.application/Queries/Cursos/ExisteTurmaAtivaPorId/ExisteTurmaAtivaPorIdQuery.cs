using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteTurmaAtivaPorIdQuery : IRequest<bool>
    {
        public ExisteTurmaAtivaPorIdQuery(long turmaId)
        {
            TurmaId = turmaId;
        }

        public long TurmaId { get; set; }
    }

    public class ExisteTurmaAtivaPorIdQueryValidator : AbstractValidator<ExisteTurmaAtivaPorIdQuery>
    {
        public ExisteTurmaAtivaPorIdQueryValidator()
        {
            RuleFor(x => x.TurmaId)
                .NotEmpty()
                .WithMessage("O id da turma deve ser informado.");
        }
    }
}
