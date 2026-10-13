using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Infra.Dtos.Atividades
{
    public class AtividadeDto
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string UsuarioGsaId { get; set; }
        public long CursoGsaId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime? DataEntrega { get; set; }
        public double NotaMaxima { get; set; }
    }
}
