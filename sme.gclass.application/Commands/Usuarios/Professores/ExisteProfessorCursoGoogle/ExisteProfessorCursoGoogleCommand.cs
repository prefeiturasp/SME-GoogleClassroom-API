using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao.Commands.Usuarios.Professores.ObterProfessorCursoGoogle
{
    public class ExisteProfessorCursoGoogleCommand : IRequest<bool>
    {
        public long CursoId { get; set; }
        public string Email { get; set; }

        public ExisteProfessorCursoGoogleCommand(long cursoId, string email)
        {
            CursoId = cursoId;
            Email = email;
        }
    }

    public class ExisteProfessorCursoGoogleCommandValidator : AbstractValidator<ExisteProfessorCursoGoogleCommand>
    {
        public ExisteProfessorCursoGoogleCommandValidator()
        {
            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("O curso deve ser informado para verificar o professor.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail do professor deve ser informado para verificação com o curso.");
        }
    }
}
