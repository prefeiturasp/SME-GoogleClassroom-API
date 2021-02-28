using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosGooglePorRfsQuery : IRequest<IEnumerable<UsuarioDto>>
    {
        public ObterFuncionariosGooglePorRfsQuery(long[] rfs)
        {
            Rfs = rfs;
        }

        public long[] Rfs { get; set; }
    }
    public class ObterFuncionariosGooglePorRfsQueryValidator : AbstractValidator<ObterFuncionariosGooglePorRfsQuery>
    {
        public ObterFuncionariosGooglePorRfsQueryValidator()
        {
            RuleFor(c => c.Rfs)
                .NotEmpty()
                .WithMessage("Informe ao menos 1 RF.");
        }
    }
}
