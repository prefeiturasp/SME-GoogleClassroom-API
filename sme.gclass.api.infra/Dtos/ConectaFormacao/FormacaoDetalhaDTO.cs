using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra.Dtos.ConectaFormacao
{
    public class FormacaoDetalhaDTO
    {
        public FormacaoDetalhaDTO(string codigoIE, string nomeIE, string codigoPL, string codigoCurso, string nomeCurso)
        {
            CodigoIE = codigoIE;
            NomeIE = nomeIE;
            CodigoPL = codigoPL;
            CodigoCurso = codigoCurso;
            NomeCurso = nomeCurso;
            Turmas = new List<FormacaoDetalhaTurmaDTO>();
        }

        public string CodigoIE { get;  }
        public string NomeIE { get; }
        public string CodigoPL { get;  }
        public string NomePL { get => CodigoPL; }
        public string CodigoCurso { get; }
        public string NomeCurso { get; }
        public string CodigoSerie { get => $"S.{CodigoCurso}"; }
        public string NomeSerie { get => NomeCurso; }
        public List<FormacaoDetalhaTurmaDTO> Turmas { get; }

        public void AdicionarTurma(long codigoTurma, string nomeTurma, IEnumerable<FormacaoDetalhaTurmaProfessoresDTO> professores)
        {
            var codigoDisciplina = $"D.{CodigoCurso}";

            Turmas.Add(new FormacaoDetalhaTurmaDTO(
                codigoTurma.ToString(),
                nomeTurma,
                codigoDisciplina,
                NomeCurso,
                $"{CodigoPL}-{CodigoCurso}-{codigoTurma}-{CodigoSerie}-{codigoDisciplina}",
                professores
                ));
        }
    }
}