using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCadastradosQueryHandler : IRequestHandler<ObterAlunosCadastradosQuery, PaginacaoResultadoDto<Usuario>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;
        public ObterAlunosCadastradosQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }
        public async Task<PaginacaoResultadoDto<Usuario>> Handle(ObterAlunosCadastradosQuery request, CancellationToken cancellationToken)
        {
            var alunos = await repositorioUsuario.ObterAlunosAsync(request.Paginacacao);
            return alunos;
        }
    }
}
