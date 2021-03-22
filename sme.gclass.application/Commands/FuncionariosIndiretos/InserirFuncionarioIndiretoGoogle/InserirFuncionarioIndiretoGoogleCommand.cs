using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirFuncionarioIndiretoGoogleCommand : IRequest<bool>
    {
        public FuncionarioIndiretoGoogle FuncionarioIndiretoGoogle { get; set; }

        public InserirFuncionarioIndiretoGoogleCommand(FuncionarioIndiretoGoogle funcionarioIndiretoGoogle)
        {
            FuncionarioIndiretoGoogle = funcionarioIndiretoGoogle;
        }
    }

    public class InserirFuncionarioIndiretoGoogleCommandValidator : AbstractValidator<InserirFuncionarioIndiretoGoogleCommand>
    {
        public InserirFuncionarioIndiretoGoogleCommandValidator()
        {
            RuleFor(x => x.FuncionarioIndiretoGoogle)
                .NotEmpty()
                .WithMessage("É necessário informar o funcionário que será incluído no Google Classroom.");
        }
    }
}