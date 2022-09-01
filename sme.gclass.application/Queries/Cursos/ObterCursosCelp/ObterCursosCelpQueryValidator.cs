using FluentValidation;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosCelpQueryValidator : AbstractValidator<ObterCursosCelpQuery>
    {
        public ObterCursosCelpQueryValidator()
        {
            RuleFor(c => c.Componentes)
                .NotNull()
                .WithMessage("Os componentes curriculares devem ser informados para obter os cursos CELP.");

            RuleFor(c => c.AnoLetivo)
                .GreaterThan(0)
                .WithMessage("O ano letivo deve ser informado para obter os cursos CELP.");
        }
    }
}