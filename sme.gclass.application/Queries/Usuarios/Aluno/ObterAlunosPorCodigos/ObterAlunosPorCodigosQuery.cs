using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosPorCodigosQuery : IRequest<IEnumerable<AlunoGoogle>>
    {
        public ObterAlunosPorCodigosQuery(long alunoCodigo)
        {
            AlunosCodigo = new long[] { alunoCodigo };
        }
        public ObterAlunosPorCodigosQuery(long[] alunosCodigo)
        {
            AlunosCodigo = alunosCodigo;
        }

        public long[] AlunosCodigo { get; set; }
    }

    public class ObterAlunosPorCodigosEolQueryValidator : AbstractValidator<ObterAlunosPorCodigosQuery>
    {
        public ObterAlunosPorCodigosEolQueryValidator()
        {
            RuleFor(c => c.AlunosCodigo)
               .NotEmpty()
               .WithMessage("Ao menos um codigo do aluno deve ser informado. ");
        }
    }
}
