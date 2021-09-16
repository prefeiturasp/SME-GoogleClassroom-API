using System;

namespace SME.GoogleClassroom.Infra
{
    public class CarregarTurmaInativacaoUsuarioDto
    {
        public CarregarTurmaInativacaoUsuarioDto(DateTime dataReferencia, long? alunoId = null)
        {
            DataReferencia = dataReferencia;
            AlunoId = alunoId;
        }

        public DateTime DataReferencia { get; set; }

        public long? AlunoId { get; set; }
    }
}
