using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarImportacaoAtividadesCommand : IRequest
    {
        public TratarImportacaoAtividadesCommand(ICollection<AtividadeGsaDto> atividades, long cursoId, System.DateTime ultimaExecucao)
        {
            Atividades = atividades;
            CursoId = cursoId;
            UltimaExecucao = ultimaExecucao;
        }

        public ICollection<AtividadeGsaDto> Atividades { get; }
        public long CursoId { get; }
        public DateTime UltimaExecucao { get; }
    }
}
