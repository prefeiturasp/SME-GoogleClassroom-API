using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SME.GoogleClassroom.Infra
{
    public class ComponenteCurricularTerritorioAtribuidoTurmaDTO
    {
        public long CodigoComponenteCurricular { get; set; }
        public string DescricaoComponenteCurricular { get; set; }
        public string AnoTurma { get; set; }
        public int AnoLetivo { get; set; }
        public long TurmaCodigo { get; set; }
        public string RfProfessor { get; set; }
        public long CodigoExperienciaPedagogica { get; set; }
        public long CodigoTerritorioSaber { get; set; }
        public string DescricaoTerritorioSaber { get; set; }
        public string DescricaoExperienciaPedagogica { get; set; }
        public DateTime DataAtribuicao { get; set; }
        public int AnoAtribuicao { get; set; }
        public DateTime DataFimTurma { get; set; }
        public DateTime? DataDisponibilizacao { get; set; }
        public long? CodigoMotivoDisponibilizacao { get; set; }
        public bool AtribuicaoExterna { get; set; }
        public string DescricaoAgrupamentoTerritorioSaber() => $"{DescricaoTerritorioSaber} - {DescricaoExperienciaPedagogica}";

        public bool EhVigente(DateTime? dataBase = null)
        {
            var data = dataBase ?? DateTime.Today;
            return DataAtribuicao <= data &&
                   (DataDisponibilizacao is null || DataDisponibilizacao >= data);
        }

    }

    public static class ListExtension
    {
        public static AgrupamentoAtribuicaoTerritorioSaber MapearDominio(this IEnumerable<ComponenteCurricularTerritorioAtribuidoTurmaDTO> componentesCurricularesTerritorioAtribuidoTurma)
        {
            if (componentesCurricularesTerritorioAtribuidoTurma.GroupBy(cc => new { cc.RfProfessor, cc.TurmaCodigo, cc.DataAtribuicao, cc.CodigoTerritorioSaber, cc.CodigoExperienciaPedagogica }).Count() > 1)
                throw new Exception("Somente é possível se utilizar deste mapeamento caso o agrupamento seja válido!");

            var componenteCurricularTerritorioAtribuidoTurma = componentesCurricularesTerritorioAtribuidoTurma.FirstOrDefault();
            return new AgrupamentoAtribuicaoTerritorioSaber()
            {
                CriadoEm = DateTime.Now,
                AlteradoEm = DateTime.Now,
                AnoLetivo = componenteCurricularTerritorioAtribuidoTurma.AnoLetivo,
                CodigoExperienciaPedagogica = componenteCurricularTerritorioAtribuidoTurma.CodigoExperienciaPedagogica,
                CodigoTerritorioSaber = componenteCurricularTerritorioAtribuidoTurma.CodigoTerritorioSaber,
                DescricaoExperienciaPedagogica = componenteCurricularTerritorioAtribuidoTurma.DescricaoExperienciaPedagogica,
                DescricaoTerritorioSaber = componenteCurricularTerritorioAtribuidoTurma.DescricaoTerritorioSaber,
                CodigoTurma = componenteCurricularTerritorioAtribuidoTurma.TurmaCodigo,
                DtFimAtribuicao = componenteCurricularTerritorioAtribuidoTurma.DataDisponibilizacao,
                DtInicioAtribuicao = componenteCurricularTerritorioAtribuidoTurma.DataAtribuicao,
                RfProfessor = componenteCurricularTerritorioAtribuidoTurma.RfProfessor,
                CodigosComponentesCurriculares = string.Join(',', componentesCurricularesTerritorioAtribuidoTurma.Select(cc => cc.CodigoComponenteCurricular)),
                CodigoMotivoDisponibilizacao = componenteCurricularTerritorioAtribuidoTurma.CodigoMotivoDisponibilizacao,
                AnoAtribuicao = componenteCurricularTerritorioAtribuidoTurma.AnoAtribuicao,
                DtFimTurma = componenteCurricularTerritorioAtribuidoTurma.DataFimTurma,
                AtribuicaoExterna = componenteCurricularTerritorioAtribuidoTurma.AtribuicaoExterna
            };
        }

        public static AgrupamentoAtribuicaoTerritorioSaber MapearDominio(this ComponenteCurricularTerritorioAtribuidoTurmaDTO componenteCurriculareTerritorioAtribuidoTurma, bool atribuirIdComCodigoComponenteCurricular = false)
        {
            return new AgrupamentoAtribuicaoTerritorioSaber()
            {
                CodigoAgrupamento = (atribuirIdComCodigoComponenteCurricular ? componenteCurriculareTerritorioAtribuidoTurma.CodigoComponenteCurricular : 0),
                CriadoEm = DateTime.Now,
                AlteradoEm = DateTime.Now,
                AnoLetivo = componenteCurriculareTerritorioAtribuidoTurma.AnoLetivo,
                CodigoExperienciaPedagogica = componenteCurriculareTerritorioAtribuidoTurma.CodigoExperienciaPedagogica,
                CodigoTerritorioSaber = componenteCurriculareTerritorioAtribuidoTurma.CodigoTerritorioSaber,
                DescricaoExperienciaPedagogica = componenteCurriculareTerritorioAtribuidoTurma.DescricaoExperienciaPedagogica,
                DescricaoTerritorioSaber = componenteCurriculareTerritorioAtribuidoTurma.DescricaoTerritorioSaber,
                CodigoTurma = componenteCurriculareTerritorioAtribuidoTurma.TurmaCodigo,
                DtFimAtribuicao = componenteCurriculareTerritorioAtribuidoTurma.DataDisponibilizacao,
                DtInicioAtribuicao = componenteCurriculareTerritorioAtribuidoTurma.DataAtribuicao,
                RfProfessor = componenteCurriculareTerritorioAtribuidoTurma.RfProfessor,
                CodigosComponentesCurriculares = componenteCurriculareTerritorioAtribuidoTurma.CodigoComponenteCurricular.ToString(),
                CodigoMotivoDisponibilizacao = componenteCurriculareTerritorioAtribuidoTurma.CodigoMotivoDisponibilizacao,
                AnoAtribuicao = componenteCurriculareTerritorioAtribuidoTurma.AnoAtribuicao,
                DtFimTurma = componenteCurriculareTerritorioAtribuidoTurma.DataFimTurma,
                AtribuicaoExterna = componenteCurriculareTerritorioAtribuidoTurma.AtribuicaoExterna
            };
        }

    }
}
