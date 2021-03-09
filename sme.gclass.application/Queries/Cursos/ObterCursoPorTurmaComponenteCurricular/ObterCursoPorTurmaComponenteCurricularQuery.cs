using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoPorTurmaComponenteCurricularQuery : IRequest<Curso>
    {
        public ObterCursoPorTurmaComponenteCurricularQuery(long turmaId, long componenteCurricularId)
        {
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }

        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
    }

    public class ObterCursoPorTurmaComponenteCurricularQueryValidator : AbstractValidator<ObterCursoPorTurmaComponenteCurricularQuery>
    {
        public ObterCursoPorTurmaComponenteCurricularQueryValidator()
        {
            RuleFor(c => c.TurmaId)
               .NotEmpty()
               .WithMessage("O id da turma deve ser informado.");

            RuleFor(c => c.ComponenteCurricularId)
               .NotEmpty()
               .WithMessage("O id do componente curricular deve ser informado.");
        }
    }
}
