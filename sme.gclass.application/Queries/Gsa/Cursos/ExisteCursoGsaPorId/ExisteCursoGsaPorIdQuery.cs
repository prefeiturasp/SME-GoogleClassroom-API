using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteCursoGsaPorIdQuery : IRequest<bool>
    {
        public string UsuarioId { get; set; }

        public ExisteCursoGsaPorIdQuery(string usuarioId)
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