using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirUsuarioCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public UsuarioTipo Tipo { get; set; }
        public string OrganizationPath { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public IncluirUsuarioCommand(long id, string nome, string email, UsuarioTipo tipo, string organizationPath, DateTime dataInclusao, DateTime? dataAtualizacao = null)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Tipo = tipo;
            OrganizationPath = organizationPath;
            DataInclusao = dataInclusao;
            DataAtualizacao = dataAtualizacao;
        }

        public IncluirUsuarioCommand(FuncionarioGoogle funcionarioGoogle)
        {
            Id = funcionarioGoogle.Rf;
            Nome = funcionarioGoogle.Nome;
            Email = funcionarioGoogle.Email;
            Tipo = UsuarioTipo.Funcionario;
            OrganizationPath = funcionarioGoogle.OrganizationPath;
            DataInclusao = funcionarioGoogle.DataInclusao;
            DataAtualizacao = funcionarioGoogle.DataAtualizacao;
        }

        public IncluirUsuarioCommand(ProfessorGoogle professorGoogle)
        {
            Id = professorGoogle.Rf;
            Nome = professorGoogle.Nome;
            Email = professorGoogle.Email;
            Tipo = UsuarioTipo.Funcionario;
            OrganizationPath = professorGoogle.OrganizationPath;
            DataInclusao = professorGoogle.DataInclusao;
            DataAtualizacao = professorGoogle.DataAtualizacao;
        }
    }

    public class IncluirUsuarioCommandValidator : AbstractValidator<IncluirUsuarioCommand>
    {
        public IncluirUsuarioCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
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