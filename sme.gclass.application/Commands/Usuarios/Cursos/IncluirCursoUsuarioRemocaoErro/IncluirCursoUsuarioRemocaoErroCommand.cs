using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirCursoUsuarioRemocaoErroCommand : IRequest<long>
    {
        public UsuarioCursoRemovidoGsaErro UsuarioCursoRemovidoGsaErro { get; set; }

        public IncluirCursoUsuarioRemocaoErroCommand(UsuarioCursoRemovidoGsaErro usuarioCursoRemovidoGsaErro)
        {
            UsuarioCursoRemovidoGsaErro = usuarioCursoRemovidoGsaErro;
        }
    }

    public class IncluirCursoUsuarioRemocaoCommandValidator : AbstractValidator<IncluirCursoUsuarioRemocaoErroCommand>
    {
        public IncluirCursoUsuarioRemocaoCommandValidator()
        {
            RuleFor(a => a.UsuarioCursoRemovidoGsaErro)
            .NotEmpty()
            .WithMessage("Deve ser informado o registro de relação entre usuário e curso do Google Sala de Aula.");

            When(x => !(x.UsuarioCursoRemovidoGsaErro is null), () =>
            {
                RuleFor(x => x.UsuarioCursoRemovidoGsaErro.UsuarioId)
                .NotEmpty()
                .WithMessage("O identificador do usuário deve ser informado.");

                RuleFor(x => x.UsuarioCursoRemovidoGsaErro.CursoId)
                    .NotEmpty()
                    .WithMessage("O identificador do curso deve ser informado.");
            });
        }
    }
}