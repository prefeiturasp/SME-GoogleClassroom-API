using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirComparativoCursoCommand : IRequest<bool>
    {
        public InserirComparativoCursoCommand(CursoComparativo cursoComparativo)
        {
            Id = cursoComparativo.Id;
            Nome = cursoComparativo.Nome;
            Secao = cursoComparativo.Secao;
            CriadorId = cursoComparativo.CriadorId;
            Descricao = cursoComparativo.Descricao;
            DataInclusao = cursoComparativo.DataInclusao;
        }

        public InserirComparativoCursoCommand(string id, string nome, string secao, string criadorId, string descricao, DateTime dataInclusao)
        {
            Id = id;
            Nome = nome;
            Secao = secao;
            CriadorId = criadorId;
            Descricao = descricao;
            DataInclusao = dataInclusao;
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public string Secao { get; set; }
        public string CriadorId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInclusao { get; set; }
    }

    public class InserirComparativoCursoCommandValidator : AbstractValidator<InserirComparativoCursoCommand>
    {
        public InserirComparativoCursoCommandValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do curso deve ser informado.");

            RuleFor(x => x.Secao)
                .NotEmpty()
                .WithMessage("O nome da seção do curso deve ser informado.");

            RuleFor(x => x.CriadorId)
                .NotEmpty()
                .WithMessage("O ID do criador do curso deve ser informado.");

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("A Descrição do curso deve ser informada.");

            RuleFor(x => x.DataInclusao)
                .NotEmpty()
                .WithMessage("A data de inclusão do curso deve ser informado.");
        }
    }
}
