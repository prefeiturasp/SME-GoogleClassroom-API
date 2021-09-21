using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroAlunoErroDto
    {
        public FiltroAlunoErroDto(UsuarioErro usuarioErro, int? anoLetivo, List<int> tiposUes, List<long> ues, List<long> turmas)
        {
            UsuarioErro = usuarioErro;
            AnoLetivo = anoLetivo;
            TiposUes = tiposUes;
            Ues = ues;
            Turmas = turmas;
        }

        public UsuarioErro UsuarioErro { get; set; }
        public int? AnoLetivo { get; set; }
        public List<int> TiposUes { get; set; }
        public List<long> Ues { get; set; }
        public List<long> Turmas { get; set; }

    }
}
