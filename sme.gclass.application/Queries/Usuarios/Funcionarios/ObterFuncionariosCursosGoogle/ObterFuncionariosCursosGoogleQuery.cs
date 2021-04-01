using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosCursosGoogleQuery : IRequest<PaginacaoResultadoDto<FuncionarioCursosCadastradosDto>>
    {
        public ObterFuncionariosCursosGoogleQuery(Paginacao paginacao, long? rf, long? turmaId, long? componenteCurricularId)
        {
            Paginacao = paginacao;
            Rf = rf;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }

        public Paginacao Paginacao { get; set; }
        public long? Rf { get; set; }
        public long? TurmaId { get; set; }
        public long? ComponenteCurricularId { get; set; }
    }

    public class ObterFuncionariosCursosGoogleQueryValidator : AbstractValidator<ObterFuncionariosCursosGoogleQuery>
    {
        public ObterFuncionariosCursosGoogleQueryValidator()
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
