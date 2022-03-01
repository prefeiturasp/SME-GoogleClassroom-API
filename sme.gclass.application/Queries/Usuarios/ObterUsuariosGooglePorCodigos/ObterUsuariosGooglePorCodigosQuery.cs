using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosGooglePorCodigosQuery : IRequest<UsuarioGoogleDto>
    {
        public ObterUsuariosGooglePorCodigosQuery(long usuarioCodigo)
        {
            UsuarioCodigo = new long[] { usuarioCodigo };
        }
        public ObterUsuariosGooglePorCodigosQuery(long[] usuarioCodigo)
        {
            UsuarioCodigo = usuarioCodigo;
        }

        public long[] UsuarioCodigo { get; set; }
    }

    public class ObterUsuariosGooglePorCodigosQueryValidator : AbstractValidator<ObterUsuariosGooglePorCodigosQuery>
    {
        public ObterUsuariosGooglePorCodigosQueryValidator()
        {
            RuleFor(c => c.UsuarioCodigo)
               .NotEmpty()
               .WithMessage("Ao menos um codigo de usuário deve ser informado. ");
        }
    }
}
