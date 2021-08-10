using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosDoProfessorParaIncluirGoogleQuery : IRequest<IEnumerable<ProfessorCursoEol>>
    {
        public long Rf { get; set; }
        public int AnoLetivo { get; set; }
        public ParametrosCargaInicialDto ParametrosCargaInicialDto { get; set; }

        public ObterCursosDoProfessorParaIncluirGoogleQuery(long rf, int anoLetivo, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            Rf = rf;
            AnoLetivo = anoLetivo;
            ParametrosCargaInicialDto = parametrosCargaInicialDto;
        }
    }

    public class ObterCursosDoProfessorParaIncluirGoogleQueryValidator : AbstractValidator<ObterCursosDoProfessorParaIncluirGoogleQuery>
    {
        public ObterCursosDoProfessorParaIncluirGoogleQueryValidator()
        {
            RuleFor(x => x.ParametrosCargaInicialDto)
                .NotEmpty()
                .WithMessage("A configuração de parâmetros deve ser informada.");

            RuleFor(x => x.Rf)
                .NotEmpty()
                .WithMessage("O Rf do professor deve ser informado.");

            RuleFor(x => x.AnoLetivo)
                .NotEmpty()
                .WithMessage("O ano letivo dos cursos deve ser informado.");
        }
    }
}