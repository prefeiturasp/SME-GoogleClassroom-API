using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InativarProfessorGoogleCommand : IRequest<bool>
    {
        public string Email { get; set; }

        public InativarProfessorGoogleCommand(string email)
        {
            Email = email;
        }
    }

    public class InativarProfessorGoogleCommandValidator : AbstractValidator<InativarAlunoGoogleCommand>
    {
        public InativarProfessorGoogleCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("É necessário informar o email do professor que será inativado no Google Classroom.");
        }
    }
}