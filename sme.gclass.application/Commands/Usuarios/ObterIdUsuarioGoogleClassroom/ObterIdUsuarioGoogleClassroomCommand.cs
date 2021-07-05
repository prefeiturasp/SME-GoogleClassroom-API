using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao.Commands.Usuarios.ConsultarUsuarioGoogleClassroom
{
    public class ObterIdUsuarioGoogleClassroomCommand : IRequest<string>
    {
        public string Email { get; set; }

        public ObterIdUsuarioGoogleClassroomCommand(string email)
        {
            Email = email;
        }
    }

    public class ObterIdUsuarioGoogleClassroomCommandValidator : AbstractValidator<ObterIdUsuarioGoogleClassroomCommand>
    {
        public ObterIdUsuarioGoogleClassroomCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail deve ser informado para consulta do usuário no Google Classroom.");
        }
    }
}
