using System.Collections.Generic;
using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterTurmasPorTipoECodigosQuery : IRequest<IEnumerable<long>>
    {
        public int TipoTurma { get; set; }
        public List<long> CodigoTurma { get; set; }

        public ObterTurmasPorTipoECodigosQuery(int tipoTurma, List<long> codigoTurma)
        {
            TipoTurma = tipoTurma;
            CodigoTurma = codigoTurma;
        }
    }


    public class
        ObterTurmasPorTipoECodigosQueryValidator : AbstractValidator<ObterTurmasPorTipoECodigosQuery>
    {
        public ObterTurmasPorTipoECodigosQueryValidator()
        {
            RuleFor(x => x.TipoTurma)
                .NotEmpty()
                .WithMessage("O Tipo Turma é obrigatório");

            RuleFor(x => x.CodigoTurma)
                .NotEmpty()
                .NotNull()
                .WithMessage("Os Codigos das turmas são obrigatórios");
        }
    }
}