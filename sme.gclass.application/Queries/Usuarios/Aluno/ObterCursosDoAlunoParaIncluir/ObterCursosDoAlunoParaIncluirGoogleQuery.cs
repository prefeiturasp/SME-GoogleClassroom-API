using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosDoAlunoParaIncluirGoogleQuery : IRequest<IEnumerable<AlunoCursoEol>>
    {
        public long CodigoAluno { get; set; }
        public int AnoLetivo { get; set; }

        public ObterCursosDoAlunoParaIncluirGoogleQuery(long codigoAluno, int anoLetivo)
        {
            CodigoAluno = codigoAluno;
            AnoLetivo = anoLetivo;
        }
    }

    public class ObterCursosDoAlunoParaIncluirGoogleQueryValidator : AbstractValidator<ObterCursosDoAlunoParaIncluirGoogleQuery>
    {
        public ObterCursosDoAlunoParaIncluirGoogleQueryValidator()
        {
            RuleFor(x => x.CodigoAluno)
                .NotEmpty()
                .WithMessage("O código do aluno deve ser informado.");

            RuleFor(x => x.AnoLetivo)
                .NotEmpty()
                .WithMessage("O ano letivo dos cursos deve ser informado.");
        }
    }
}