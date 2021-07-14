using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterAlunosInativosPorAnoLetivoQuery : IRequest<PaginacaoResultadoDto<long>>
    {
        public ObterAlunosInativosPorAnoLetivoQuery(Paginacao paginacao, int anoLetivo)
        {
            AnoLetivo = anoLetivo;
            Paginacao = paginacao;
        }

        public int AnoLetivo { get; set; }

        public Paginacao Paginacao { get; set; }
    }

    public class ObterAlunosInativosPorAnoLetivoETurmaQueryValidator : AbstractValidator<ObterAlunosInativosPorAnoLetivoQuery>
    {
        public ObterAlunosInativosPorAnoLetivoETurmaQueryValidator()
        {
            RuleFor(x => x.AnoLetivo)
                .GreaterThan(0)
                .NotNull()
                .WithMessage("O ano letivo deve ser informado.");
        }
    }
}
