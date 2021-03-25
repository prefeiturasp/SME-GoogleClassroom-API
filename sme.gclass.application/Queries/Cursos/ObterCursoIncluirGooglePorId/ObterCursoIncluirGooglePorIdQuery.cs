using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoIncluirGooglePorIdQuery : IRequest<CursoEol>
    {
        public ObterCursoIncluirGooglePorIdQuery(long turmaId, long componenteCurricularId)
        {
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }

        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
    }
    public class ObterCursoIncluirGooglePorIdQueryValidator : AbstractValidator<ObterCursoIncluirGooglePorIdQuery>
    {
        public ObterCursoIncluirGooglePorIdQueryValidator()
        {
            RuleFor(x => x.TurmaId)
                .NotEmpty()
                .WithMessage("O id da turma deve ser informado.");

            RuleFor(x => x.ComponenteCurricularId)
                .NotEmpty()
                .WithMessage("O id do componente curricular deve ser informado.");
        }
    }
}
