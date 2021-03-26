using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExcluirCursoErroCommand : IRequest<bool>
    {
        public ExcluirCursoErroCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }

    public class ExcluirCursoErroCommandValidator : AbstractValidator<ExcluirCursoErroCommand>
    {
        public ExcluirCursoErroCommandValidator()
        {

            RuleFor(c => c.Id)
                   .NotEmpty()
                   .WithMessage("O id do curso erro deve ser informado para exclusão.");
        }
    }
}
