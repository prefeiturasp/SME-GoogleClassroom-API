using MediatR;
using SME.GoogleClassroom.Dominio;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirUsuarioErroCommand : IRequest<long>
    {
        public IncluirUsuarioErroCommand(long? usuarioId, string email, string mensagem, UsuarioTipo usuarioTipo, ExecucaoTipo execucaoTipo, DateTime dataInclusao)
        {
            UsuarioId = usuarioId;
            Email = email;
            Mensagem = mensagem;
            UsuarioTipo = usuarioTipo;
            ExecucaoTipo = execucaoTipo;
            DataInclusao = dataInclusao;
        }

        public long? UsuarioId { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }
        public UsuarioTipo UsuarioTipo { get; set; }
        public ExecucaoTipo ExecucaoTipo { get; set; }
        public DateTime DataInclusao { get; set; }        
    }
}
