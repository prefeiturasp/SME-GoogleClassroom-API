using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirAlunoGoogleCommand : IRequest<bool>
    {
        public AlunoGoogle AlunoGoogle { get; set; }

        public InserirAlunoGoogleCommand(AlunoGoogle alunoGoogle)
        {
            AlunoGoogle = alunoGoogle;
        }
    }

    public class InserirAlunoGoogleCommandValidator : AbstractValidator<InserirAlunoGoogleCommand>
    {
        public InserirAlunoGoogleCommandValidator()
        {
            RuleFor(x => x.AlunoGoogle)
                .NotEmpty()
                .WithMessage("É necessário informar o aluno que será incluído no Google Classroom.");
        }
    }
}