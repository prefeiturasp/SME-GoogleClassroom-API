using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresParaRemoverCursoQuery : IRequest<IEnumerable<RemoverAtribuicaoProfessorCursoEolDto>>
    {
        public ObterProfessoresParaRemoverCursoQuery(string turmaId, DateTime dataInicio, DateTime dataFim)
        {
            TurmaId = turmaId;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }

        public string TurmaId { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
    }

    public class ObterProfessoresParaRemoverCursoQueryValidator : AbstractValidator<ObterProfessoresParaRemoverCursoQuery>
    {
        public ObterProfessoresParaRemoverCursoQueryValidator()
        {
            RuleFor(a => a.DataInicio)
                .NotEmpty()
                .WithMessage("A data de início de vigência deve ser informada para consulta de atribuições de professores a remover");

            RuleFor(a => a.DataFim)
                .NotEmpty()
                .WithMessage("A data de fim de vigência deve ser informada para consulta de atribuições de professores a remover");
        }
    }
}
