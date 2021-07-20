using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterAlunosInativosQuery : IRequest<PaginacaoResultadoDto<UsuarioInativo>>
    {
        public ObterAlunosInativosQuery(Paginacao paginacao)
        {
            Paginacao = paginacao;
        }

        public Paginacao Paginacao { get; set; }
    }

    public class ObterAlunosInativosQueryValidator : AbstractValidator<ObterAlunosInativosQuery>
    {
        public ObterAlunosInativosQueryValidator()
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
