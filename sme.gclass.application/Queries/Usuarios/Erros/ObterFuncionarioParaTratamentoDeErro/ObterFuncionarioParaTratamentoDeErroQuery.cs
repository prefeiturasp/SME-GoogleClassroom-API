using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionarioParaTratamentoDeErroQuery : IRequest<FuncionarioEol>
    {
        public long Rf { get; set; }

        public ObterFuncionarioParaTratamentoDeErroQuery(long rf)
        {
            Rf = rf;
        }
    }

    public class ObterFuncionarioParaTratamentoDeErroQueryValidator : AbstractValidator<ObterFuncionarioParaTratamentoDeErroQuery>
    {
        public ObterFuncionarioParaTratamentoDeErroQueryValidator()
        {
            RuleFor(x => x.Rf)
                .NotEmpty()
                .WithMessage("O RF do funcionário deve ser informado.");
        }
    }
}