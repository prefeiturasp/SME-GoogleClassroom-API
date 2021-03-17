using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirFuncionarioCursoGoogleCommand : IRequest<bool>
    {
        public InserirFuncionarioCursoGoogleCommand(FuncionarioCursoGoogle funcionarioCursoGoogle, string email)
        {
            FuncionarioCursoGoogle = funcionarioCursoGoogle;
            Email = email;
        }

        public FuncionarioCursoGoogle FuncionarioCursoGoogle { get; set; }
        public string Email { get; set; }
    }
    public class InserirFuncionarioCursoGoogleCommandValidator : AbstractValidator<InserirFuncionarioCursoGoogleCommand>
    {
        public InserirFuncionarioCursoGoogleCommandValidator()
        {
            RuleFor(x => x.FuncionarioCursoGoogle)
                .NotEmpty()
                .WithMessage("É necessário informar um funcionario x curso que será incluído no Google Classroom.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail do funcionario deve ser informado.");
        }
    }
}
