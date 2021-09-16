using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InativarAlunoGoogleCommand : IRequest<bool>
    {
        public string Email { get; set; }

        public InativarAlunoGoogleCommand(string email)
        {
            Email = email;
        }
    }

    public class InativarAlunoGoogleCommandValidator : AbstractValidator<InativarAlunoGoogleCommand>
    {
        public InativarAlunoGoogleCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("É necessário informar o email do aluno que será inativado no Google Classroom.");
        }
    }
}