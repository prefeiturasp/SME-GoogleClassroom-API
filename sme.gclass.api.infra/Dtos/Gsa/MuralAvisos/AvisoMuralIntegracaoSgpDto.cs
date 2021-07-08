using System;

namespace SME.GoogleClassroom.Infra
{
    public class AvisoMuralIntegracaoSgpDto
    {
        public string TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public string UsuarioRf { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public string Mensagem { get; set; }
    }
}
