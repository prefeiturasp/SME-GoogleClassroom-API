using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosDoCursoCelpParaIncluirGoogleQuery : IRequest<IEnumerable<FuncionarioCursoEol>>
    {
        public int AnoLetivo { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }

        public ObterFuncionariosDoCursoCelpParaIncluirGoogleQuery(int anoLetivo, long turmaId, long componenteCurricularId)
        {
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }
    }

    public class ObterFuncionariosDoCursoCelpParaIncluirGoogleQueryValidator : AbstractValidator<ObterFuncionariosDoCursoCelpParaIncluirGoogleQuery>
    {
        public ObterFuncionariosDoCursoCelpParaIncluirGoogleQueryValidator()
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