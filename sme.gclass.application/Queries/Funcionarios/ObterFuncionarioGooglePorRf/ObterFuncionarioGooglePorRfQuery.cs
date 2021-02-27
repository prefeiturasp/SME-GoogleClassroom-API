using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionarioGooglePorRfQuery : IRequest<IEnumerable<UsuarioDto>>
    {
        public ObterFuncionarioGooglePorRfQuery(long[] rfs)
        {
            Rfs = rfs;
        }

        public long[] Rfs { get; set; }
    }
    public class ObterFuncionarioGooglePorRfQueryValidator : AbstractValidator<ObterFuncionarioGooglePorRfQuery>
    {
        public ObterFuncionarioGooglePorRfQueryValidator()
        {
            RuleFor(c => c.Rfs)
                .NotEmpty()
                .WithMessage("O RF deve ser informado.");
        }
    }
}
