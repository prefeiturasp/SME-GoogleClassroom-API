using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosIncluirGoogleQuery : IRequest<PaginacaoResultadoDto<CursoParaInclusaoDto>>
    {
        public ObterCursosIncluirGoogleQuery(DateTime ultimaExecucao, Paginacao paginacao)
        {
            UltimaExecucao = ultimaExecucao;
            Paginacao = paginacao;
        }
        public Paginacao Paginacao { get; set; }
        public DateTime UltimaExecucao { get; set; }
    }
}
