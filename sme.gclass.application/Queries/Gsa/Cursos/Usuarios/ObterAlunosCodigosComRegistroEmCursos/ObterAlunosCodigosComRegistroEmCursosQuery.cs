using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCodigosComRegistroEmCursosQuery : IRequest<IEnumerable<CursoUsuarioRemoverDto>>
    {
        public ObterAlunosCodigosComRegistroEmCursosQuery(IEnumerable<long> alunosCodigos, long turmaId)
        {
            AlunosCodigos = alunosCodigos;
            TurmaId = turmaId;
        }

        public IEnumerable<long> AlunosCodigos { get; set; }
        public long TurmaId { get; set; }
    }

    public class ObterAlunosCodigosComRegistroEmCursosQueryValidator : AbstractValidator<ObterAlunosCodigosComRegistroEmCursosQuery>
    {
        public ObterAlunosCodigosComRegistroEmCursosQueryValidator()
        {
            RuleFor(x => x.AlunosCodigos)
                .NotEmpty()
                .NotNull()
                .WithMessage("É obrigatório informar os códigos dos alunos para consulta de alunos inativos");

            RuleFor(x => x.TurmaId)
                .NotEmpty()
                .NotNull()
                .WithMessage("É obrigatório informar o código da turma para consulta de alunos inativos");
        }
    }
}
