using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterAlunosQueSeraoInativadosPorAnoLetivoQuery : IRequest<PaginacaoResultadoDto<AlunoEol>>
    {
        public ObterAlunosQueSeraoInativadosPorAnoLetivoQuery(Paginacao paginacao, int anoLetivo)
        {
            AnoLetivo = anoLetivo;
            Paginacao = paginacao;
        }

        public int AnoLetivo { get; set; }

        public Paginacao Paginacao { get; set; }
    }

    public class ObterAlunosQueSeraoInativadosPorAnoLetivoQueryValidator : AbstractValidator<ObterAlunosQueSeraoInativadosPorAnoLetivoQuery>
    {
        public ObterAlunosQueSeraoInativadosPorAnoLetivoQueryValidator()
        {
            RuleFor(x => x.AnoLetivo)
                .GreaterThan(0)
                .NotNull()
                .WithMessage("O ano letivo deve ser informado.");
        }
    }
}
