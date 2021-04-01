using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.Usuarios.Erros.ObterAlunoParaTratamentoDeErro
{
    public class ObterAlunoParaTratamentoDeErroQueryHandler : IRequestHandler<ObterAlunoParaTratamentoDeErroQuery, AlunoEol>
    {
        private readonly IRepositorioAlunoEol repositorioAlunoEol;

        public ObterAlunoParaTratamentoDeErroQueryHandler(IRepositorioAlunoEol repositorioAlunoEol)
        {
            this.repositorioAlunoEol = repositorioAlunoEol;
        }

        public async Task<AlunoEol> Handle(ObterAlunoParaTratamentoDeErroQuery request, CancellationToken cancellationToken) 
            => await repositorioAlunoEol.ObterAlunoParaTratamentoDeErroAsync(request.CodigoEol, DateTime.Now.Year);
    }
}