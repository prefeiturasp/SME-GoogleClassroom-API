using FluentValidation;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosMatriculadosCelpQueryValidator : AbstractValidator<ObterAlunosMatriculadosCelpQuery>
    {
        public ObterAlunosMatriculadosCelpQueryValidator()
        {
            RuleFor(c => c.ComponenteCurricularId)
                .NotNull()
                .WithMessage("O componente deve ser informado para obter os alunos matriculados nos cursos CELP");

            RuleFor(c => c.AnoLetivo)
                .GreaterThan(0)
                .WithMessage("O ano letivo deve ser informado para obter os alunos matriculados nos cursos CELP.");
        }
    }
}