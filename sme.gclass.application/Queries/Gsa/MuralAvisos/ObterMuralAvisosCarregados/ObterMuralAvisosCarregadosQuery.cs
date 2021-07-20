using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterMuralAvisosCarregadosQuery : IRequest<IEnumerable<AvisoGsa>>
    {
        public ObterMuralAvisosCarregadosQuery(long cursoId)
        {
            CursoId = cursoId;
        }

        public long CursoId { get; }
    }

    public class ObterMuralAvisosCarregadosQueryValidator : AbstractValidator<ObterMuralAvisosCarregadosQuery>
    {
        public ObterMuralAvisosCarregadosQueryValidator()
        {
            RuleFor(a => a.CursoId)
                .NotEmpty()
                .WithMessage("O id do curso deve ser informado para carga dos avisos do mural no GCA");
        }
    }
}
