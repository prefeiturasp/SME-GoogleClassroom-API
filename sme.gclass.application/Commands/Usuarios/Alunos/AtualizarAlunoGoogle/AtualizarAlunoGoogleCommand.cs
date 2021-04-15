using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{ 
    public class AtualizarAlunoGoogleCommand : IRequest<bool>
    {
        public AlunoGoogle AlunoGoogle { get; set; }

        public AtualizarAlunoGoogleCommand(AlunoGoogle alunoGoogle)
        {
            AlunoGoogle = alunoGoogle;
        }
    }

    public class AtualizarAlunoGoogleCommandValidator : AbstractValidator<AtualizarAlunoGoogleCommand>
    {
        public AtualizarAlunoGoogleCommandValidator()
        {
            RuleFor(x => x.AlunoGoogle)
                .NotEmpty()
                .WithMessage("É necessário informar o aluno que será atualizado no Google Classroom.");
        }
    }
}
