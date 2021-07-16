using FluentValidation;
using MediatR;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterTurmasIdsCadastradasQuery : IRequest<IEnumerable<long>>
    {
        public ObterTurmasIdsCadastradasQuery(int anoLetivo)
        {
            AnoLetivo = anoLetivo;
        }

        public int AnoLetivo { get; }
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
