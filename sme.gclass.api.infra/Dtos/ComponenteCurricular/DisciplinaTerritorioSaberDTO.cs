using System;

namespace SME.Pedagogico.Interface.DTO.RetornoQueryDTO
{
    public class DisciplinaTerritorioSaberDTO
    {
        public long CodigoExperienciaPedagogica { get; set; }
        public long CodigoTerritorioSaber { get; set; }
        public string DescricaoTerritorioSaber { get; set; }
        public string DescricaoExperienciaPedagogica { get; set; }
        public DateTime DataInicio { get; set; }
        public long CodigoComponenteCurricular { get; set; }
 
        public string ObterDescricaoComponenteCurricular()
        {
            return $"{DescricaoTerritorioSaber} - {DescricaoExperienciaPedagogica}";
        }

        public bool ComparaCodigoComponenteCurricular(long codigo)
        {
            if (DataInicio != DateTime.MinValue)
                return codigo == long.Parse(DataInicio.ToString("MMdd"));
            return false;
        }
    }
}
