using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirAlunoCursoGoogleCommand : IRequest<bool>
    {
        public InserirAlunoCursoGoogleCommand(AlunoCursoGoogle alunoCursoGoogle, string email)
        {
            AlunoCursoGoogle = alunoCursoGoogle;
            Email = email;
        }

        public AlunoCursoGoogle AlunoCursoGoogle { get; set; }
        public string Email { get; set; }
    }

    public class InserirAlunoCursoGoogleCommandValidator : AbstractValidator<InserirAlunoCursoGoogleCommand>
    {
        public InserirAlunoCursoGoogleCommandValidator()
        {
            RuleFor(x => x.AlunoCursoGoogle)
                .NotEmpty()
                .WithMessage("É necessário informar um aluno x curso que será incluído no Google Classroom.");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail do aluno deve ser informado.");
        }
    }
}
