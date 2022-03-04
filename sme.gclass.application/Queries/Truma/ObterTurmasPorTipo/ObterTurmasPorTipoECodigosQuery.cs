using System.Collections.Generic;
using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterTurmasPorTipoECodigosQuery : IRequest<IEnumerable<long>>
    {
        public List<long> CodigoTurma { get; set; }

        public ObterTurmasPorTipoECodigosQuery(List<long> codigoTurma)
        {
            CodigoTurma = codigoTurma;
        }
    }


    public class
        ObterTurmasPorTipoECodigosQueryValidator : AbstractValidator<ObterTurmasPorTipoECodigosQuery>
    {
        public ObterTurmasPorTipoECodigosQueryValidator()
        {
            RuleFor(x => x.CodigoTurma)
                .NotEmpty()
                .NotNull()
                .WithMessage("Os Codigos das turmas são obrigatórios");
        }
    }
}