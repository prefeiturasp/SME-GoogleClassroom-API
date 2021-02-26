using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCadastradosQuery : IRequest<PaginacaoResultadoDto<Usuario>>
    {
        public ObterAlunosCadastradosQuery(Paginacao paginacacao)
        {
            this.Paginacacao = paginacacao;
        }

        public Paginacao Paginacacao { get; set; }
    }
}
