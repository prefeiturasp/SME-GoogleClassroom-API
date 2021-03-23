using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirUsuarioCommand : IRequest<long>
    {
        public long? Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public UsuarioTipo Tipo { get; set; }
        public string OrganizationPath { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public IncluirUsuarioCommand(FuncionarioGoogle funcionarioGoogle)
            : this(usuarioGoogle: funcionarioGoogle)
        {
            Id = funcionarioGoogle.Rf;
        }

        public IncluirUsuarioCommand(ProfessorGoogle professorGoogle)
            : this(usuarioGoogle: professorGoogle)
        {
            Id = professorGoogle.Rf;
        }

        public IncluirUsuarioCommand(AlunoGoogle alunoGoogle)
            : this(usuarioGoogle: alunoGoogle)
        {
            Id = alunoGoogle.Codigo;
        }

        public IncluirUsuarioCommand(FuncionarioIndiretoGoogle funcionarioIndiretoGoogle)
            :this(usuarioGoogle: funcionarioIndiretoGoogle)
        {
            Cpf = funcionarioIndiretoGoogle.Cpf;
        }

        private IncluirUsuarioCommand(UsuarioGoogle usuarioGoogle)
        {
            Nome = usuarioGoogle.Nome;
            Email = usuarioGoogle.Email;
            Tipo = usuarioGoogle.UsuarioTipo;
            OrganizationPath = usuarioGoogle.OrganizationPath;
            DataInclusao = usuarioGoogle.DataInclusao;
            DataAtualizacao = usuarioGoogle.DataAtualizacao;
        }
    }

    public class IncluirUsuarioCommandValidator : AbstractValidator<IncluirUsuarioCommand>
    {
        public IncluirUsuarioCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .When(x => string.IsNullOrWhiteSpace(x.Cpf))
                .WithMessage("A identificação do usuário deve ser informada.");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .When(x => x.Id is null)
                .WithMessage("A identificação do usuário deve ser informada.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do usuário deve ser informado.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O email do usuário deve ser informado.");

            RuleFor(x => x.OrganizationPath)
                .NotEmpty()
                .WithMessage("A unidade organizacional do usuário deve ser informada.");

            RuleFor(x => x.DataInclusao)
                .NotEmpty()
                .WithMessage("A data de inclusão do usuário deve ser informada.");
        }
    }
}