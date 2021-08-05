using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosDoCursoParaIncluirGoogleQuery : IRequest<IEnumerable<AlunoCursoEol>>
    {
        public int AnoLetivo { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public ParametrosCargaInicialDto ParametrosCargaInicialDto { get; set; }

        public ObterAlunosDoCursoParaIncluirGoogleQuery(int anoLetivo, long turmaId, long componenteCurricularId, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            ParametrosCargaInicialDto = parametrosCargaInicialDto;
        }
    }

    public class ObterAlunosDoCursoParaIncluirGoogleQueryValidator : AbstractValidator<ObterAlunosDoCursoParaIncluirGoogleQuery>
    {
        public ObterAlunosDoCursoParaIncluirGoogleQueryValidator()
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