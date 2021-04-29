using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RemoverCursoUsuarioCommand : IRequest<bool>
    {
        public long CursoUsuarioId { get; set; }

        public RemoverCursoUsuarioCommand(long cursoUsuarioId)
        {
            CursoUsuarioId = cursoUsuarioId;
        }
    }

    public class RemoverCursoUsuarioCommandValidator : AbstractValidator<RemoverCursoUsuarioCommand>
    {
        public RemoverCursoUsuarioCommandValidator()
        {
            RuleFor(x => x.CursoUsuarioId)
                .NotEmpty()
                .WithMessage("O identificador da atribuição do usuário no curso deve ser informada.");
        }
    }
}