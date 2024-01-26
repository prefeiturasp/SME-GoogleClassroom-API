using System;
using System.Collections.Generic;
using System.Net;

namespace SME.GoogleClassroom.Dominio
{
    public class NegocioException : Exception
    {
        public NegocioException(string mensagem, int statusCode = 601) : base(mensagem)
        {
            StatusCode = statusCode;
            Mensagens = new List<string>() { mensagem };
        }

        public NegocioException(string mensagem, HttpStatusCode statusCode) : base(mensagem)
        {
            StatusCode = (int)statusCode;
            Mensagens = new List<string>() { mensagem };
        }
        public NegocioException(List<string> mensagens, int statusCode = 601) : base(string.Join(", ", mensagens))
        {
            Mensagens = mensagens;
            StatusCode = statusCode;
        }
        public List<string> Mensagens { get; set; }
        public int StatusCode { get; }
    }
}
