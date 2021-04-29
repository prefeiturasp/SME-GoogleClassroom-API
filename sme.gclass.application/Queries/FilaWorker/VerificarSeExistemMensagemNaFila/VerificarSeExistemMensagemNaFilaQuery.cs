using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class VerificarSeExistemMensagemNaFilaQuery : IRequest<bool>
    {
        public string RotaFila { get; set; }

        public VerificarSeExistemMensagemNaFilaQuery(string rotaFila)
        {
            RotaFila = rotaFila;
        }
    }

    public class VerificarSeExistemMensagemNaFilaQueryValidator : AbstractValidator<VerificarSeExistemMensagemNaFilaQuery>
    {
        public VerificarSeExistemMensagemNaFilaQueryValidator()
        {
            RuleFor(x => x.RotaFila)
                .NotEmpty()
                .WithMessage("A rota da fila deve ser informada para verificação de mensagens.");
        }
    }
}