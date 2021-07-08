using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAvisoMuralPorIdQuery : IRequest<AvisoGsa>
    {
        public ObterAvisoMuralPorIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }

    public class ObterAvisoMuralPorIdQueryValidator : AbstractValidator<ObterAvisoMuralPorIdQuery>
    {
        public ObterAvisoMuralPorIdQueryValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty()
                .WithMessage("O id do aviso no mural do google deve ser informado para consulta");
        }
    }
}
