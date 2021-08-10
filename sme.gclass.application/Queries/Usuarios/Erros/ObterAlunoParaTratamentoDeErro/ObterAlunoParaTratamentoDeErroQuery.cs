using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunoParaTratamentoDeErroQuery : IRequest<AlunoEol>
    {
        public long CodigoEol { get; set; }
        public ParametrosCargaInicialDto ParametrosCargaInicialDto { get; set; }

        public ObterAlunoParaTratamentoDeErroQuery(long codigoEol, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            CodigoEol = codigoEol;
            ParametrosCargaInicialDto = parametrosCargaInicialDto;
        }
    }

    public class ObterAlunoParaTratamentoDeErroQueryValidator : AbstractValidator<ObterAlunoParaTratamentoDeErroQuery>
    {
        public ObterAlunoParaTratamentoDeErroQueryValidator()
        {
            RuleFor(x => x.CodigoEol)
                .NotEmpty()
                .WithMessage("O código EOL do aluno deve ser informado.");

            RuleFor(x => x.ParametrosCargaInicialDto)
                .NotEmpty()
                .WithMessage("O código EOL do aluno deve ser informado.");
        }
    }
}