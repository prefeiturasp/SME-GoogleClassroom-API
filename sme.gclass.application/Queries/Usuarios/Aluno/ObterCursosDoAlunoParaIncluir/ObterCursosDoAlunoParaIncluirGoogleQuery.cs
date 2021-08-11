using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosDoAlunoParaIncluirGoogleQuery : IRequest<IEnumerable<AlunoCursoEol>>
    {
        public long CodigoAluno { get; set; }
        public int AnoLetivo { get; set; }
        public ParametrosCargaInicialDto ParametrosCargaInicialDto{ get; set; }

        public ObterCursosDoAlunoParaIncluirGoogleQuery(long codigoAluno, int anoLetivo, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            CodigoAluno = codigoAluno;
            AnoLetivo = anoLetivo;
            ParametrosCargaInicialDto = parametrosCargaInicialDto;
        }
    }

    public class ObterCursosDoAlunoParaIncluirGoogleQueryValidator : AbstractValidator<ObterCursosDoAlunoParaIncluirGoogleQuery>
    {
        public ObterCursosDoAlunoParaIncluirGoogleQueryValidator()
        {
            RuleFor(x => x.ParametrosCargaInicialDto)
                .NotEmpty()
                .WithMessage("A configuração de parâmetros deve ser informada.");

            RuleFor(x => x.CodigoAluno)
                .NotEmpty()
                .WithMessage("O código do aluno deve ser informado.");

            RuleFor(x => x.AnoLetivo)
                .NotEmpty()
                .WithMessage("O ano letivo dos cursos deve ser informado.");
        }
    }
}