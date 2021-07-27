using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExcluirCursoGoogleCommand : IRequest<bool>
    {
        public ExcluirCursoGoogleCommand(long cursoId)
        {
            CursoId = cursoId;
        }

        public long CursoId { get; set; }
    }

    public class ExcluirCursoGoogleCommandValidator : AbstractValidator<ExcluirCursoGoogleCommand>
    {
        public ExcluirCursoGoogleCommandValidator()
        {
            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("É necessário informar o id do curso que será excluido no Google Classroom.");
        }
    }
}