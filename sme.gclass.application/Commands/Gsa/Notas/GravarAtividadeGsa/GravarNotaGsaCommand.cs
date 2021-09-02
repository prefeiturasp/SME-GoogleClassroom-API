using FluentValidation;
using MediatR;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class GravarNotaGsaCommand : IRequest
    {
        public long Id { get; set; }
        public long AtividadeId { get; set; }
        public long UsuarioId { get; set; }
        public double Nota { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }

    public class GravarNotaGsaCommandValidator : AbstractValidator<GravarNotaGsaCommand>
    {
        public GravarNotaGsaCommandValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty()
                .WithMessage("O indice da nota deve ser informado para geração da atividade avaliativa");

            RuleFor(a => a.AtividadeId)
                .NotEmpty()
                .WithMessage("O indice da atividade deve ser informado para geração da atividade avaliativa");

            RuleFor(a => a.UsuarioId)
                .NotEmpty()
                .WithMessage("O indice do usuário deve ser informado para geração da atividade avaliativa");

            RuleFor(a => a.Nota)
                .NotNull()
                .WithMessage("A nota ser informada");

            RuleFor(a => a.DataInclusao)
                .NotEmpty()
                .WithMessage("A data de inclusão da nota deve ser informada");
        }
    }
}
