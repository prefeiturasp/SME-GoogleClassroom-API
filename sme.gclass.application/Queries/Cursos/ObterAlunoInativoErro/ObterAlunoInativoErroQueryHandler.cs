using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunoInativoErroQueryHandler : IRequestHandler<ObterAlunoInativoErroQuery,IEnumerable<UsuarioInativoErro>>
    {
        private readonly IRepositorioUsuarioInativoErro repositorioUsuarioInativoErro;

        public ObterAlunoInativoErroQueryHandler(IRepositorioUsuarioInativoErro repositorioUsuarioInativoErro)
        {
            this.repositorioUsuarioInativoErro = repositorioUsuarioInativoErro ?? throw new ArgumentNullException(nameof(repositorioUsuarioInativoErro));
        }

        public async Task<IEnumerable<UsuarioInativoErro>> Handle(ObterAlunoInativoErroQuery request,
            CancellationToken cancellationToken)
            => await repositorioUsuarioInativoErro.BuscarTodo();
    }
}