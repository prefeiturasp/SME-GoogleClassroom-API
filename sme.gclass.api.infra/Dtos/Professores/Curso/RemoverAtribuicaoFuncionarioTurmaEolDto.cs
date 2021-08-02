using System;

namespace SME.GoogleClassroom.Infra
{
    public class RemoverAtribuicaoFuncionarioTurmaEolDto
    {
        public string UsuarioRf { get; set; }
        public string UsuarioNome { get; set; }
        public long TurmaCodigo { get; set; }
        public long ComponenteCurricularCodigo { get; set; }
        public long UeCodigo { get; set; }
        public DateTime FimNomeacao { get; set; }
    }
}
