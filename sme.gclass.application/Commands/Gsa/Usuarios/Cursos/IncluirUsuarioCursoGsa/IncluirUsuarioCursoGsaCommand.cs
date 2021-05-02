using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirUsuarioCursoGsaCommand : IRequest<bool>
    {
        public IncluirUsuarioCursoGsaCommand(UsuarioCursoGsa usuarioCursoGsa)
        {
            UsuarioCursoGsa = usuarioCursoGsa;
        }

        public UsuarioCursoGsa UsuarioCursoGsa { get; }
    }

    public class IncluirUsuarioCursoGsaCommandValidator : AbstractValidator<IncluirUsuarioCursoGsaCommand>
    {
        public IncluirUsuarioCursoGsaCommandValidator()
        {
            RuleFor(a => a.UsuarioCursoGsa)
                .NotEmpty()
                .WithMessage("Deve ser informado o registro de relação entre usuário e curso do Google Sala de Aula.");

            When(x => !(x.UsuarioCursoGsa is null), () =>
            {
                RuleFor(x => x.UsuarioCursoGsa.UsuarioId)
                .NotEmpty()
                .WithMessage("O identificador do usuário deve ser informado.");

                RuleFor(x => x.UsuarioCursoGsa.CursoId)
                    .NotEmpty()
                    .WithMessage("O identificador do curso deve ser informado.");
            });
        }
    }
}