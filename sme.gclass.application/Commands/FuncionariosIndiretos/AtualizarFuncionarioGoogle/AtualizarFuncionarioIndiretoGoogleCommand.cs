using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtualizarFuncionarioIndiretoGoogleCommand : IRequest<bool>
    {
        public FuncionarioIndiretoGoogle FuncionarioIndiretoGoogle { get; set; }

        public AtualizarFuncionarioIndiretoGoogleCommand(FuncionarioIndiretoGoogle funcionarioIndiretoGoogle)
        {
            FuncionarioIndiretoGoogle = funcionarioIndiretoGoogle;
        }
    }

    public class AtualizarFuncionarioGoogleCommandValidator : AbstractValidator<AtualizarFuncionarioIndiretoGoogleCommand>
    {
        public AtualizarFuncionarioGoogleCommandValidator()
        {
            RuleFor(x => x.FuncionarioIndiretoGoogle)
                .NotEmpty()
                .WithMessage("É necessário informar o funcionário indireto que será atualizado no Google Classroom.");
        }
    }
}