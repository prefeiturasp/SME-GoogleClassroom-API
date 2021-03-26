using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosIndiretosGoogleQuery : IRequest<PaginacaoResultadoDto<FuncionarioIndiretoGoogle>>
    {
        public ObterFuncionariosIndiretosGoogleQuery(Paginacao paginacao, string cpf, string email)
        {
            Paginacao = paginacao;
            Cpf = cpf;
            Email = email;
        }

        public Paginacao Paginacao { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
    }

    public class ObterFuncionariosIndiretosGoogleQueryValidator : AbstractValidator<ObterFuncionariosIndiretosGoogleQuery>
    {
        public ObterFuncionariosIndiretosGoogleQueryValidator()
        {
            RuleFor(x => x.Cpf)
                .Matches("^\\d{11}")
                .When(x => !string.IsNullOrWhiteSpace(x.Cpf))
                .WithMessage("O CPF informado é inválido.");

            RuleFor(x => x.Paginacao)
                .NotEmpty()
                .WithMessage("A paginação deve ser informada.");

            RuleFor(x => x.Paginacao.QuantidadeRegistros)
                .GreaterThan(0)
                .WithMessage("O número da página e a quantidade de registro devem ser informados.");
        }
    }
}