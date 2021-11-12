using System;

namespace SME.GoogleClassroom.Infra
{
    public class AtividadeGsaDto
    {
        public AtividadeGsaDto(string id, string cursoId, string titulo, string descricao, string usuarioClassroomId, object criadoEm, object alteradoEm, bool cursoCriadoManualmente, DateTime? dataEntrega = null, double? notaMaxima = 0)
        {
            Id = long.Parse(id);
            CursoId = long.Parse(cursoId);
            Titulo = titulo;
            Descricao = descricao;
            UsuarioClassroomId = usuarioClassroomId;
            CriadoEm = (DateTime)criadoEm;
            AlteradoEm = (DateTime)alteradoEm;
            DataEntrega = dataEntrega.Value;
            NotaMaxima = notaMaxima ?? 0;
            CursoCriadoManualmente = cursoCriadoManualmente;
        }

        public long Id { get; }
        public long CursoId { get; }
        public string Titulo { get; }
        public string Descricao { get; set; }
        public string UsuarioClassroomId { get; }
        public DateTime CriadoEm { get; }
        public DateTime AlteradoEm { get; }
        public DateTime? DataEntrega { get; set; }
        public double? NotaMaxima { get; set; }
        public bool CursoCriadoManualmente { get; set; }
    }
}
