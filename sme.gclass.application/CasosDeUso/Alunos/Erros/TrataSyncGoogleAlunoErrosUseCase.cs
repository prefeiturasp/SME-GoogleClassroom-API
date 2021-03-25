using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleAlunoErrosUseCase : ITrataSyncGoogleAlunoErrosUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleAlunoErrosUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            throw new NotImplementedException();
        }
    }
}
