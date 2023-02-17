using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra.Dtos.Gsa
{
    public class ProfessoresFuncionariosDto
    {
        public IEnumerable<FuncionarioEolDto> Funcionarios { get; set; }
        public IEnumerable<ModalidadeEolDto> Modalidades { get; set; }
    }
}