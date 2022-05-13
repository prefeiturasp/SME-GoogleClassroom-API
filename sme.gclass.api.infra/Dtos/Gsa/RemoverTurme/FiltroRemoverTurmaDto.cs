using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroRemoverTurmaDto
    {
        [Required(ErrorMessage = "O codigo da turma tem que ser informado")]
        public List<long> CodigoTurma { get; set; }
        public List<int> TipoTurma { get; set; }

        public FiltroRemoverTurmaDto()
        {
        }

        public FiltroRemoverTurmaDto(List<long> codigoTurma, List<int> tipoTurma)
        {
            CodigoTurma = codigoTurma;
            TipoTurma = tipoTurma;
        }
    }
}