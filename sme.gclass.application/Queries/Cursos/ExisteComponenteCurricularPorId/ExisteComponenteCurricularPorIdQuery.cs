using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteComponenteCurricularPorIdQuery : IRequest<bool>
    {
        public ExisteComponenteCurricularPorIdQuery(long componenteCurricularId)
        {
            ComponenteCurricularId = componenteCurricularId;
        }

        public long ComponenteCurricularId { get; set; }
    }

    public class ExisteComponenteCurricularPorIdQueryValidator : AbstractValidator<ExisteComponenteCurricularPorIdQuery>
    {
        public ExisteComponenteCurricularPorIdQueryValidator()
        {
            RuleFor(x => x.ComponenteCurricularId)
                .NotEmpty()
                .WithMessage("O id do componente curricular deve ser informado.");
        }
    }
}
