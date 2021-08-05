using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuarioPorClassroomIdQuery : IRequest<UsuarioGoogleDto>
    {
        public ObterUsuarioPorClassroomIdQuery(string googleClassroomId)
        {
            GoogleClassroomId = googleClassroomId;
        }

        public string GoogleClassroomId { get; }
    }

    public class ObterUsuarioIdPorClassroomIdQueryValidator : AbstractValidator<ObterUsuarioPorClassroomIdQuery>
    {
        public ObterUsuarioIdPorClassroomIdQueryValidator()
        {
            RuleFor(a => a.GoogleClassroomId)
                .NotEmpty()
                .WithMessage("O id do google sala de aula deve ser informado para pesquisa de usuário");
        }
    }
}
