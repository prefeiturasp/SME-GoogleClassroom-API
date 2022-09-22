using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterTurmasConcluidasPorAnoLetivoQuery: IRequest<IEnumerable<CursoEolDto>>
    {
        public int AnoLetivo { get; set; }
        public long? TurmaId { get; set; }
        public ParametrosCargaInicialDto ParametrosCargaInicialDto { get; set; }

        public ObterTurmasConcluidasPorAnoLetivoQuery(ParametrosCargaInicialDto parametrosCargaInicialDto, int anoLetivo, long? turmaId)
        {
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
            ParametrosCargaInicialDto = parametrosCargaInicialDto;
        }
    }

    public class ObterTurmasConcluidasPorAnoLetivoQueryValidator : AbstractValidator<ObterTurmasConcluidasPorAnoLetivoQuery>
    {
        public ObterTurmasConcluidasPorAnoLetivoQueryValidator()
        {
            RuleFor(a => a.AnoLetivo)
                .NotEmpty()
                .WithMessage("O Ano deve ser informado");

            RuleFor(x => x.ParametrosCargaInicialDto)
                .NotEmpty()
                .WithMessage("A configuração de parâmetros deve ser informada.");
        }
    }
}
