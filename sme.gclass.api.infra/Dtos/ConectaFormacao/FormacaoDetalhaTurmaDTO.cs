using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra.Dtos.ConectaFormacao
{
    public class FormacaoDetalhaTurmaDTO
    {
        public FormacaoDetalhaTurmaDTO(string codigoTurma, string nomeTurma, string codigoDisciplina, string nomeDisciplina, string codigoTurmaDisciplina, IEnumerable<FormacaoDetalhaTurmaProfessoresDTO> professores)
        {
            CodigoTurma = codigoTurma;
            NomeTurma = nomeTurma;
            CodigoDisciplina = codigoDisciplina;
            NomeDisciplina = nomeDisciplina;
            CodigoTurmaDisciplina = codigoTurmaDisciplina;
            Professores = professores;
        }

        public string CodigoTurma { get;  }
        public string NomeTurma { get;  }
        public string CodigoDisciplina { get; }
        public string NomeDisciplina { get; }
        public string CodigoTurmaDisciplina { get; }
        public IEnumerable<FormacaoDetalhaTurmaProfessoresDTO> Professores { get; }
    }
}