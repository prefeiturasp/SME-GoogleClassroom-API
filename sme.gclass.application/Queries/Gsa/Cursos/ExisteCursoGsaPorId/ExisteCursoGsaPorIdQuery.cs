using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteCursoGsaPorIdQuery : IRequest<bool>
    {
        public long UsuarioId { get; set; }

        public ExisteCursoGsaPorIdQuery(long usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }

    public class ExisteCursoGsaPorIdQueryValidator : AbstractValidator<ExisteCursoGsaPorIdQuery>
    {
        public ExisteCursoGsaPorIdQueryValidator()
        {
            RuleFor(x => x.UsuarioId)
                .NotEmpty()
                .WithMessage("O identificador do usuário deve ser informado.");
        }
    }
}