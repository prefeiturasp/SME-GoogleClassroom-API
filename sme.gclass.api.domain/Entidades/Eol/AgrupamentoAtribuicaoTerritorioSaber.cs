using System;
using System.Collections.Generic;
using System.Linq;

namespace SME.GoogleClassroom.Dominio
{
    public class AgrupamentoAtribuicaoTerritorioSaber
    {
        public AgrupamentoAtribuicaoTerritorioSaber()
        { }
        public long CodigoAgrupamento { get; set; }
        public long CodigoTerritorioSaber { get; set; }
        public long CodigoExperienciaPedagogica { get; set; }
        public DateTime DtInicioAtribuicao { get; set; }
        public int AnoAtribuicao { get; set; }
        public DateTime? DtFimAtribuicao { get; set; }
        public DateTime DtFimTurma { get; set; }
        public long? CodigoMotivoDisponibilizacao { get; set; }
        public string RfProfessor { get; set; }
        public long CodigoTurma { get; set; }
        public int AnoLetivo { get; set; }
        public string CodigosComponentesCurriculares { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public string DescricaoTerritorioSaber { get; set; }
        public string DescricaoExperienciaPedagogica { get; set; }
        public bool EncerramentoAtribuicaoViaAtualizacaoComponentesAgrupados { get; set; }
        public bool AtribuicaoExterna { get; set; }
        public IEnumerable<long> ComponentesCurricularesAgrupados { get { return CodigosComponentesCurriculares.Split(',').Select(cc => long.Parse(cc)); } }
        public bool TodosComponentesAgrupadosPertencemOutroAgrupamento(AgrupamentoAtribuicaoTerritorioSaber agrupamentoComparacao)
        {
            return !(agrupamentoComparacao is null) && ComponentesCurricularesAgrupados.All(cca => agrupamentoComparacao.ComponentesCurricularesAgrupados.Contains(cca));
        }
        public string DescricaoAgrupamentoTerritorioSaber() => $"{DescricaoTerritorioSaber} - {DescricaoExperienciaPedagogica}";

        public bool EhVigente(DateTime? dataBase = null)
        {
            var data = dataBase ?? DateTime.Today;
            return DtInicioAtribuicao <= data &&
                   (DtFimAtribuicao is null || DtFimAtribuicao >= data);
        }
    }
}

