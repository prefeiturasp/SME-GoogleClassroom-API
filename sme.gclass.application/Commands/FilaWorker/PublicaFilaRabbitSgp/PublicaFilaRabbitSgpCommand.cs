using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Aplicacao
{
    public class PublicaFilaRabbitSgpCommand : IRequest<bool>
    {
        public PublicaFilaRabbitSgpCommand(string nomeFila, object mensagem)
        {
            NomeFila = nomeFila;
            Mensagem = mensagem;
        }

        public string NomeFila { get; }
        public object Mensagem { get; }
    }
}
