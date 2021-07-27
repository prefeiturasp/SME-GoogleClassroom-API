using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtribuirDonoCursoGoogleCommand : IRequest<bool>
    {
        public AtribuirDonoCursoGoogleCommand(long cursoId, string usuarioId)
        {
            CursoId = cursoId;
            UsuarioId = usuarioId;
        }
        public long CursoId { get; set; }
        public string UsuarioId { get; set; }
    }

    public class AtribuirDonoCursoGoogleCommandValidator : AbstractValidator<AtribuirDonoCursoGoogleCommand>
    {
        public AtribuirDonoCursoGoogleCommandValidator()
        {
            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("O curso deve ser informado para atribuir o dono.");
            RuleFor(x => x.UsuarioId)
                .NotEmpty()
                .WithMessage("O usuario deve ser informado para atribuir o dono.");
        }
    }
}
