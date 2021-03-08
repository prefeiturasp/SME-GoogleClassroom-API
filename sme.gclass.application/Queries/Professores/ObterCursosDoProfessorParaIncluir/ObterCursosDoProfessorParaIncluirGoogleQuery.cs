using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosDoProfessorParaIncluirGoogleQuery : IRequest<IEnumerable<ProfessorCursoEol>>
    {
        public long Rf { get; set; }
        public int AnoLetivo { get; set; }

        public ObterCursosDoProfessorParaIncluirGoogleQuery(long rf, int anoLetivo)
        {
            Rf = rf;
            AnoLetivo = anoLetivo;
        }
    }

    public class ObterCursosDoProfessorParaIncluirGoogleQueryValidator : AbstractValidator<ObterCursosDoProfessorParaIncluirGoogleQuery>
    {
        public ObterCursosDoProfessorParaIncluirGoogleQueryValidator()
        {
            RuleFor(x => x.Rf)
                .NotEmpty()
                .WithMessage("O Rf do professor deve ser informado.");

            RuleFor(x => x.AnoLetivo)
                .NotEmpty()
                .WithMessage("O ano letivo dos cursos deve ser informado.");
        }
    }
}