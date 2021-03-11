using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosPorCodigosQueryHandler : IRequestHandler<ObterAlunosPorCodigosQuery, IEnumerable<AlunoGoogle>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterAlunosPorCodigosQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<IEnumerable<AlunoGoogle>> Handle(ObterAlunosPorCodigosQuery request, CancellationToken cancellationToken)
        {
            var alunos = await repositorioUsuario.ObterAlunosPorCodigos(request.AlunosCodigo);

            return alunos;
        }
    }
}
