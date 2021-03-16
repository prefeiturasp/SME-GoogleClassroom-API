using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterGradesDeCursosQuery : IRequest<PaginacaoResultadoDto<GradeCursoEol>>
    {
        public DateTime UltimaDataExecucao { get; set; }
        public Paginacao Paginacao { get; set; }
        public long? TurmaId { get; set; }
        public long? ComponenteCurricularId { get; set; }

        public ObterGradesDeCursosQuery(DateTime ultimaDataExecucao, Paginacao paginacao)
        {
            UltimaDataExecucao = ultimaDataExecucao;
            Paginacao = paginacao;
        }

        public ObterGradesDeCursosQuery(DateTime ultimaDataExecucao, Paginacao paginacao, long? turmaId, long? componenteCurricularId)
            : this(ultimaDataExecucao, paginacao)
        {
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }
    }

    public class ObterGradesDeCursosQueryValidator : AbstractValidator<ObterGradesDeCursosQuery>
    {
        public ObterGradesDeCursosQueryValidator()
        {
            RuleFor(x => x.UltimaDataExecucao)
                .NotEmpty()
                .WithMessage("A última data de execução deve ser informada.");

            RuleFor(x => x.Paginacao)
                .NotEmpty()
                .WithMessage("A página e a quantidade de registros devem ser informados.");

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