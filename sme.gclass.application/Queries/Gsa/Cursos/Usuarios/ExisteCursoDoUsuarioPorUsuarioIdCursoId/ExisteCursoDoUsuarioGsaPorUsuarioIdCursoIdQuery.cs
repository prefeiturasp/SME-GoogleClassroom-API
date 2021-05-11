using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteCursoDoUsuarioGsaPorUsuarioIdCursoIdQuery : IRequest<bool>
    {
        public string UsuarioId { get; set; }
        public string CursoId { get; set; }

        public ExisteCursoDoUsuarioGsaPorUsuarioIdCursoIdQuery(string usuarioId, string cursoId)
        {
            UsuarioId = usuarioId;
            CursoId = cursoId;
        }
    }

    public class ExisteCursoDoUsuarioPorUsuarioIdCursoIdQueryValidator : AbstractValidator<ExisteCursoDoUsuarioGsaPorUsuarioIdCursoIdQuery>
    {
        public ExisteCursoDoUsuarioPorUsuarioIdCursoIdQueryValidator()
        {
            RuleFor(x => x.UsuarioId)
                .NotEmpty()
                .WithMessage("O identificador do usuário deve ser informado.");

            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("O identificador do curso deve ser informado.");
        }
    }
}