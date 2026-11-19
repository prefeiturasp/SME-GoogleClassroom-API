using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterNotasAtividadesAvaliativasQuery : IRequest<PaginacaoResultadoDto<NotasAtividadesDto>>
    {
        public ObterNotasAtividadesAvaliativasQuery(Paginacao paginacao, long? atividadeId, DateTime dataReferencia)
        {
            Paginacao = paginacao;
            AtividadeId = atividadeId;
            DataReferencia = dataReferencia;
        }

        public Paginacao Paginacao { get; set; }
        public long? AtividadeId { get; set; }
        public DateTime DataReferencia { get; set; }
    }

    public class ObterNotasAtividadesAvaliativasQueryValidator : AbstractValidator<ObterNotasAtividadesAvaliativasQuery>
    {
        public ObterNotasAtividadesAvaliativasQueryValidator()
        {
            RuleFor(x => x.DataReferencia)
                .NotEmpty()
                .NotNull()
                .WithMessage("A data de importação deve ser informada.");
        }
    }
}
