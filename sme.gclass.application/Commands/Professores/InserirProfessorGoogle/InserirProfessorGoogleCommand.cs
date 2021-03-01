using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirProfessorGoogleCommand : IRequest<bool>
    {
        public ProfessorGoogle ProfessorGoogle { get; set; }

        public InserirProfessorGoogleCommand(ProfessorGoogle professorGoogle)
        {
            ProfessorGoogle = professorGoogle;
        }
    }

    public class InserirProfessorGoogleCommandValidator : AbstractValidator<InserirProfessorGoogleCommand>
    {
        public InserirProfessorGoogleCommandValidator()
        {
            RuleFor(x => x.ProfessorGoogle)
                .NotEmpty()
                .WithMessage("É necessário informar o professor que será incluído no Google Classroom.");
        }
    }
}