using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class LancarFrequenciaUseCase : AbstractUseCase,ILancarFrequenciaUseCase
    {
        public LancarFrequenciaUseCase(IMediator mediator)
            : base(mediator)
        {
        }

        public async Task<bool> Executar(FrequenciaSalvarAulaAlunosDto frequenciaSalvarAulaAlunosDto)
        {
            return await mediator.Send(new LancarFrequenciaCommand(frequenciaSalvarAulaAlunosDto));
        }
    }
}