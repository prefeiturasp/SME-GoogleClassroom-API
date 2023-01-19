using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra.Dtos.Gsa
{
    public class ProfessoresFuncionariosSgaDto
    {
        public IEnumerable<FuncionarioEolGsaDto> Funcionarios { get; set; }
        public IEnumerable<FuncionarioEolGsaDto> Professores { get; set; }
    }
}