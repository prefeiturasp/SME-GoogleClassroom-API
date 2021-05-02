using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteUsuarioGsaPorIdQuery : IRequest<bool>
    {
        public string CursoId { get; set; }

        public ExisteUsuarioGsaPorIdQuery(string cursoId)
        {
            CursoId = cursoId;
        }
    }

    public class ExisteUsuarioGsaPorIdQueryValidator : AbstractValidator<ExisteUsuarioGsaPorIdQuery>
    {
        public ExisteUsuarioGsaPorIdQueryValidator()
        {
            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("O identificador do curso deve ser informado.");
        }
    }
}