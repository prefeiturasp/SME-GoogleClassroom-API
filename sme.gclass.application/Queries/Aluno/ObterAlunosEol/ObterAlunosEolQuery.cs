using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosEolQuery : IRequest<PaginacaoResultadoDto<AlunoDto>>
    {
        public ObterAlunosEolQuery(Paginacao paginacacao)
        {
            this.Paginacacao = paginacacao;
        }

        public Paginacao Paginacacao { get; set; }
        public int AnoLetivo { get; set; }
        public DateTime DataReferencia { get; set; }
    }
}
