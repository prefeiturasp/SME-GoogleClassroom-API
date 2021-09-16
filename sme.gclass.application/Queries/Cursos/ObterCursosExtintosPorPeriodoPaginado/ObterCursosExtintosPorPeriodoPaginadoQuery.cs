using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosExtintosPorPeriodoPaginadoQuery : IRequest<PaginacaoResultadoDto<CursoExtintoEolDto>>
    {
        public ObterCursosExtintosPorPeriodoPaginadoQuery(ParametrosCargaInicialDto parametrosCargaInicialDto, DateTime dataInicio, DateTime dataFim, int anoLetivo, long? turmaId, Paginacao paginacao)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
            Paginacao = paginacao;
        }

        public DateTime DataInicio { get; }
        public DateTime DataFim { get; }
        public int AnoLetivo { get; }
        public long? TurmaId { get; }
        public Paginacao Paginacao { get; }
        public ParametrosCargaInicialDto ParametrosCargaInicialDto { get; set; }        
    }

    public class ObterCursosExtintosPorPeriodoPaginadoQueryValidator : AbstractValidator<ObterCursosExtintosPorPeriodoPaginadoQuery>
    {
        public ObterCursosExtintosPorPeriodoPaginadoQueryValidator()
        {
            RuleFor(a => a.DataInicio)
                .NotEmpty()
                .WithMessage("A data de início deve ser informada para consulta de turmas a arquivar");

            RuleFor(a => a.DataFim)
                .NotEmpty()
                .WithMessage("A data de fim deve ser informada para consulta de turmas a arquivar");

            RuleFor(a => a.AnoLetivo)
                .NotEmpty()
                .WithMessage("O ano letivo deve ser informado para consulta de turmas a arquivar");

            RuleFor(x => x.ParametrosCargaInicialDto)
                .NotEmpty()
                .WithMessage("A configuração de parâmetros deve ser informada.");
        }
    }
}
