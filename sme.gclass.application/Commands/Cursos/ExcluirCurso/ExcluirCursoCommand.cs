using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExcluirCursoCommand : IRequest<bool>
    {
        public long CursoId { get; set; }

        public ExcluirCursoCommand(long cursoId)
        {
            CursoId = cursoId;
        }
    }

    public class ExcluirCursoCommandValidator : AbstractValidator<ExcluirCursoCommand>
    {
        public ExcluirCursoCommandValidator()
        {
            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("O curso deve ser informado para exclusão do curso.");
        }
    }
}