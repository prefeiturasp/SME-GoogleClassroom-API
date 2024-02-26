using MediatR;
using SME.GoogleClassroom.Infra.Dtos.ConectaFormacao;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ListagemAreaPromotoraQuery : IRequest<IEnumerable<AreaPromotoraDTO>>
    {
        private static ListagemAreaPromotoraQuery _instancia;

        public static ListagemAreaPromotoraQuery Instancia() => _instancia ??= new ListagemAreaPromotoraQuery();
    }
}
