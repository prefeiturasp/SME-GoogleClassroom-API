using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoPorNomeQuery : IRequest<CursoGoogle>
    {
        public ObterCursoPorNomeQuery(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
    }

    public class ObterCursoPorNomeQueryValidator : AbstractValidator<ObterCursoPorNomeQuery>
    {
        public ObterCursoPorNomeQueryValidator()
        {
            RuleFor(c => c.Nome)
               .NotEmpty()
               .WithMessage("A sala virtual (nome do curso) deve ser informada.");
        }
    }
}