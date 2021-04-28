using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtualizarUsuarioGoogleClassroomIdCommand : IRequest<bool>
    {
        public long UsuarioId { get; set; }
        public string GoogleClassroomId { get; set; }

        public AtualizarUsuarioGoogleClassroomIdCommand(long usuarioId, string googleClassroomId)
        {
            UsuarioId = usuarioId;
            GoogleClassroomId = googleClassroomId;
        }
    }

    public class AtualizarUsuarioGoogleClassroomIdCommandValidator : AbstractValidator<AtualizarUsuarioGoogleClassroomIdCommand>
    {
        public AtualizarUsuarioGoogleClassroomIdCommandValidator()
        {
            RuleFor(x => x.UsuarioId)
                .NotEmpty()
                .WithMessage("O identificador do usuário deve ser informado para atualização do GoogleClassroomId.");

            RuleFor(x => x.GoogleClassroomId)
                .NotEmpty()
                .WithMessage("O identificador do GoogleClassroom deve ser informado para atualização.");
        }
    }
}