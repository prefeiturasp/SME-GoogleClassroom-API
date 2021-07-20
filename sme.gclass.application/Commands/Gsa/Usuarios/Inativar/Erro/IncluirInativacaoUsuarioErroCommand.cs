using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirInativacaoUsuarioErroCommand : IRequest<long>
    {
        public UsuarioInativoErro AlunoInativoErro { get; set; }

        public IncluirInativacaoUsuarioErroCommand(UsuarioInativoErro alunoInativoErro)
        {
            AlunoInativoErro = alunoInativoErro;
        }
    }

    public class IncluirInativacaoUsuarioErroCommandValidator : AbstractValidator<IncluirInativacaoUsuarioErroCommand>
    {
        public IncluirInativacaoUsuarioErroCommandValidator()
        {
            RuleFor(a => a.AlunoInativoErro)
            .NotEmpty()
            .WithMessage("Deve ser informado o objeto de  usuário do Google Sala de Aula.");

            When(x => !(x.AlunoInativoErro is null), () =>
            {
                RuleFor(x => x.AlunoInativoErro.UsuarioId)
                .NotEmpty()
                .WithMessage("O identificador do usuário deve ser informado.");
            });
        }
    }
}
