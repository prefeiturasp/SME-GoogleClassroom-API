using System;
using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtividadesQuery : IRequest<PaginacaoResultadoDto<AtividadeGsa>>
    {
        public AtividadesQuery(Paginacao paginacao, DateTime dataReferencia, long? cursoId)
        {
            Paginacao = paginacao;
            DataReferencia = dataReferencia;
            CursoId = cursoId;
        }

        public Paginacao Paginacao { get; set; }
        public DateTime DataReferencia { get; set; }
        public long? CursoId { get; set; }
    }

    public class AtividadesQueryValidator : AbstractValidator<ObterAvisoQuery>
    {
        public AtividadesQueryValidator()
        {
            RuleFor(x => x.DataReferencia)
                .NotEmpty()
                .WithMessage("Parâmetro data de referência não pode ser nulo");
        }
    }
}