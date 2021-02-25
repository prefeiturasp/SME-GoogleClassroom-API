using Newtonsoft.Json;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleUsuarioUseCase : ITrataSyncGoogleUsuarioUseCase
    {
        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var resposta = JsonConvert.SerializeObject(mensagemRabbit);
            return await Task.FromResult(true);
        }
    }
}
