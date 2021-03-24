using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleCursoErroUseCase : ITrataSyncGoogleCursoErroUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleCursoErroUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            throw new NotImplementedException();
        }
    }
}
