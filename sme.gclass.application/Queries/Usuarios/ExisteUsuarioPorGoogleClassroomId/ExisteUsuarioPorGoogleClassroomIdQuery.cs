using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteUsuarioPorGoogleClassroomIdQuery : IRequest<bool>
    {
        public string GoogleClassroomId { get; set; }

        public ExisteUsuarioPorGoogleClassroomIdQuery(string googleClassroomId)
        {
            GoogleClassroomId = googleClassroomId;
        }
    }

    public class ExisteUsuarioPorGoogleClassroomIdQueryValidator : AbstractValidator<ExisteUsuarioPorGoogleClassroomIdQuery>
    {
        public ExisteUsuarioPorGoogleClassroomIdQueryValidator()
        {
            RuleFor(x => x.GoogleClassroomId)
                .NotEmpty()
                .WithMessage("O identificador do usuário no GoogleClassroom deve ser informado.");
        }
    }
}