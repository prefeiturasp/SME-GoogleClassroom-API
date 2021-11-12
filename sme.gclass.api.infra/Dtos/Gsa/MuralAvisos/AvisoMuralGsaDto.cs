using System;

namespace SME.GoogleClassroom.Infra
{
    public class AvisoMuralGsaDto
    {
        public AvisoMuralGsaDto(string id, string cursoId, string usuarioClassroomId, string mensagem, object criadoEm, object alteradoEm, bool cursoCriadoManualmente)
        {
            Id = long.Parse(id);
            CursoId = long.Parse(cursoId);
            UsuarioClassroomId = usuarioClassroomId;
            Mensagem = mensagem;
            CriadoEm = (DateTime)criadoEm;
            AlteradoEm = (DateTime)alteradoEm;
            CursoCriadoManualmente = cursoCriadoManualmente;
        }

        public long Id { get; set; }
        public long CursoId { get; set; }
        public string UsuarioClassroomId { get; set; }
        public string Mensagem { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }
        public bool CursoCriadoManualmente { get; set; }
    }
}
