using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresCursosGoogleQuery : IRequest<PaginacaoResultadoDto<ProfessorCursosCadastradosDto>>
    {
        public ObterProfessoresCursosGoogleQuery(Paginacao paginacao, long? rf, long? turmaId, long? componenteCurricularId)
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
    public class ObterProfessoresCursosGoogleQueryValidator : AbstractValidator<ObterProfessoresCursosGoogleQuery>
    {
        public ObterProfessoresCursosGoogleQueryValidator()
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
