using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirProfessorCursoGoogleCommand : IRequest<bool>
    {
        public InserirProfessorCursoGoogleCommand(long cursoId, string email)
        {
            CursoId = cursoId;
            Email = email;
        }

        public long CursoId { get; set; }
        public string Email { get; set; }
    }
    public class InserirProfessorCursoGoogleCommandValidator : AbstractValidator<InserirProfessorCursoGoogleCommand>
    {
        public InserirProfessorCursoGoogleCommandValidator()
        {
            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("O identificador do curso deve ser informado para a inclusão do professor no curso no Google Classroom.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail do professor deve ser informado para a inclusão do professor no curso no Google Classroom.");
        }
    }
}
