using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarImportacaoAtividadesCommand : IRequest
    {
        public TratarImportacaoAtividadesCommand(ICollection<AtividadeGsaDto> atividades, long cursoId)
        {
            Atividades = atividades;
            CursoId = cursoId;
        }

        public ICollection<AtividadeGsaDto> Atividades { get; }
        public long CursoId { get; }
    }
}
