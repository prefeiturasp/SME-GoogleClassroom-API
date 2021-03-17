using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresFuncionariosPorRfsPaginadoQuery : IRequest<PaginacaoResultadoDto<ProfessorGoogle>>
    {
        public ObterProfessoresFuncionariosPorRfsPaginadoQuery(Paginacao paginacao, long[] rfs)
        {
            Paginacao = paginacao;
            Rfs = rfs;
        }

        public Paginacao Paginacao { get; set; }
        public long[] Rfs { get; set; }
    }

    public class ObterProfessoresPorRfsPaginadoQueryValidator : AbstractValidator<ObterProfessoresFuncionariosPorRfsPaginadoQuery>
    {
        public ObterProfessoresPorRfsPaginadoQueryValidator()
        {
            RuleFor(c => c.Rfs)
               .NotEmpty()
               .WithMessage("Os Rfs dos professores devem ser informados. ");
            RuleFor(x => x.Paginacao.QuantidadeRegistros)
                .GreaterThan(0)
                .WithMessage("O número da página e a quantidade de registro devem ser informados.");
        }
    }
}