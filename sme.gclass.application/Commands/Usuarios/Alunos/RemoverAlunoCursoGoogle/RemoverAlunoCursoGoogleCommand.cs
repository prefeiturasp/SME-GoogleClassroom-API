using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RemoverAlunoCursoGoogleCommand : IRequest<bool>
    {
        public RemoverAlunoCursoGoogleCommand(UsuarioCursoGoogleDto alunoCursoGoogle)
        {
            AlunoCursoGoogle = alunoCursoGoogle;
        }

        public UsuarioCursoGoogleDto AlunoCursoGoogle { get; set; }
    }

    public class RemoverAlunoCursoGoogleCommandValidator : AbstractValidator<RemoverAlunoCursoGoogleCommand>
    {
        public RemoverAlunoCursoGoogleCommandValidator()
        {
            RuleFor(x => x.AlunoCursoGoogle)
                .NotEmpty()
                .WithMessage("É necessário informar um aluno x curso que será incluído no Google Classroom.");
        }
    }
}
