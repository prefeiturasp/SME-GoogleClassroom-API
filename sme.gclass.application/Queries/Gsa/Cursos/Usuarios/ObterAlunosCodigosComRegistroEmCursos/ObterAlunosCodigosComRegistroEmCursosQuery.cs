using FluentValidation;
using MediatR;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCodigosComRegistroEmCursosQuery : IRequest<IEnumerable<long>>
    {
        public ObterAlunosCodigosComRegistroEmCursosQuery(IEnumerable<long> alunosCodigos)
        {
            AlunosCodigos = alunosCodigos;
        }

        public IEnumerable<long> AlunosCodigos { get; set; }
    }

    public class ObterAlunosCodigosComRegistroEmCursosQueryValidator : AbstractValidator<ObterAlunosCodigosComRegistroEmCursosQuery>
    {
        public ObterAlunosCodigosComRegistroEmCursosQueryValidator()
        {
            RuleFor(x => x.AlunosCodigos)
                .NotEmpty()
                .NotNull()
                .WithMessage("É obrigatório informar os códigos dos alunos");
        }
    }
}
