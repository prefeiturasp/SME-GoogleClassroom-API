using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirCursoUsuarioCommand : IRequest<long>
    {
        public IncluirCursoUsuarioCommand(long usuarioId, long cursoId)
        {
            UsuarioId = usuarioId;
            CursoId = cursoId;
        }

        public long UsuarioId { get; set; }
        public long CursoId { get; set; }
    }

    public class IncluirCursoUsuarioCommandValidator : AbstractValidator<IncluirCursoUsuarioCommand>
    {
        public IncluirCursoUsuarioCommandValidator()
        {
            RuleFor(x => x.UsuarioId)
                .NotEmpty()
                .WithMessage("O id do usuario deve ser informado.");

            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("O id do curso deve ser informado.");
        }
    }
}
