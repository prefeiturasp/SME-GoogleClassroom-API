using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirProfessorCursoGoogleCommand : IRequest<bool>
    {
        public InserirProfessorCursoGoogleCommand(ProfessorCursoGoogle professorCursoGoogle, string email)
        {
            ProfessorCursoGoogle = professorCursoGoogle;
            Email = email;
        }

        public ProfessorCursoGoogle ProfessorCursoGoogle { get; set; }
        public string Email { get; set; }
    }
    public class InserirProfessorCursoGoogleCommandValidator : AbstractValidator<InserirProfessorCursoGoogleCommand>
    {
        public InserirProfessorCursoGoogleCommandValidator()
        {
            RuleFor(x => x.ProfessorCursoGoogle)
                .NotEmpty()
                .WithMessage("É necessário informar um professor x curso que será incluído no Google Classroom.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail do professor deve ser informado.");
        }
    }
}
