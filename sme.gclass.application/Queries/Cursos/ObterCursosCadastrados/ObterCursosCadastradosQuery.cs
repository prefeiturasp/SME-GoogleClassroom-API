using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Curso;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosCadastradosQuery : IRequest<PaginacaoResultadoDto<CursoGoogleDto>>
    {
        public ObterCursosCadastradosQuery(int paginaNumero, Paginacao paginacao, long? turmaId, long? componenteCurricularId, long? cursoId, string emailCriador)
        {
            PaginaNumero = paginaNumero;
            Paginacao = paginacao;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            CursoId = cursoId;
            EmailCriador = emailCriador;
        }

        public int PaginaNumero { get; set; }
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

            RuleFor(x => x.PaginaNumero)
                .GreaterThan(0)
                .WithMessage("O número da página deve ser maior que zero.");

            RuleFor(x => x.Paginacao.QuantidadeRegistros)
                .GreaterThan(0)
                .When(x => x.Paginacao != null)
                .WithMessage("A quantidade de registros deve ser maior que zero.");
        }
    }
}