using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuarioIdPorClassroomIdQuery : IRequest<long>
    {
        public ObterUsuarioIdPorClassroomIdQuery(string googleClassroomId)
        {
            GoogleClassroomId = googleClassroomId;
        }

        public string GoogleClassroomId { get; }
    }

    public class ObterUsuarioIdPorClassroomIdQueryValidator : AbstractValidator<ObterUsuarioIdPorClassroomIdQuery>
    {
        public ObterUsuarioIdPorClassroomIdQueryValidator()
        {
            RuleFor(a => a.GoogleClassroomId)
                .NotEmpty()
                .WithMessage("O id do google sala de aula deve ser informado para pesquisa de usuário");
        }
    }
}
