using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtribuirDonoCursoCommand : IRequest<bool>
    {
        public AtribuirDonoCursoCommand(long turmaId, long componenteCurricularId, string googleClassroomId, string usuarioEmail)
        {
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            GoogleClassroomId = googleClassroomId;
            UsuarioEmail = usuarioEmail;
        }

        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public string GoogleClassroomId { get; set; }
        public string UsuarioEmail { get; set; }
    }

    public class AtribuirDonoCursoCommandValidator : AbstractValidator<AtribuirDonoCursoCommand>
    {
        public AtribuirDonoCursoCommandValidator()
        {
            RuleFor(x => x.TurmaId)
                .NotEmpty()
                .WithMessage("A turma deve ser informado para atribuir o dono.");

            RuleFor(x => x.ComponenteCurricularId)
                .NotEmpty()
                .WithMessage("O componente curricular deve ser informado para atribuir o dono.");

            RuleFor(x => x.GoogleClassroomId)
                .NotEmpty()
                .WithMessage("O usuario deve ser informado para atribuir o dono.");

            RuleFor(x => x.UsuarioEmail)
                .NotEmpty()
                .WithMessage("O usuario deve ser informado para atribuir o dono.");
        }
    }
}
