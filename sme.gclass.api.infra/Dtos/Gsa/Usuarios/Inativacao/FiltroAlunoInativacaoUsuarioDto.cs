using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroAlunoInativacaoUsuarioDto
    {
        public FiltroAlunoInativacaoUsuarioDto(int anoLetivo, DateTime dataReferencia, IEnumerable<long> alunosIds)
        {
            AnoLetivo = anoLetivo;
            DataReferencia = dataReferencia;
            AlunosIds = alunosIds;
        }

        public int AnoLetivo { get; set; }
        public DateTime DataReferencia { get; set; }
        public IEnumerable<long> AlunosIds { get; set; }
    }
}
