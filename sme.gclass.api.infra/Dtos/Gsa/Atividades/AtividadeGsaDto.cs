using System;

namespace SME.GoogleClassroom.Infra
{
    public class AtividadeGsaDto
    {
        public AtividadeGsaDto()
        {
        }

        public AtividadeGsaDto(string id, string cursoId, string titulo, string descricao, string usuarioClassroomId, object criadoEm, object alteradoEm, bool cursoCriadoManualmente, DateTime? dataEntrega = null, double? notaMaxima = 0)
        {
            Id = !string.IsNullOrWhiteSpace(id) && long.TryParse(id, out var idLong) ? idLong : 0;
            CursoId = !string.IsNullOrWhiteSpace(cursoId) && long.TryParse(cursoId, out var cursoIdLong) ? cursoIdLong : 0;
            Titulo = titulo;
            Descricao = descricao;
            UsuarioClassroomId = usuarioClassroomId;
            CriadoEm = criadoEm is DateTime criadoDt ? criadoDt : DateTime.MinValue;
            AlteradoEm = alteradoEm is DateTime alteradoDt ? alteradoDt : DateTime.MinValue;
            DataEntrega = dataEntrega;
            NotaMaxima = notaMaxima ?? 0;
            CursoCriadoManualmente = cursoCriadoManualmente;
        }

        public long Id { get; set; }
        public long CursoId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string UsuarioClassroomId { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }
        public DateTime? DataEntrega { get; set; }
        public double? NotaMaxima { get; set; }
        public bool CursoCriadoManualmente { get; set; }
    }
}
