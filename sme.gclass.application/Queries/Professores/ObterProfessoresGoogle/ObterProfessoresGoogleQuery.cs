using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresGoogleQuery : IRequest<PaginacaoResultadoDto<ProfessorGoogle>>
    {
        public ObterProfessoresGoogleQuery(Paginacao paginacao, long? rf, string email)
        {
            Paginacao = paginacao;
            Rf = rf;
            Email = email;
        }

        public Paginacao Paginacao { get; set; }
        public long? Rf { get; set; }
        public string Email { get; set; }
    }

    public class ObterProfessoresGoogleQueryValidator : AbstractValidator<ObterProfessoresGoogleQuery>
    {
        public ObterProfessoresGoogleQueryValidator()
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