using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosPorCodigosPaginadoQuery : IRequest<PaginacaoResultadoDto<AlunoGoogle>>
    {
        public ObterAlunosPorCodigosPaginadoQuery(Paginacao paginacao, long[] codigosAluno)
        {
            Paginacao = paginacao;
            CodigosAluno = codigosAluno;
        }

        public Paginacao Paginacao { get; set; }
        public long[] CodigosAluno { get; set; }
    }

    public class ObterAlunosPorCodigosPaginadoQueryValidator : AbstractValidator<ObterAlunosPorCodigosPaginadoQuery>
    {
        public ObterAlunosPorCodigosPaginadoQueryValidator()
        {
            RuleFor(c => c.CodigosAluno)
               .NotEmpty()
               .WithMessage("Os codigos dos alunos devem ser informados.");
            RuleFor(x => x.Paginacao.QuantidadeRegistros)
                .GreaterThan(0)
                .WithMessage("O número da página e a quantidade de registro devem ser informados.");
        }
    }
}
