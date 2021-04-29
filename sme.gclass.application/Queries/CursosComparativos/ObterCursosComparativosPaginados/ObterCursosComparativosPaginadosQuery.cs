using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosComparativosPaginadosQuery : IRequest<PaginacaoResultadoDto<CursoComparativoDto>>
    {
        public ObterCursosComparativosPaginadosQuery(Paginacao paginacao, string secao)
        {
            Paginacao = paginacao;
            Secao = secao;
        }

        public Paginacao Paginacao { get; set; }
        public string Secao { get; set; }
    }

    public class ObterCursosComparativosPaginadosQueryValidator : AbstractValidator<ObterCursosComparativosPaginadosQuery>
    {
        public ObterCursosComparativosPaginadosQueryValidator()
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
