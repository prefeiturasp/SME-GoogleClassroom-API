using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosCelpPorComponenteCurricularEAnoQuery: IRequest<IEnumerable<CursoCelpDto>>
    {
        public ObterCursosCelpPorComponenteCurricularEAnoQuery(int ano, int[] componentesCurriculares)
        {
            Ano = ano;
            componentesCurriculares = componentesCurriculares;
        }

        public int Ano { get; set; }
        public int[] componentesCurriculares { get; set; }
    }

    public class ObterCursosCelpPorComponenteCurricularEAnoQueryValidator : AbstractValidator<ObterCursosCelpPorComponenteCurricularEAnoQuery>
    {
        public ObterCursosCelpPorComponenteCurricularEAnoQueryValidator()
        {
            RuleFor(x => x.Ano)
                .NotEmpty()
                .WithMessage("O ano deve ser informado para a busca de cursos celp por componente curricular e ano.");
            
            RuleFor(x => x.Ano)
                .NotEmpty()
                .WithMessage("Os componentes curriculares devem ser informados para a busca de cursos celp por componente curricular e ano.");
        }
    }
}