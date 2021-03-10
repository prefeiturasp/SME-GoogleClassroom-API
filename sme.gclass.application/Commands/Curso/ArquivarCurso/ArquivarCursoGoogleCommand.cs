using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ArquivarCursoGoogleCommand : IRequest<bool>
    {
        public long CursoId { get; set; }

        public ArquivarCursoGoogleCommand(long cursoId)
        {
            CursoId = cursoId;
        }
    }

    public class ArquivarCursoCommandValidator : AbstractValidator<ArquivarCursoGoogleCommand>
    {
        public ArquivarCursoCommandValidator()
        {
            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("O curso deve ser informado para arquivar.");
        }
    }
}