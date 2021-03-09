namespace SME.GoogleClassroom.Dominio.Entidades.Eol.Cursos
{
    public class CursoEol
    {
        public string Nome { get; set; }
        public string Secao { get; set; }
        public long ComponenteCurricularId { get; set; }
        public long TurmaId { get; set; }
        public string UeCodigo { get; set; }
        public string Email { get; set; }
    }
}