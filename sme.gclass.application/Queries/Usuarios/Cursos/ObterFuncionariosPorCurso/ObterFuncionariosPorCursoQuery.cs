using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosPorCursoQuery: IRequest<IEnumerable<UsuarioGoogleDto>>
    {
        public long CursoId { get; set; }

        public ObterFuncionariosPorCursoQuery(long cursoId)
        {
            CursoId = cursoId;
        }
    }

    public class ObterFuncionariosPorCursoQueryValidator : AbstractValidator<ObterPorUsuarioIdCursoIdQuery>
    {
        public ObterFuncionariosPorCursoQueryValidator()
        {
            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("O curso deve ser informado para busca.");
        }
    }
}
