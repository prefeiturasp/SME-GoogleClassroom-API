using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirAtividadesBulkCommand : IRequest<bool>
    {
        public IncluirAtividadesBulkCommand(IEnumerable<AtividadeGsa> atividades)
        {
            Atividades = atividades;
        }

        public IEnumerable<AtividadeGsa> Atividades { get; set; }
    }
}
