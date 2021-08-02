using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresEFuncionariosPorCodigosQuery : IRequest<IEnumerable<ProfessorGoogle>>
    {
        public ObterProfessoresEFuncionariosPorCodigosQuery(string codigo)
        {
            ProfessoresEFuncionariosCodigo = new string[] { codigo };
        }
        public ObterProfessoresEFuncionariosPorCodigosQuery(string[] codigos)
        {
            ProfessoresEFuncionariosCodigo = codigos;
        }

        public string[] ProfessoresEFuncionariosCodigo { get; set; }
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
