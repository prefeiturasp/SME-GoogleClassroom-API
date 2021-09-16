using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class PublicaFilaRabbitCommand : IRequest<bool>
    {
        public PublicaFilaRabbitCommand(string nomeFila, object mensagem = null)
        {
            Mensagem = mensagem;
            NomeFila = nomeFila;
            NomeRota = nomeFila;
        }

        public PublicaFilaRabbitCommand(string nomeFila, string nomeRota = null, object mensagem = null)
        {
            Mensagem = mensagem;
            NomeFila = nomeFila;
            NomeRota = string.IsNullOrEmpty(nomeRota) ? nomeFila : nomeRota;
        }

        public string NomeFila { get; private set; }
        public string NomeRota { get; private set; }
        public object Mensagem { get; private set; }
    }

    public class PublicaFilaRabbitCommandValidator : AbstractValidator<PublicaFilaRabbitCommand>
    {
        public PublicaFilaRabbitCommandValidator()
        {
            RuleFor(c => c.NomeFila)
               .NotEmpty()
               .WithMessage("O nome da fila deve ser informado para publicar na fila do worker.");
        }
    }
}
