using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteAlunoCursoGoogleQuery : IRequest<bool>
    {
        public ExisteAlunoCursoGoogleQuery(long ususarioId, long cursoId)
        {
            UsusarioId = ususarioId;
            CursoId = cursoId;
        }

        public long UsusarioId { get; set; }
        public long CursoId { get; set; }
    }

    public class ExisteAlunoCursoGoogleQueryValidator : AbstractValidator<ExisteAlunoCursoGoogleQuery>
    {
        public ExisteAlunoCursoGoogleQueryValidator()
        {
            RuleFor(x => x.UsusarioId)
                .NotEmpty()
                .WithMessage("o id do aluno deve ser informado.");

            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("o id do curso deve ser informado.");
        }
    }
}
