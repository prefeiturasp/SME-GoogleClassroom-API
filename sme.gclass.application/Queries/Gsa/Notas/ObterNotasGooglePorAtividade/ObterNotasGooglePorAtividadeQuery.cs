using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterNotasGooglePorAtividadeQuery : IRequest<PaginaConsultaNotasGsaDto>
    {
        public ObterNotasGooglePorAtividadeQuery(DadosAvaliacaoDto dadosAtividade, string tokenProximaPagina = "")
        {
            DadosAtividade = dadosAtividade;
            TokenProximaPagina = tokenProximaPagina;
        }
        public DadosAvaliacaoDto DadosAtividade { get; set; }
        public string TokenProximaPagina { get; set; }
    }
}
