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
            TiposUes = tiposUes;
            Ues = ues;
            Turmas = turmas;
            AnoLetivo = anoLetivo;
        }

        public IList<int> TiposUes { get; set; }
        public IList<long> Ues { get; set; }
        public IList<long> Turmas { get; set; }
        public int? AnoLetivo { get; set; }

        public void AdicionaTiposUe(string tiposUe)
        {
            tiposUe
                .Split(',')
                .Select(int.Parse)
                .ToList()
                .ForEach(tipo => TiposUes.Add(tipo));
        }

        public void AdicionaUes(string ues)
        {
            ues
                .Split(',')
                .Select(long.Parse)
                .ToList()
                .ForEach(ue => Ues.Add(ue));
        }

        public void AdicionaTurmas(string turmas)
        {
            turmas
                .Split(',')
                .Select(long.Parse)
                .ToList()
                .ForEach(turma => Turmas.Add(turma));
        }
    }
}
