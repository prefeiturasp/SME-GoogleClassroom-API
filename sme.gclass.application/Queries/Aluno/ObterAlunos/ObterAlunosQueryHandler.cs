using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosQueryHandler : IRequestHandler<ObterAlunosQuery, IEnumerable<UsuarioDto>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;
        public ObterAlunosQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }
        public async Task<IEnumerable<UsuarioDto>> Handle(ObterAlunosQuery request, CancellationToken cancellationToken)
        {
            var alunos = await repositorioUsuario.ObterAlunosAsync();
            return alunos;
        }
    }
}
