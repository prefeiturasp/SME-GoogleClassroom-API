using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionarioParaTratamentoDeErroQuery : IRequest<FuncionarioEol>
    {
        public long Rf { get; set; }
        public ParametrosCargaInicialDto ParametrosCargaInicialDto { get; }

        public ObterFuncionarioParaTratamentoDeErroQuery(long rf, Infra.ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            Rf = rf;
            ParametrosCargaInicialDto = parametrosCargaInicialDto;
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