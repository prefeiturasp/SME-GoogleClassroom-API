using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroAlunoErroDto
    {
        public FiltroAlunoErroDto()
        {
            TiposUes = new List<int>();
            Ues = new List<long>();
            Turmas = new List<long>();
        }

        public FiltroAlunoErroDto(UsuarioErro usuarioErro, int? anoLetivo, List<int> tiposUes, List<long> ues, List<long> turmas)
        {
            UsuarioErro = usuarioErro;
            AnoLetivo = anoLetivo;
            TiposUes = tiposUes ?? new List<int>();
            Ues = ues ?? new List<long>();
            Turmas = turmas ?? new List<long>();
        }

        public UsuarioErro UsuarioErro { get; set; }
        public int? AnoLetivo { get; set; }
        public List<int> TiposUes { get; set; }
        public List<long> Ues { get; set; }
        public List<long> Turmas { get; set; }

    }
}
