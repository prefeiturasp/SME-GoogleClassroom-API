using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RemoverProfessorCursoGoogleCommand : IRequest<bool>
    {
        public long CursoId { get; set; }
        public string Email { get; set; }

        public RemoverProfessorCursoGoogleCommand(long cursoId, string email)
        {
            CursoId = cursoId;
            Email = email;
        }
    }

    public class RemoverProfessorCursoGoogleCommandValidator : AbstractValidator<RemoverProfessorCursoGoogleCommand>
    {
        public RemoverProfessorCursoGoogleCommandValidator()
        {
            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("O curso deve ser informado para remover o professor.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail do professor deve ser informado para removê-lo do curso.");
        }
    }
}