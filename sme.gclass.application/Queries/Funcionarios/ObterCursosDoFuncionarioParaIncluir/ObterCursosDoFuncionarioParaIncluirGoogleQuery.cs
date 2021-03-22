using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosDoFuncionarioParaIncluirGoogleQuery : IRequest<IEnumerable<FuncionarioCursoEol>>
    {
        public long? Rf { get; set; }
        public int AnoLetivo { get; set; }

        public ObterCursosDoFuncionarioParaIncluirGoogleQuery(long? rf, int anoLetivo)
        {
            Rf = rf;
            AnoLetivo = anoLetivo;
        }
    }

    public class ObterCursosDoFuncionarioParaIncluirGoogleQueryValidator : AbstractValidator<ObterCursosDoFuncionarioParaIncluirGoogleQuery>
    {
        public ObterCursosDoFuncionarioParaIncluirGoogleQueryValidator()
        {
            RuleFor(x => x.Rf)
                .NotEmpty()
                .WithMessage("O Rf do funcionário deve ser informado.");

            RuleFor(x => x.AnoLetivo)
                .NotEmpty()
                .WithMessage("O ano letivo dos cursos deve ser informado.");
        }
    }
}