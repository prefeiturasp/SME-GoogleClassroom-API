using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class GravarNotaGsaCommand : IRequest
    {
        public GravarNotaGsaCommand(string id, long atividadeId, long usuarioId, double? nota, StatusGSA status, DateTime dataInclusao, DateTime? dataAlteracao = null)
        {
            Id = id;
            AtividadeId = atividadeId;
            UsuarioId = usuarioId;
            Nota = nota;
            Status = status;
            DataInclusao = dataInclusao;
            DataAlteracao = dataAlteracao;
        }

        public string Id { get; set; }
        public long AtividadeId { get; set; }
        public long UsuarioId { get; set; }
        public double? Nota { get; set; }
        public StatusGSA Status { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }

    public class GravarNotaGsaCommandValidator : AbstractValidator<GravarNotaGsaCommand>
    {
        public GravarNotaGsaCommandValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty()
                .WithMessage("O índice da nota deve ser informado para geração da nota");

            RuleFor(a => a.AtividadeId)
                .NotEmpty()
                .WithMessage("O índice da atividade deve ser informado para geração da nota");

            RuleFor(a => a.UsuarioId)
                .NotEmpty()
                .WithMessage("O índice do usuário deve ser informado para geração da nota");

            RuleFor(a => a.DataInclusao)
                .NotEmpty()
                .WithMessage("A data de inclusão da nota deve ser informada");
        }
    }
}
