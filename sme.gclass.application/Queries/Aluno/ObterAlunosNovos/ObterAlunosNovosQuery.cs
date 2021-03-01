using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosNovosQuery : IRequest<PaginacaoResultadoDto<AlunoEol>>
    {
        public ObterAlunosNovosQuery(DateTime dataReferencia, Paginacao paginacao)
        {
            this.Paginacao = paginacao;
            this.DataReferencia = dataReferencia;
        }

        public Paginacao Paginacao { get; set; }

        public DateTime DataReferencia { get; set; }
    }
}
