using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirProfessorCursoGoogleCommand : IRequest<bool>
    {
        public InserirProfessorCursoGoogleCommand(ProfessorCursoEol professorCursoEol)
        {
            ProfessorCursoEol = professorCursoEol;
        }

        public ProfessorCursoEol ProfessorCursoEol { get; set; }
    }
    public class InserirProfessorCursoGoogleCommandValidator : AbstractValidator<InserirProfessorCursoGoogleCommand>
    {
        public InserirProfessorCursoGoogleCommandValidator()
        {
            RuleFor(x => x.ProfessorCursoEol)
                .NotEmpty()
                .WithMessage("É necessário informar um professor x curso que será incluído no Google Classroom.");
        }
    }
}
