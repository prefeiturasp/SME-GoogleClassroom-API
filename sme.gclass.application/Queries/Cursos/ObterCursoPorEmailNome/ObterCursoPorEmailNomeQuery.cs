using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoPorEmailNomeQuery : IRequest<CursoGoogle>
    {
        public ObterCursoPorEmailNomeQuery(string email, string nome)
        {
            Email = email;
            Nome = nome;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
    }

    public class ObterCursoPorEmailNomeQueryValidator : AbstractValidator<ObterCursoPorEmailNomeQuery>
    {
        public ObterCursoPorEmailNomeQueryValidator()
        {
            RuleFor(c => c.Email)
               .NotEmpty()
               .WithMessage("O email deve ser informado.");

            RuleFor(c => c.Nome)
               .NotEmpty()
               .WithMessage("O nome deve ser informado.");
        }
    }
}
