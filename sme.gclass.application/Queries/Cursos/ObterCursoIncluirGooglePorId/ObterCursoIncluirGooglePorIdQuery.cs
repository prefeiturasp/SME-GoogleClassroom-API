using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoIncluirGooglePorIdQuery : IRequest<CursoEol>
    {
        public ObterCursoIncluirGooglePorIdQuery(long turmaId, long componenteCurricularId, int anoLetivo, Infra.ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            AnoLetivo = anoLetivo;
            ParametrosCargaInicialDto = parametrosCargaInicialDto;
        }

        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public int AnoLetivo { get; set; }
        public ParametrosCargaInicialDto ParametrosCargaInicialDto { get; set; }        
    }

    public class ObterCursoIncluirGooglePorIdQueryValidator : AbstractValidator<ObterCursoIncluirGooglePorIdQuery>
    {
        public ObterCursoIncluirGooglePorIdQueryValidator()
        {
            RuleFor(x => x.ParametrosCargaInicialDto)
                .NotEmpty()
                .WithMessage("A configuração de parâmetros deve ser informada.");

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
