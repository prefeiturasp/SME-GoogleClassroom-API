using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosParaIncluirGoogleQueryHandler : IRequestHandler<ObterFuncionariosParaIncluirGoogleQuery, PaginacaoResultadoDto<FuncionarioParaIncluirGoogleDto>>
    {
        private readonly IRepositorioFuncionarioEol repositorioFuncionarioEol;

        public ObterFuncionariosParaIncluirGoogleQueryHandler(IRepositorioFuncionarioEol repositorioFuncionarioEol)
        {
            this.repositorioFuncionarioEol = repositorioFuncionarioEol;
        }

        public async Task<PaginacaoResultadoDto<FuncionarioParaIncluirGoogleDto>> Handle(ObterFuncionariosParaIncluirGoogleQuery request, CancellationToken cancellationToken)
            => await repositorioFuncionarioEol.ObterFuncionariosParaInclusaoAsync(request.UltimaDataExecucao, request.Paginacao);
    }
}