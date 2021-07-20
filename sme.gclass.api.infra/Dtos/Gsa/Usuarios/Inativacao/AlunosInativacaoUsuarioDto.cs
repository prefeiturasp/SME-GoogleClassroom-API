using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class AlunosInativacaoUsuarioDto
    {
        public AlunosInativacaoUsuarioDto(IEnumerable<long> alunosCodigos)
        {
            AlunosCodigos = alunosCodigos;
        }

        public IEnumerable<long> AlunosCodigos { get; set; }
    }
}
