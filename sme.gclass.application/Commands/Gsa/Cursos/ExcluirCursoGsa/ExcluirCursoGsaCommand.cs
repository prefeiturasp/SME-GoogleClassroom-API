using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExcluirCursoGsaCommand : IRequest<bool>
    {
        public ExcluirCursoGsaCommand(long cursoId)
        {
            CursoId = cursoId;
        }

        public long CursoId { get; set; }
    }

    public class ExcluirCursoGsaCommandValidator : AbstractValidator<ExcluirCursoGsaCommand>
    {
        public ExcluirCursoGsaCommandValidator()
        {
            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("O identificador do curso deve ser informado para exclusão.");
        }
    }
}
