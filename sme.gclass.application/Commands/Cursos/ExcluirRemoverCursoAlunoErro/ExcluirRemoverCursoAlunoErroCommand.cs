using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExcluirRemoverCursoAlunoErroCommand : IRequest<bool>
    {
        
        public long UsuarioId { get; set; }
        public long CursoId { get; set; }

        public ExcluirRemoverCursoAlunoErroCommand(long usuarioId, long cursoId)
        {
            UsuarioId = usuarioId;
            CursoId = cursoId;
        }
    }

    public class ExcluirRemoverCursoAlunoErroCommandValidator : AbstractValidator<ExcluirRemoverCursoAlunoErroCommand>
    {
        public ExcluirRemoverCursoAlunoErroCommandValidator()
        {

            RuleFor(c => c.UsuarioId)
                   .NotEmpty()
                   .WithMessage("O id do usuario erro deve ser informado para exclusão.");
            
            
            RuleFor(c => c.CursoId)
                .NotEmpty()
                .WithMessage("O id do curso erro deve ser informado para exclusão.");
        }
    }
}
