using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoGsaPorAnoQuery : IRequest<IEnumerable<CursoGsaId>>
    {
        public ObterCursoGsaPorAnoQuery(int anoLetivo, long? cursoId = null, int pagina = 0, int quantidadeRegistrosPagina = 100)
        {
            AnoLetivo = anoLetivo;
            CursoId = cursoId;
            Pagina = pagina;
            QuantidadeRegistrosPagina = quantidadeRegistrosPagina;
        }

        public int AnoLetivo { get; }
        public long? CursoId { get; }
        public int Pagina { get; set; }
        public int QuantidadeRegistrosPagina { get; set; }
    }

    public class ObterCursoGsaManualmenteQueryValidator : AbstractValidator<ObterCursoGsaPorAnoQuery>
    {
        public ObterCursoGsaManualmenteQueryValidator()
        {
            RuleFor(a => a.AnoLetivo)
                .NotEmpty()
                .WithMessage("O ano deve ser informado para consulta de turmas");
        }
    }
}
