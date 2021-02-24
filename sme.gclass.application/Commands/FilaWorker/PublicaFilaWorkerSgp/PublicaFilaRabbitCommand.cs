using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class PublicaFilaRabbitCommand : IRequest<bool>
    {
        public PublicaFilaRabbitCommand(string nomeFila, object mensagem)
        {
            Mensagem = mensagem;
            NomeFila = nomeFila;
        }

        public string NomeFila { get; private set; }
        public object Mensagem { get; private set; }

    }

    public class PublicaFilaRabbitCommandValidator : AbstractValidator<PublicaFilaRabbitCommand>
    {
        public PublicaFilaRabbitCommandValidator()
        {
            RuleFor(c => c.NomeFila)
               .NotEmpty()
               .WithMessage("O nome da fila deve ser informado para publicar na fila do worker.");

            RuleFor(c => c.Mensagem)
               .NotEmpty()
               .WithMessage("A mensagem deve ser informada para publicar na fila do worker.");


        }
    }
}
