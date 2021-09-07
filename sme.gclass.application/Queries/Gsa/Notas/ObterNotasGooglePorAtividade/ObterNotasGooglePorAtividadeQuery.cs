using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterNotasGooglePorAtividadeQuery : IRequest<PaginaConsultaNotasGsaDto>
    {
        public ObterNotasGooglePorAtividadeQuery(DadosAvaliacaoNotasGsaDto dadosAtividade, string tokenProximaPagina = "")
        {
            DadosAtividade = dadosAtividade;
            TokenProximaPagina = tokenProximaPagina;
        }
        public DadosAvaliacaoNotasGsaDto DadosAtividade { get; set; }
        public string TokenProximaPagina { get; set; }
    }
}
