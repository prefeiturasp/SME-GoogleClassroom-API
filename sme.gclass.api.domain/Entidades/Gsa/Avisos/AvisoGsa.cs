using System;

namespace SME.GoogleClassroom.Dominio.Entidades.Gsa.Mural
{
    public class AvisoGsa
    {
        public string Id { get; set; }
        public string Texto { get; set; }
        public DateTime DataInclusao { get; set; }
        public string UsuarioId { get;  set; }
        public string CursoId { get; set; }

        public AvisoGsa(string id, string texto, DateTime dataInclusao, string usuarioId, string cursoId)
        {
            Id = id;
            Texto = texto;
            DataInclusao = dataInclusao;
            UsuarioId = usuarioId;
            CursoId = cursoId;
        }
    }
}