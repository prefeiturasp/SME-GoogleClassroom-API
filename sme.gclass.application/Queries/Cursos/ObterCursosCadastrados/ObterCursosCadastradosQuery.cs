using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosCadastradosQuery : IRequest<PaginacaoResultadoDto<Curso>>
    {
        public ObterCursosCadastradosQuery(Paginacao paginacao, long? turmaId, long? componenteCurricularId, long? cursoId, string emailCriador)
        {
            Paginacao = paginacao;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            CursoId = cursoId;
            EmailCriador = emailCriador;
        }

        public Paginacao Paginacao { get; set; }
        public long? TurmaId { get; set; }
        public long? ComponenteCurricularId { get; set; }
        public long? CursoId { get; set; }
        public string EmailCriador { get; set; }
    }

    public class ObterCursosCadastradosQueryValidator : AbstractValidator<ObterCursosCadastradosQuery>
    {
        public ObterCursosCadastradosQueryValidator()
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
