using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosIncluirGoogleQuery : IRequest<PaginacaoResultadoDto<CursoEol>>
    {
        public ObterCursosIncluirGoogleQuery(ParametrosCargaInicialDto parametrosCargaInicialDto, DateTime? ultimaExecucao, Paginacao paginacao, long? componenteCurricularId, long? turmaId)
        {
            UltimaExecucao = ultimaExecucao;
            Paginacao = paginacao;
            ComponenteCurricularId = componenteCurricularId;
            TurmaId = turmaId;
            ParametrosCargaInicialDto = parametrosCargaInicialDto;
        }
        public Paginacao Paginacao { get; set; }
        public DateTime? UltimaExecucao { get; set; }
        public long? ComponenteCurricularId { get; set; }
        public long? TurmaId { get; set; }
        public ParametrosCargaInicialDto ParametrosCargaInicialDto { get; set; }
    }

    public class ObterCursosIncluirGoogleQueryValidator : AbstractValidator<ObterCursosIncluirGoogleQuery>
    {
        public ObterCursosIncluirGoogleQueryValidator()
        {
            RuleFor(x => x.ParametrosCargaInicialDto)
                .NotEmpty()
                .WithMessage("A configuração de parâmetros deve ser informada.");

            RuleFor(x => x.Paginacao)
                .NotEmpty()
                .WithMessage("A página e a quantidade de registros devem ser informados.");
        }
    }
}
