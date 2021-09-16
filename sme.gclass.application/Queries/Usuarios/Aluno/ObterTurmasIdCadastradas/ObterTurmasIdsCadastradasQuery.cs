using FluentValidation;
using MediatR;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterTurmasIdsCadastradasQuery : IRequest<IEnumerable<long>>
    {
        public ObterTurmasIdsCadastradasQuery(int anoLetivo, long? turmaId = null)
        {
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
        }

        public int AnoLetivo { get; }

        public long? TurmaId { get; set; }
    }

    public class ObterTurmasIsCadastradasQueryValidator : AbstractValidator<ObterTurmasIdsCadastradasQuery>
    {
        public ObterTurmasIsCadastradasQueryValidator()
        {
            RuleFor(x => x.AnoLetivo)
                .NotNull()
                .WithMessage("O ano letivo deve ser informado para consulta de turmas no ano.");
        }
    }
}
