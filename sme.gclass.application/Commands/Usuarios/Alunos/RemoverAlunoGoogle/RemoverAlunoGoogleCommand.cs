using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RemoverAlunoGoogleCommand : IRequest<bool>
    {
        public string Email { get; set; }

        public RemoverAlunoGoogleCommand(string email)
        {
            Email = email;
        }
    }

    public class RemoverAlunoGoogleCommandValidator : AbstractValidator<RemoverAlunoGoogleCommand>
    {
        public RemoverAlunoGoogleCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("É necessário informar o email do aluno que será removido no Google Classroom.");
        }
    }
}