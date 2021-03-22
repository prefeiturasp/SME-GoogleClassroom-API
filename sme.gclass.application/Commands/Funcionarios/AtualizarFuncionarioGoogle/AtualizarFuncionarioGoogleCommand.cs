using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtualizarFuncionarioGoogleCommand : IRequest<bool>
    {
        public FuncionarioIndiretoGoogle FuncionarioIndiretoGoogle { get; set; }

        public AtualizarFuncionarioGoogleCommand(FuncionarioIndiretoGoogle funcionarioIndiretoGoogle)
        {
            FuncionarioIndiretoGoogle = funcionarioIndiretoGoogle;
        }
    }

    public class AtualizarFuncionarioGoogleCommandValidator : AbstractValidator<AtualizarFuncionarioGoogleCommand>
    {
        public AtualizarFuncionarioGoogleCommandValidator()
        {
            RuleFor(x => x.FuncionarioIndiretoGoogle)
                .NotEmpty()
                .WithMessage("É necessário informar o funcionário indireto que será atualizado no Google Classroom.");
        }
    }
}