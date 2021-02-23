using Newtonsoft.Json;
using System;

namespace SME.GoogleClassroom.Infra
{
    public class MensagemRabbit
    {
        public MensagemRabbit(object mensagem)
        {
            Mensagem = mensagem;            
        }
        protected MensagemRabbit()
        {

        }        
        public object Mensagem { get; set; }        

        public T ObterObjetoMensagem<T>() where T : class
        {
            return JsonConvert.DeserializeObject<T>(Mensagem.ToString());
        }
    }
}
