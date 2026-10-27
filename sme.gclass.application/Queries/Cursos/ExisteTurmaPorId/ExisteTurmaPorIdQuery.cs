using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteTurmaPorIdQuery : IRequest<bool>
    {
        public ExisteTurmaPorIdQuery(long turmaId)
        {
            TurmaId = turmaId;
        }

        public long TurmaId { get; set; }
    }

    public class ExisteTurmaPorIdQueryValidator : AbstractValidator<ExisteTurmaPorIdQuery>
    {
        public ExisteTurmaPorIdQueryValidator()
        {
            RuleFor(x => x.TurmaId)
                .NotEmpty()
                .WithMessage("O id da turma deve ser informado.");
        }
    }
}
