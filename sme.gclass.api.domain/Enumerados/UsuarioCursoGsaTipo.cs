using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Dominio
{
    public enum UsuarioCursoGsaTipo
    {
        [Display(Description = "Estudante")]
        Estudante = 1,

        [Display(Description = "Professor")]
        Professor = 2
    }
}