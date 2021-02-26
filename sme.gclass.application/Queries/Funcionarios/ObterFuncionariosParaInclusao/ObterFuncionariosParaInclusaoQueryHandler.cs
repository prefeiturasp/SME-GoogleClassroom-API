using MediatR;
using SME.GoogleClassroom.Dados.Interfaces.Eol;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Funcionarios;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosParaInclusaoQueryHandler : IRequestHandler<ObterFuncionariosParaInclusaoQuery, PaginacaoResultadoDto<FuncionarioParaInclusaoDto>>
    {
        private readonly IRepositorioFuncionarioEol repositorioFuncionarioEol;

        public ObterFuncionariosParaInclusaoQueryHandler(IRepositorioFuncionarioEol repositorioFuncionarioEol)
        {
            this.repositorioFuncionarioEol = repositorioFuncionarioEol;
        }

        public async Task<PaginacaoResultadoDto<FuncionarioParaInclusaoDto>> Handle(ObterFuncionariosParaInclusaoQuery request, CancellationToken cancellationToken)
            => await repositorioFuncionarioEol.ObterFuncionariosParaInclusaoAsync(request.UltimaDataExecucao, request.Paginacao);
    }
}