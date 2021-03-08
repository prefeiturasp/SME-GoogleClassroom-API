using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteProfessorCursoGoogleQuery : IRequest<bool>
    {
        public ExisteProfessorCursoGoogleQuery(long ususarioId, long cursoId)
        {
            UsusarioId = ususarioId;
            CursoId = cursoId;
        }

        public long UsusarioId { get; set; }
        public long CursoId { get; set; }
    }

    public class ExisteProfessorCursoGoogleQueryValidator : AbstractValidator<ExisteProfessorCursoGoogleQuery>
    {
        public ExisteProfessorCursoGoogleQueryValidator()
        {
            RuleFor(x => x.UsusarioId)
                .NotEmpty()
                .WithMessage("o id do professor deve ser informado.");

            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("o id do curso deve ser informado.");
        }
    }
}
