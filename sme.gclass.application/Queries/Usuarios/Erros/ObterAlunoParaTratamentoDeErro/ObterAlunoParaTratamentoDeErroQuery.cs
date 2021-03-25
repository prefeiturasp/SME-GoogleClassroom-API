using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunoParaTratamentoDeErroQuery : IRequest<AlunoEol>
    {
        public long CodigoEol { get; set; }

        public ObterAlunoParaTratamentoDeErroQuery(long codigoEol)
        {
            CodigoEol = codigoEol;
        }
    }

    public class ObterAlunoParaTratamentoDeErroQueryValidator : AbstractValidator<ObterAlunoParaTratamentoDeErroQuery>
    {
        public ObterAlunoParaTratamentoDeErroQueryValidator()
        {
            RuleFor(x => x.CodigoEol)
                .NotEmpty()
                .WithMessage("O código EOL do aluno deve ser informado.");
        }
    }
}