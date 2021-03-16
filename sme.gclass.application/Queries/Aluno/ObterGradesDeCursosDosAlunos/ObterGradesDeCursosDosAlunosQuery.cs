using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterGradesDeCursosDosAlunosQuery : IRequest<PaginacaoResultadoDto<GradeCursoEol>>
    {
        public DateTime UltimaDataExecucao { get; set; }
        public Paginacao Paginacao { get; set; }
        public long? CodigoAluno { get; set; }
        public long? TurmaId { get; set; }
        public long? ComponenteCurricularId { get; set; }

        public ObterGradesDeCursosDosAlunosQuery(DateTime ultimaDataExecucao, Paginacao paginacao)
        {
            UltimaDataExecucao = ultimaDataExecucao;
            Paginacao = paginacao;
        }

        public ObterGradesDeCursosDosAlunosQuery(DateTime ultimaDataExecucao, Paginacao paginacao, long? codigoAluno, long? turmaId, long? componenteCurricularId)
            : this(ultimaDataExecucao, paginacao)
        {
            CodigoAluno = codigoAluno;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }
    }

    public class ObterGradesDeCursosDosAlunosQueryValidator : AbstractValidator<ObterGradesDeCursosDosAlunosQuery>
    {
        public ObterGradesDeCursosDosAlunosQueryValidator()
        {
            RuleFor(x => x.UltimaDataExecucao)
                .NotEmpty()
                .WithMessage("A última data de execução deve ser informada.");

            RuleFor(x => x.Paginacao)
                .NotEmpty()
                .WithMessage("A página e a quantidade de registros devem ser informados.");

            RuleFor(x => x.CodigoAluno)
                .NotEmpty()
                .When(x => !(x.CodigoAluno is null))
                .WithMessage("O código do aluno informado é inválido.");

            RuleFor(x => x.TurmaId)
                .NotEmpty()
                .When(x => !(x.TurmaId is null))
                .WithMessage("A turma informada é inválida.");

            RuleFor(x => x.ComponenteCurricularId)
                .NotEmpty()
                .When(x => !(x.ComponenteCurricularId is null))
                .WithMessage("O componente curricular informado é inválido.");
        }
    }
}