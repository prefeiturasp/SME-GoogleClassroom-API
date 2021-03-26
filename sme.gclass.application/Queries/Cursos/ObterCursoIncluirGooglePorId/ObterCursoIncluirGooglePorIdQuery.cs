using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoIncluirGooglePorIdQuery : IRequest<CursoEol>
    {
        public ObterCursoIncluirGooglePorIdQuery(long turmaId, long componenteCurricularId, int anoLetivo)
        {
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            AnoLetivo = anoLetivo;
        }

        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public int AnoLetivo { get; set; }
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

            RuleFor(x => x.AnoLetivo)
                .NotEmpty()
                .WithMessage("O ano letivo deve ser informado.");
        }
    }
}
