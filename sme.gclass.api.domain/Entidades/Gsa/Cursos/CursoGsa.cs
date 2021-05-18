using System;

namespace SME.GoogleClassroom.Dominio
{
    public class CursoGsa
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Secao { get; set; }
        public string CriadorId { get; set; }
        public string Descricao { get; set; }
        public bool InseridoManualmenteGoogle { get; set; }
        public DateTime DataInclusao { get; set; }

        public CursoGsa(string id, string nome, string secao, string criadorId, string descricao, bool inseridoManualmenteGoogle, DateTime? dataInclusao = null)
        {
            Id = id;
            Nome = nome;
            Secao = secao;
            CriadorId = criadorId;
            Descricao = descricao;
            InseridoManualmenteGoogle = inseridoManualmenteGoogle;
            DataInclusao = dataInclusao ?? DateTime.Now;
        }
    }
}
