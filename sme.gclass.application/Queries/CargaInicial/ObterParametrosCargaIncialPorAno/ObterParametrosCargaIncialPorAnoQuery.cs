using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterParametrosCargaIncialPorAnoQuery : IRequest<ParametrosCargaInicialDto>
    {
        public ObterParametrosCargaIncialPorAnoQuery(int ano)
        {
            Ano = ano;
        }

        public int Ano { get; }
    }

    public class ObterParametrosCargaIncialPorAnoQueryValidator : AbstractValidator<ObterParametrosCargaIncialPorAnoQuery>
    {
        public ObterParametrosCargaIncialPorAnoQueryValidator()
        {
            RuleFor(a => a.Ano)
                .NotEmpty()
                .WithMessage("O ano deve ser informado para consulta dos parâmetros da carga inicial");
        }
    }
}
