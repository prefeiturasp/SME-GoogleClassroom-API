using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Aplicacao
{
    public class PublicaFilaRabbitSgpCommand : IRequest<bool>
    {
        public PublicaFilaRabbitSgpCommand(string nomeFila, object mensagem, string usuarioLogadoRF = "", string usuarioLogadoNome = "", string usuarioLogadoPerfil = "")
        {
            NomeFila = nomeFila;
            Mensagem = mensagem;
            UsuarioLogadoRF = usuarioLogadoRF;
            UsuarioLogadoNome = usuarioLogadoNome;
            UsuarioLogadoPerfil = usuarioLogadoPerfil;
        }
         
        public string NomeFila { get; }
        public object Mensagem { get; }
        public string UsuarioLogadoRF { get; }
        public string UsuarioLogadoNome { get; }
        public string UsuarioLogadoPerfil { get; }
    }
}
