using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosComResponsaveisPorAnoQuery : IRequest<(IEnumerable<CursoUsuarioDto> cursos, int? totalPaginas)>
    {
        public ObterCursosComResponsaveisPorAnoQuery(int anoLetivo, long? cursoId = null, int? pagina = null, int? quantidadeRegistrosPagina = null)
        {
            AnoLetivo = anoLetivo;
            CursoId = cursoId;
            Pagina = pagina;
            QuantidadeRegistrosPagina = quantidadeRegistrosPagina;
        }

        public int AnoLetivo { get; }
        public long? CursoId { get; }
        public int? Pagina { get; set; }
        public int? QuantidadeRegistrosPagina { get; set; }
    }

    public class ObterCursosComResponsaveisPorAnoQueryValidator : AbstractValidator<ObterCursosComResponsaveisPorAnoQuery>
    {
        public ObterCursosComResponsaveisPorAnoQueryValidator()
        {
            RuleFor(a => a.AnoLetivo)
                .NotEmpty()
                .WithMessage("O ano deve ser informado para consulta de turmas");
        }
    }
}
