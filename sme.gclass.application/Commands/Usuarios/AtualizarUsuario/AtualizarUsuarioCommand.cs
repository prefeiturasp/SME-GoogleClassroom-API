using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtualizarUsuarioCommand : IRequest<bool>
    {
        public AtualizarUsuarioCommand(long id, string nome, string cpf, string email, UsuarioTipo tipo)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            UsuarioTipo = (int)tipo;
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string OrganizationPath { get; set; }
        public int UsuarioTipo { get; set; }

        public AtualizarUsuarioCommand(long id, string nome, string organizationPath)
        {
            Id = id;
            Nome = nome;
            OrganizationPath = organizationPath;
        }
    }

    public class AtualizarUsuarioCommandValidator : AbstractValidator<AtualizarUsuarioCommand>
    {
        public AtualizarUsuarioCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O identificador do usuário deve ser informado para a atualização.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do usuário deve ser informado para a atualização.");

            RuleFor(x => x.OrganizationPath)
                .NotEmpty()
                .WithMessage("A unidade organizacional do usuário deve ser informado para a atualização.");
        }
    }
}