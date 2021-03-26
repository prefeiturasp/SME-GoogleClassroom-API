using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExcluirUsuarioErroCommand : IRequest<bool>
    {
        public long UsuarioErroId { get; set; }

        public ExcluirUsuarioErroCommand(long usuarioErroId)
        {
            UsuarioErroId = usuarioErroId;
        }
    }

    public class ExcluirUsuarioErroCommandValidator : AbstractValidator<ExcluirUsuarioErroCommand>
    {
        public ExcluirUsuarioErroCommandValidator()
        {
            RuleFor(x => x.UsuarioErroId)
                .NotEmpty()
                .WithMessage("É necessário informar o id do erro do usuário.");
        }
    }
}