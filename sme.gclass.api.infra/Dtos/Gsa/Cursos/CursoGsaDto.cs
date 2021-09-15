using System;

namespace SME.GoogleClassroom.Infra
{
    public class CursoGsaDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Secao { get; set; }
        public string CriadorId { get; set; }
        public string Descricao { get; set; }
        public string Situacao { get; set; }
        public DateTime? DataInclusao { get; set; }
        public bool UltimoItemDaFila { get; set; }
    }
}