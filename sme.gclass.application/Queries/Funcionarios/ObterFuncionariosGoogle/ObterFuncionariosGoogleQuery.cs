using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosGoogleQuery : IRequest<PaginacaoResultadoDto<FuncionarioGoogle>>
    {
        public ObterFuncionariosGoogleQuery(Paginacao paginacao, long? rf, string email)
        {
            Paginacao = paginacao;
            Rf = rf;
            Email = email;
        }

        public Paginacao Paginacao { get; set; }
        public long? Rf { get; set; }
        public string Email { get; set; }
    }

    public class ObterFuncionariosGoogleQueryValidator : AbstractValidator<ObterFuncionariosGoogleQuery>
    {
        public ObterFuncionariosGoogleQueryValidator()
        {
            RuleFor(x => x.Paginacao)
                .NotEmpty()
                .WithMessage("A paginação deve ser informada.");

            RuleFor(x => x.Paginacao.QuantidadeRegistros)
                .GreaterThan(0)
                .WithMessage("O número da página e a quantidade de registro devem ser informados.");
        }
    }
}
