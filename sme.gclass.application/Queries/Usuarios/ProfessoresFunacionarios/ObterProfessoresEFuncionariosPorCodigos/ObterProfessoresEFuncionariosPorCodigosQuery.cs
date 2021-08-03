using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresEFuncionariosPorCodigosQuery : IRequest<IEnumerable<ProfessorGoogle>>
    {
        public ObterProfessoresEFuncionariosPorCodigosQuery(long codigo)
        {
            ProfessoresEFuncionariosCodigo = new long[] { codigo };
        }
        public ObterProfessoresEFuncionariosPorCodigosQuery(long[] codigos)
        {
            ProfessoresEFuncionariosCodigo = codigos;
        }

        public long[] ProfessoresEFuncionariosCodigo { get; set; }
    }

    public class ObterProfessoresEFuncionariosPorCodigosQueryValidator : AbstractValidator<ObterProfessoresEFuncionariosPorCodigosQuery>
    {
        public ObterProfessoresEFuncionariosPorCodigosQueryValidator()
        {
            RuleFor(c => c.ProfessoresEFuncionariosCodigo)
               .NotEmpty()
               .WithMessage("Ao menos um codigo de professor ou funcionário deve ser informado. ");
        }
    }
}
