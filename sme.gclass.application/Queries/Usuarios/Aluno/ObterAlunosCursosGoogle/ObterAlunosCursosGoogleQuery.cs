using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCursosGoogleQuery : IRequest<PaginacaoResultadoDto<AlunoCursosCadastradosDto>>
    {
        public ObterAlunosCursosGoogleQuery(Paginacao paginacao, long? codigoAluno, long? turmaId, long? componenteCurricularId)
        {
            Paginacao = paginacao;
            CodigoAluno = codigoAluno;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }

        public Paginacao Paginacao { get; set; }
        public long? CodigoAluno { get; set; }
        public long? TurmaId { get; set; }
        public long? ComponenteCurricularId { get; set; }
    }
    public class ObterAlunosCursosGoogleQueryValidator : AbstractValidator<ObterAlunosCursosGoogleQuery>
    {
        public ObterAlunosCursosGoogleQueryValidator()
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
