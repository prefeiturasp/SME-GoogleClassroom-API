using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessorParaTratamentoDeErroQuery : IRequest<ProfessorEol>
    {
        public long Rf { get; set; }

        public ObterProfessorParaTratamentoDeErroQuery(long rf)
        {
            Rf = rf;
        }
    }

    public class ObterProfessorParaTratamentoDeErroQueryValidator : AbstractValidator<ObterProfessorParaTratamentoDeErroQuery>
    {
        public ObterProfessorParaTratamentoDeErroQueryValidator()
        {
            RuleFor(x => x.Rf)
                .NotEmpty()
                .WithMessage("O RF do professor deve ser informado.");
        }
    }
}