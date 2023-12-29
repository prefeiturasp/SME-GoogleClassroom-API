using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra.Dtos.Gsa
{
    public class FormacaoCodigoNomeDataRealizacaoCoordenadoriaTurmasDTO
    {
        public long CodigoFormacao { get; set; }
        public string NomeFormacao { get; set; }
        public DateTime DataRealizacaoInicio { get; set; }
        public DateTime DataRealizacaoFim { get; set; }
        public string Coordenadoria { get; set; }
        public IEnumerable<CodigoNomeTurmaProfessoresDTO> Turmas { get; set; }
    }
}