using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteTurmaPorCodigoQuery : IRequest<bool>
    {
        public ExisteTurmaPorCodigoQuery(long turmaId)
        {
            TurmaId = turmaId;
        }

        public long TurmaId { get; set; }
    }

    public class ExisteTurmaPorCodigoQueryValidator : AbstractValidator<ExisteTurmaPorCodigoQuery>
    {
        public ExisteTurmaPorCodigoQueryValidator()
        {
            RuleFor(x => x.TurmaId)
                .NotEmpty()
                .WithMessage("O id da turma deve ser informado.");
        }
    }
}
