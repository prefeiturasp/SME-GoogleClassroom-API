using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirProfessorCursoGoogleCommand : IRequest<bool>
    {
        public InserirProfessorCursoGoogleCommand(ProfessorCursoGoogle professorCursoGoogle)
        {
            ProfessorCursoGoogle = professorCursoGoogle;
        }

        public ProfessorCursoGoogle ProfessorCursoGoogle { get; set; }
    }
    public class InserirProfessorCursoGoogleCommandValidator : AbstractValidator<InserirProfessorCursoGoogleCommand>
    {
        public InserirProfessorCursoGoogleCommandValidator()
        {
            RuleFor(x => x.ProfessorCursoGoogle)
                .NotEmpty()
                .WithMessage("É necessário informar um professor x curso que será incluído no Google Classroom.");
        }
    }
}
