using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirUsuarioCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public UsuarioTipo Tipo { get; set; }
        public string Email { get; set; }
        public string OrganizationPath { get; set; }
    }

    public class IncluirUsuarioCommandValidator : AbstractValidator<IncluirUsuarioCommand>
    {
        public IncluirUsuarioCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("A identificação do usuário deve ser informada.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O email do usuário deve ser informado.");

            RuleFor(x => x.OrganizationPath)
                .NotEmpty()
                .WithMessage("A unidade organizacional do usuário deve ser informada.");
        }
    }
}