using FluentValidation;
using MediatR;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterEmailProfessorResponsavelCursoQuery : IRequest<bool>
    {
        public long UsuarioId { get; set; }
        public string Email { get; set; }

        public ObterEmailProfessorResponsavelCursoQuery(long usuarioId, string email)
        {
            UsuarioId = usuarioId;
            Email = email;
        }
    }

    public class ObterEmailProfessorResponsavelCursoQueryValidator : AbstractValidator<ObterEmailProfessorResponsavelCursoQuery>
    {
        public ObterEmailProfessorResponsavelCursoQueryValidator()
        {
            RuleFor(x => x.UsuarioId)
                .NotEmpty()
                .WithMessage("O ID do usuário deve ser informado.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O Email do usuário deve ser informado.");
        }
    }
}
