using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra.Dtos.Gsa
{
    public class ModalidadeEolSgaDto
    {

        public string NomeModalidade { get; set; }
        public IEnumerable<TurmaEolGsaDto> Turmas { get; set; }
    }
}