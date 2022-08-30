using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirFuncionarioCursoGoogleCommand : IRequest<bool>
    {
        public InserirFuncionarioCursoGoogleCommand(long cursoId, string email)
        {
            CursoId = cursoId;
            Email = email;
        }

        public string Email { get; set; }
        public long CursoId { get; set; }
    }
    public class InserirFuncionarioCursoGoogleCommandValidator : AbstractValidator<InserirFuncionarioCursoGoogleCommand>
    {
        public InserirFuncionarioCursoGoogleCommandValidator()
        {
            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("O identificador do curso deve ser informado para funcionário ser incluído no curso no Google Classroom.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail do funcionario deve ser informado para funcionário ser incluído no curso no Google Classroom.");
        }
    }
}
