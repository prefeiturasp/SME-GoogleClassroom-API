using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirFuncionarioGoogleCommand : IRequest<bool>
    {
        public FuncionarioGoogle FuncionarioGoogle { get; set; }

        public InserirFuncionarioGoogleCommand(FuncionarioGoogle funcionarioGoogle)
        {
            FuncionarioGoogle = funcionarioGoogle;
        }
    }

    public class InserirFuncionarioGoogleCommandValidator : AbstractValidator<InserirFuncionarioGoogleCommand>
    {
        public InserirFuncionarioGoogleCommandValidator()
        {
            RuleFor(x => x.FuncionarioGoogle)
                .NotEmpty()
                .WithMessage("É necessário informar o funcionário que será incluído no Google Classroom.");
        }
    }
}