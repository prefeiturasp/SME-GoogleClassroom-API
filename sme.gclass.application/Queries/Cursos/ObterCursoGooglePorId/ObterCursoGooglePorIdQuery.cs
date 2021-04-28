using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoGooglePorIdQuery : IRequest<CursoGoogle>
    {
        public ObterCursoGooglePorIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
    public class ObterCursoGooglePorIdQueryValidator : AbstractValidator<ObterCursoGooglePorIdQuery>
    {
        public ObterCursoGooglePorIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O id do  deve ser informado.");

        }
    }
}
