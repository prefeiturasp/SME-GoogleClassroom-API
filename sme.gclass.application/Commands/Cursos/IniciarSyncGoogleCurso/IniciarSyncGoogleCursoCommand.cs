using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncGoogleCursoCommand : IRequest<bool>
    {
        public long? TurmaId { get; set; }
        public long? ComponenteCurricularId { get; set; }

        public IniciarSyncGoogleCursoCommand(long? turmaId, long? componenteCurricularId)
        {
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }
    }

    public class IniciarSyncGoogleCursoCommandValidator : AbstractValidator<IniciarSyncGoogleCursoCommand>
    {
        public IniciarSyncGoogleCursoCommandValidator()
        {
            When(x => x.TurmaId.HasValue || x.ComponenteCurricularId.HasValue, () =>
            {
                RuleFor(x => x.TurmaId)
                    .NotEmpty()
                    .WithMessage("Para utilizar o filtro de sincronização deve-se informar a turma e o componente curricular.");

                RuleFor(x => x.ComponenteCurricularId)
                    .NotEmpty()
                    .WithMessage("Para utilizar o filtro de sincronização deve-se informar a turma e o componente curricular.");
            });
        }
    }
}