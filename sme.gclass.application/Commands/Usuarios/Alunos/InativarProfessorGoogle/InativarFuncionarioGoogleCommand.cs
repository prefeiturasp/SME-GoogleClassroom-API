using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InativarFuncionarioGoogleCommand : IRequest<bool>
    {
        public string Email { get; set; }

        public UsuarioTipo UsuarioTipo { get; set; }

        public InativarFuncionarioGoogleCommand(string email, UsuarioTipo usuarioTipo)
        {
            Email = email;
            UsuarioTipo = usuarioTipo;
        }
    }

    public class InativarProfessorGoogleCommandValidator : AbstractValidator<InativarAlunoGoogleCommand>
    {
        public InativarProfessorGoogleCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("É necessário informar o email do professor que será inativado no Google Classroom.");
        }
    }
}