using System;

namespace SME.GoogleClassroom.Dominio
{
    public class CursoComparativo
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Secao { get; set; }
        public string CriadorId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}
