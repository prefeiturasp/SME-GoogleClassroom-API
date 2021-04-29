using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosComparativosPaginadosQuery : IRequest<PaginacaoResultadoDto<CursoComparativoDto>>
    {
        public ObterCursosComparativosPaginadosQuery(Paginacao paginacao, string secao, string descricao, string nome)
        {
            Paginacao = paginacao;
            Secao = secao;
            Descricao = descricao;
            Nome = nome;
        }

        public Paginacao Paginacao { get; set; }
        public string Secao { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
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
