using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosNovosQuery : IRequest<PaginacaoResultadoDto<AlunoEol>>
    {
        public ObterAlunosNovosQuery(Paginacao paginacao, DateTime? dataReferencia)
        {
            Paginacao = paginacao;
            DataReferencia = dataReferencia;
        }

        public ObterAlunosNovosQuery(Paginacao paginacao, DateTime? dataReferencia, long? codigoEol)
            :this(paginacao, dataReferencia)
        {
            CodigoEol = codigoEol;
        }

        public Paginacao Paginacao { get; set; }

        public DateTime? DataReferencia { get; set; }

        public long? CodigoEol { get; set; }
    }

    public class ObterAlunosNovosQueryValidator : AbstractValidator<ObterAlunosNovosQuery>
    {
        public ObterAlunosNovosQueryValidator()
        {
            RuleFor(x => x.Paginacao)
                .NotEmpty()
                .WithMessage("A definição da paginação deve ser informada.");
        }
    }
}
