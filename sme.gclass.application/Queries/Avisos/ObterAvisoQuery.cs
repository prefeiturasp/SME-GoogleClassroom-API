using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio.Entidades.Gsa.Mural;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao.Queries.Avisos
{
    public class ObterAvisoQuery : IRequest<IEnumerable<AvisoGsa>>
    {
        public ObterAvisoQuery(long usuarioId)
        {
            UsuarioId = usuarioId;
        }

        public long UsuarioId { get; set; }
    }

    public class ObterAvisoQueryValidator : AbstractValidator<ObterAvisoQuery>
    {
        public ObterAvisoQueryValidator()
        {
            RuleFor(x => x.UsuarioId)
                .NotEmpty()
                .WithMessage("Parâmetro de usuário não pode ser nulo");
        }
    }
}