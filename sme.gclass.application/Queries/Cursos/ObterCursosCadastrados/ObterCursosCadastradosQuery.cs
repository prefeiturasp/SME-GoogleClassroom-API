using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosCadastradosQuery : IRequest<IEnumerable<Curso>>
    {
        public ObterCursosCadastradosQuery(Paginacao paginacacao)
        {
            this.paginacacao = paginacacao;
        }

        public Paginacao paginacacao { get; set; }
    }
}
