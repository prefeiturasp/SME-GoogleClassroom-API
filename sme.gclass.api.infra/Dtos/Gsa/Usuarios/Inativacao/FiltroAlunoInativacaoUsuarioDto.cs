using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroAlunoInativacaoUsuarioDto
    {
        public FiltroAlunoInativacaoUsuarioDto(DateTime dataReferencia, IEnumerable<long> alunosIds)
        {
            DataReferencia = dataReferencia;
            AlunosIds = alunosIds;
        }

        public DateTime DataReferencia { get; set; }
        public IEnumerable<long> AlunosIds { get; set; }
    }
    
}
