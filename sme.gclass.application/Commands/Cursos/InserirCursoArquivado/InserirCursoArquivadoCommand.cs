using FluentValidation;
using MediatR;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirCursoArquivadoCommand : IRequest
    {
        public InserirCursoArquivadoCommand(long cursoId, DateTime dataArquivamento, bool extinto)
        {
            CursoId = cursoId;
            DataArquivamento = dataArquivamento;
            Extinto = extinto;
        }

        public long CursoId { get; }
        public DateTime DataArquivamento { get; }
        public bool Extinto { get; }
    }

    public class InserirCursoArquivadoCommandValidator : AbstractValidator<InserirCursoArquivadoCommand>
    {
        public InserirCursoArquivadoCommandValidator()
        {
            RuleFor(a => a.CursoId)
                .NotEmpty()
                .WithMessage("O id do curso deve ser informado para arquivamento do curso");

            RuleFor(a => a.DataArquivamento)
                .NotEmpty()
                .WithMessage("A data do arquivamento deve ser informada para arquivamento do curso");
        }
    }
}
