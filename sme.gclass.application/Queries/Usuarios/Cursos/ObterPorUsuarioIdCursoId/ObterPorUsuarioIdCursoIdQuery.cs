using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterPorUsuarioIdCursoIdQuery : IRequest<CursoUsuario>
    {
        public long CursoId { get; set; }
        public long UsuarioId { get; set; }

        public ObterPorUsuarioIdCursoIdQuery(long usuarioId, long cursoId)
        {
            CursoId = cursoId;
            UsuarioId = usuarioId;
        }
    }

    public class ObterPorUsuarioIdCursoIdQueryValidator : AbstractValidator<ObterPorUsuarioIdCursoIdQuery>
    {
        public ObterPorUsuarioIdCursoIdQueryValidator()
        {
            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("O curso deve ser informado para busca.");

            RuleFor(x => x.UsuarioId)
                .NotEmpty()
                .WithMessage("O usuário deve ser informado para busca.");
        }
    }
}