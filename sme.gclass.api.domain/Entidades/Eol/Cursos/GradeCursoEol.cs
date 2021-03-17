using System;

namespace SME.GoogleClassroom.Dominio
{
    public class GradeCursoEol
    {
        public string Nome { get; set; }
        public string Secao { get; set; }
        public long ComponenteCurricularId { get; set; }
        public long TurmaId { get; set; }
        public string UeCodigo { get; set; }
        public string Email { get; set; }
        public DateTime DataInicioGrade { get; set; }

        protected GradeCursoEol()
        {
        }
    }
}