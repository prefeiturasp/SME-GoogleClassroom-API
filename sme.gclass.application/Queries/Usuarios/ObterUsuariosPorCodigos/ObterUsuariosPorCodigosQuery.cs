using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosPorCodigosQuery : IRequest<IEnumerable<UsuarioGsaDto>>
    {
        public ObterUsuariosPorCodigosQuery(long usuarioCodigo)
        {
            UsuarioCodigo = new long[] { usuarioCodigo };
        }
        public ObterUsuariosPorCodigosQuery(long[] usuarioCodigo)
        {
            UsuarioCodigo = usuarioCodigo;
        }

        public long[] UsuarioCodigo { get; set; }
    }

    public class ObterUsuariosPorCodigosQueryValidator : AbstractValidator<ObterUsuariosPorCodigosQuery>
    {
        public ObterUsuariosPorCodigosQueryValidator()
        {
            RuleFor(c => c.UsuarioCodigo)
               .NotEmpty()
               .WithMessage("Ao menos um codigo de usuário deve ser informado. ");
        }
    }
}
