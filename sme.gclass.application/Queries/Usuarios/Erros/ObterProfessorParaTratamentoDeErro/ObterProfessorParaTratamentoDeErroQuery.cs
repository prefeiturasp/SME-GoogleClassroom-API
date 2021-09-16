using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessorParaTratamentoDeErroQuery : IRequest<ProfessorEol>
    {
        public long Rf { get; set; }
        public ParametrosCargaInicialDto ParametrosCargaInicialDto { get; set; }

        public ObterProfessorParaTratamentoDeErroQuery(long rf, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            Rf = rf;
            ParametrosCargaInicialDto = parametrosCargaInicialDto;
        }
    }

    public class ObterProfessorParaTratamentoDeErroQueryValidator : AbstractValidator<ObterProfessorParaTratamentoDeErroQuery>
    {
        public ObterProfessorParaTratamentoDeErroQueryValidator()
        {
            RuleFor(x => x.ParametrosCargaInicialDto)
                .NotEmpty()
                .WithMessage("A configuração de parâmetros deve ser informada.");

            RuleFor(x => x.Rf)
                .NotEmpty()
                .WithMessage("O RF do professor deve ser informado.");
        }
    }
}