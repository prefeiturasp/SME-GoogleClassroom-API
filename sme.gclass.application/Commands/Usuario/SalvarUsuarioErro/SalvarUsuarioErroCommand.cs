using MediatR;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SalvarUsuarioErroCommand : IRequest<long>
    {
        public long UsuarioId { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }
        public int UsuarioTipo { get; set; }
        public int ExecucaoTipo { get; set; }
        public DateTime DataInclusao { get; set; }        
    }
}
