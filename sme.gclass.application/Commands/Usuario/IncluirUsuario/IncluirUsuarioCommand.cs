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
            Tipo = UsuarioTipo.Professor;
            OrganizationPath = professorGoogle.OrganizationPath;
            DataInclusao = professorGoogle.DataInclusao;
            DataAtualizacao = professorGoogle.DataAtualizacao;
        }

        public IncluirUsuarioCommand(AlunoGoogle alunoGoogle)
        {
            Id = alunoGoogle.Codigo;
            Nome = alunoGoogle.Nome;
            Email = alunoGoogle.Email;
            Tipo = UsuarioTipo.Aluno;
            OrganizationPath = alunoGoogle.OrganizationPath;
            DataInclusao = alunoGoogle.DataInclusao;
            DataAtualizacao = alunoGoogle.DataAtualizacao;
        }

        public IncluirUsuarioCommand(FuncionarioIndiretoGoogle funcionarioIndiretoGoogle)
        {
            Cpf = funcionarioIndiretoGoogle.Cpf;
            Nome = funcionarioIndiretoGoogle.Nome;
            Email = funcionarioIndiretoGoogle.Email;
            Tipo = UsuarioTipo.FuncionarioIndireto;
            OrganizationPath = funcionarioIndiretoGoogle.OrganizationPath;
            DataInclusao = funcionarioIndiretoGoogle.DataInclusao;
            DataAtualizacao = funcionarioIndiretoGoogle.DataAtualizacao;
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