using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosParaIncluirGoogleQueryHandler : IRequestHandler<ObterFuncionariosParaIncluirGoogleQuery, PaginacaoResultadoDto<FuncionarioEol>>
    {
        private readonly IRepositorioFuncionarioEol repositorioFuncionarioEol;

        public ObterFuncionariosParaIncluirGoogleQueryHandler(IRepositorioFuncionarioEol repositorioFuncionarioEol)
        {
            this.repositorioFuncionarioEol = repositorioFuncionarioEol;
        }

        public async Task<PaginacaoResultadoDto<FuncionarioEol>> Handle(ObterFuncionariosParaIncluirGoogleQuery request, CancellationToken cancellationToken)
            => await repositorioFuncionarioEol.ObterFuncionariosParaInclusaoAsync(request.UltimaDataExecucao, request.Paginacao);
    }
}