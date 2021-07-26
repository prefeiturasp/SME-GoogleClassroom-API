using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ArquivarCursoExtintoQuery: IRequest<bool>
    {
        public ArquivarCursoExtintoQuery()
        {

        }

        public string Atributo { get; set; }
    }

    public class ArquivarCursoExtintoQueryValidator : AbstractValidator<ArquivarCursoExtintoQuery>
    {
        public ArquivarCursoExtintoQueryValidator()
        {
            RuleFor(a => a.Atributo)
                .NotEmpty()
                .WithMessage("Mensagem de validação");
        }
    }
}
