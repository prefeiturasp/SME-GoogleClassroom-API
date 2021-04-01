using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteFuncionarioCursoGoogleQuery : IRequest<bool>
    {
        public ExisteFuncionarioCursoGoogleQuery(long ususarioId, long cursoId)
        {
            UsusarioId = ususarioId;
            CursoId = cursoId;
        }

        public long UsusarioId { get; set; }
        public long CursoId { get; set; }
    }
    public class ExisteFuncionarioCursoGoogleQueryValidator : AbstractValidator<ExisteFuncionarioCursoGoogleQuery>
    {
        public ExisteFuncionarioCursoGoogleQueryValidator()
        {
            RuleFor(x => x.UsusarioId)
                .NotEmpty()
                .WithMessage("o id do funcionário deve ser informado.");

            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("o id do curso deve ser informado.");
        }
    }
}
