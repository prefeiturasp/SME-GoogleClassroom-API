using System;
using System.Collections.Generic;
using System.Linq;

namespace SME.GoogleClassroom.Infra
{
    public class ParametrosCargaInicialDto
    {
        public ParametrosCargaInicialDto()
        {
            TiposUes = new List<int>();
            Ues = new List<long>();
            Turmas = new List<long>();
        }

        public ParametrosCargaInicialDto(IList<int> tiposUes, IList<long> ues, IList<long> turmas, int? anoLetivo)
        {
            TiposUes = tiposUes ?? new List<int>();
            Ues = ues ?? new List<long>();
            Turmas = turmas ?? new List<long>();
            AnoLetivo = anoLetivo;
        }

        public IList<int> TiposUes { get; set; }
        public IList<long> Ues { get; set; }
        public IList<long> Turmas { get; set; }
        public int? AnoLetivo { get; set; }

        public void AdicionaTiposUe(string tiposUe)
        {
            if (string.IsNullOrWhiteSpace(tiposUe)) return;
            tiposUe
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.Parse(s.Trim()))
                .ToList()
                .ForEach(tipo => TiposUes.Add(tipo));
        }

        public void AdicionaUes(string ues)
        {
            if (string.IsNullOrWhiteSpace(ues)) return;
            ues
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => long.Parse(s.Trim()))
                .ToList()
                .ForEach(ue => Ues.Add(ue));
        }

        public void AdicionaTurmas(string turmas)
        {
            if (string.IsNullOrWhiteSpace(turmas)) return;
            turmas
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => long.Parse(s.Trim()))
                .ToList()
                .ForEach(turma => Turmas.Add(turma));
        }
    }
}
