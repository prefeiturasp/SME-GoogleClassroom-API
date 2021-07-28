using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RemoverUsuarioCursoGoogleCommand : IRequest<bool>
    {
        public RemoverUsuarioCursoGoogleCommand(UsuarioCursoGoogleDto usuarioCursoGoogle)
        {
            UsuarioCursoGoogle = usuarioCursoGoogle;
        }

        public UsuarioCursoGoogleDto UsuarioCursoGoogle { get; set; }
    }

    public class RemoverAlunoCursoGoogleCommandValidator : AbstractValidator<RemoverUsuarioCursoGoogleCommand>
    {
        public RemoverAlunoCursoGoogleCommandValidator()
        {
            RuleFor(x => x.UsuarioCursoGoogle)
                .NotEmpty()
                .WithMessage("É necessário informar um usuário x curso que será removido no Google Classroom.");
        }
    }
}
