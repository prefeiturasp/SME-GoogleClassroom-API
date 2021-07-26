using FluentValidation;
using MediatR;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ArquivarCursoExtintoQuery: IRequest<long>
    {
        public ArquivarCursoExtintoQuery(long cursoId, DateTime dataArquivamento, bool extinto)
        {
            CursoId = cursoId;
            DataArquivamento = dataArquivamento;
            Extinto = extinto;
        }

        public long CursoId { get; set; }
        public DateTime DataArquivamento { get; set; }
        public bool Extinto { get; set; }
    }

    public class ArquivarCursoExtintoQueryValidator : AbstractValidator<ArquivarCursoExtintoQuery>
    {
        public ArquivarCursoExtintoQueryValidator()
        {
            RuleFor(a => a.CursoId)
                .NotEmpty()
                .WithMessage("O curso deve ser informado");

            RuleFor(a => a.DataArquivamento)
                .NotEmpty()
                .WithMessage("A data de arquivamento deve ser informada");

        }
    }
}
