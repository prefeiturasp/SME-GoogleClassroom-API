using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteCursoDoUsuarioPorUsuarioIdCursoIdQuery : IRequest<bool>
    {
        public string UsuarioId { get; set; }
        public string CursoId { get; set; }

        public ExisteCursoDoUsuarioPorUsuarioIdCursoIdQuery(string usuarioId, string cursoId)
        {
            UsuarioId = usuarioId;
            CursoId = cursoId;
        }
    }

    public class ExisteCursoDoUsuarioPorUsuarioIdCursoIdQueryValidator : AbstractValidator<ExisteCursoDoUsuarioPorUsuarioIdCursoIdQuery>
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