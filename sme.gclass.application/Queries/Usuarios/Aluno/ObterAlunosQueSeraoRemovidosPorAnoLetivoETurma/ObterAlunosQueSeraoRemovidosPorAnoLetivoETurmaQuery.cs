using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosQueSeraoRemovidosPorAnoLetivoETurmaQuery : IRequest<PaginacaoResultadoDto<AlunoRemocaoDto>>
    {
        public ObterAlunosQueSeraoRemovidosPorAnoLetivoETurmaQuery(ParametrosCargaInicialDto parametrosCargaInicialDto, Paginacao paginacao, int anoLetivo, long turmaId, DateTime dataReferencia, bool ehDataReferenciaPrincipal)
        {
            Paginacao = paginacao;
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
            DataReferencia = dataReferencia;
            EhDataReferenciaPrincipal = ehDataReferenciaPrincipal;
            ParametrosCargaInicialDto = parametrosCargaInicialDto;
        }

        public Paginacao Paginacao { get; set; }
        public int AnoLetivo { get; set; } 
        public long TurmaId { get; set; }
        public DateTime DataReferencia { get; set; }
        public bool EhDataReferenciaPrincipal { get; set; }
        public ParametrosCargaInicialDto ParametrosCargaInicialDto { get; set; }
    }
}
