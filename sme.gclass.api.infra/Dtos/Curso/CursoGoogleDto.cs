using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Infra
{
    public class CursoGoogleDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Secao { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public string Email { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool? ExisteGoogle { get; set; }
    }
}
