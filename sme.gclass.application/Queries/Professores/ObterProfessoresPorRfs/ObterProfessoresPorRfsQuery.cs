using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresPorRfsQuery : IRequest<IEnumerable<ProfessorGoogle>>
    {
        public ObterProfessoresPorRfsQuery(long rf)
        {
            Rfs = new long[] { rf };            
        }
        public ObterProfessoresPorRfsQuery(long[] rfs)
        {
            Rfs = rfs;
        }

        public long[] Rfs { get; set; }
    }

    public class ObterTurmasComInicioFechamentoQueryValidator : AbstractValidator<ObterProfessoresPorRfsQuery>
    {
        public ObterTurmasComInicioFechamentoQueryValidator()
        {
            RuleFor(c => c.Rfs)
               .NotEmpty()
               .WithMessage("Os Rfs dos professores devem ser informados. ");
        }
    }
}