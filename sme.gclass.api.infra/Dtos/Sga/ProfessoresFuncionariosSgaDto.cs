using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra.Dtos.Gsa
{
    public class ProfessoresFuncionariosSgaDto
    {
        public IEnumerable<FuncionarioEolSgaDto> Funcionarios { get; set; }
        public IEnumerable<ModalidadeEolSgaDto> Modalidades { get; set; }
    }
}