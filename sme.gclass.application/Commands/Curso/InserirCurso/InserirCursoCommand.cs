using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirCursoCommand : IRequest<long>
    {
        public InserirCursoCommand(CursoGoogle cursoGoogle)
        {
            Email = cursoGoogle.Email;
            Nome = cursoGoogle.Nome;
            Secao = cursoGoogle.Secao;
            TurmaId = cursoGoogle.TurmaId;
            ComponenteCurricularId = cursoGoogle.ComponenteCurricularId;
            DataInclusao = cursoGoogle.DataInclusao;
        }

        public InserirCursoCommand(long id, string email, string nome, string secao, long turmaId, long componenteCurricularId, DateTime dataInclusao, DateTime? dataAtualizacao)
        {
            Id = id;
            Email = email;
            Nome = nome;
            Secao = secao;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            DataInclusao = dataInclusao;
            DataAtualizacao = dataAtualizacao;
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Secao { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }

    public class InserirCursoCommandValidator : AbstractValidator<InserirCursoCommand>
    {
        public InserirCursoCommandValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do curso deve ser informado.");

            RuleFor(x => x.Secao)
                .NotEmpty()
                .WithMessage("O nome da seção do curso deve ser informado.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail do criador do curso deve ser informado.");

            RuleFor(x => x.TurmaId)
                .NotEmpty()
                .WithMessage("A turma do curso deve ser informado.");

            RuleFor(x => x.ComponenteCurricularId)
                .NotEmpty()
                .WithMessage("O componente curricular do curso deve ser informado.");

            RuleFor(x => x.DataInclusao)
                .NotEmpty()
                .WithMessage("A data de inclusão do curso deve ser informado.");
        }
    }
}
