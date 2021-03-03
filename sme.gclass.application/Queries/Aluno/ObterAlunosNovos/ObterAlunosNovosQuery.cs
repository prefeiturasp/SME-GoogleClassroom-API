using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosNovosQuery : IRequest<PaginacaoResultadoDto<AlunoEol>>
    {
        public ObterAlunosNovosQuery(Paginacao paginacao, DateTime dataReferencia, long codigoEol)
        {
            Paginacao = paginacao;
            DataReferencia = dataReferencia;
            CodigoEol = codigoEol;
        }

        public Paginacao Paginacao { get; set; }

        public DateTime DataReferencia { get; set; }

        public long CodigoEol { get; set; }
    }
}
