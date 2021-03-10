using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresDoCursoParaIncluirGoogleQuery : IRequest<IEnumerable<ProfessorCursoEol>>
    {
        public int AnoLetivo { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }

        public ObterProfessoresDoCursoParaIncluirGoogleQuery(int anoLetivo, long turmaId, long componenteCurricularId)
        {
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }
    }

    public class ObterProfessoresDoCursoParaIncluirGoogleQueryValidator : AbstractValidator<ObterProfessoresDoCursoParaIncluirGoogleQuery>
    {
        public ObterProfessoresDoCursoParaIncluirGoogleQueryValidator()
        {
            RuleFor(x => x.AnoLetivo)
                .NotEmpty()
                .WithMessage("O ano letivo do curso deve ser informado.");

            RuleFor(x => x.TurmaId)
                .NotEmpty()
                .WithMessage("A turma do curso deve ser informado.");

            RuleFor(x => x.ComponenteCurricularId)
                .NotEmpty()
                .WithMessage("O componente curricular do curso deve ser informado.");
        }
    }
}