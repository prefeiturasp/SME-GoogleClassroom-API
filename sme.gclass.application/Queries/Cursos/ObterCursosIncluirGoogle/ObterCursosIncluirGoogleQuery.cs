using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosIncluirGoogleQuery : IRequest<PaginacaoResultadoDto<CursoParaInclusaoDto>>
    {
        public ObterCursosIncluirGoogleQuery(DateTime ultimaExecucao, Paginacao paginacao, long? componenteCurricularId, long? turmaId)
        {
            UltimaExecucao = ultimaExecucao;
            Paginacao = paginacao;
            ComponenteCurricularId = componenteCurricularId;
            TurmaId = turmaId;
        }
        public Paginacao Paginacao { get; set; }
        public DateTime UltimaExecucao { get; set; }
        public long? ComponenteCurricularId { get; set; }
        public long? TurmaId { get; set; }
    }

    public class ObterCursosIncluirGoogleQueryValidator : AbstractValidator<ObterCursosIncluirGoogleQuery>
    {
        public ObterCursosIncluirGoogleQueryValidator()
        {
            RuleFor(x => x.UltimaExecucao)
                .NotEmpty()
                .WithMessage("A última data de execução deve ser informada.");

            RuleFor(x => x.Paginacao)
                .NotEmpty()
                .WithMessage("A página e a quantidade de registros devem ser informados.");
        }
    }
}
