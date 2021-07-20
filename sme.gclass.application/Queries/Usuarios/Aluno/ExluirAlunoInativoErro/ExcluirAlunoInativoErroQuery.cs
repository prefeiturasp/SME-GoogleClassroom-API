using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExluirAlunoInativoErroQuery : IRequest<bool>
    {
        public long UsuarioId { get; set; }

        public ExluirAlunoInativoErroQuery(long usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }
    
    public class ExluirAlunoInativoErroQueryValidator : AbstractValidator<ExluirAlunoInativoErroQuery>
    {
        public ExluirAlunoInativoErroQueryValidator()
        {
            RuleFor(c => c.UsuarioId)
                .NotEmpty()
                .WithMessage("O id do usuario deve ser informado.");
        }
    }
    
}