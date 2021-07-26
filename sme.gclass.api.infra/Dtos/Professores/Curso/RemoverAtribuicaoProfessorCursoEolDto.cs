using System;

namespace SME.GoogleClassroom.Infra
{
    public class RemoverAtribuicaoProfessorCursoEolDto
    {
        public long TurmaCodigo { get; set; }
        public long ComponenteCurricularCodigo { get; set; }
        public string UsuarioRf { get; set; }
        public string UsuarioNome { get; set; }
        public DateTime DataDisponibilizacao { get; set; }
        public int MotivoDisponibilizacao { get; set; }
    }
}
