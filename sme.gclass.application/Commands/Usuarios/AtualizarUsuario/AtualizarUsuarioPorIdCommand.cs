using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtualizarUsuarioPorIdCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public int UsuarioTipo { get; set; }
        
        public AtualizarUsuarioPorIdCommand(long id, string nome, string cpf, string email, int usuarioTipo)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            UsuarioTipo = usuarioTipo;
        }
    }
    public class AtualizarUsuarioPorIdCommandValidator : AbstractValidator<AtualizarUsuarioPorIdCommand>
    {
        public AtualizarUsuarioPorIdCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O identificador do usuário deve ser informado para a atualização.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do usuário deve ser informado para a atualização.");
            RuleFor(x => x.Cpf)
                .Length(11)
                .WithMessage("O CPF do usuário deve ser informado e deve ter 11 dígitos  para a atualização.");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O E-mail do usuário deve ser informado para a atualização.");
        }
    }
}