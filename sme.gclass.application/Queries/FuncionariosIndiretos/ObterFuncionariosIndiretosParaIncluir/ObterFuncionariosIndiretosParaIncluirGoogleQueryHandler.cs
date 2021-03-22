using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosIndiretosParaIncluirGoogleQueryHandler : IRequestHandler<ObterFuncionariosIndiretosParaIncluirGoogleQuery, PaginacaoResultadoDto<FuncionarioIndiretoEol>>
    {
        private readonly IRepositorioFuncionarioIndiretoEol repositorioFuncionarioIndiretoEol;

        public ObterFuncionariosIndiretosParaIncluirGoogleQueryHandler(IRepositorioFuncionarioIndiretoEol repositorioFuncionarioIndiretoEol)
        {
            this.repositorioFuncionarioIndiretoEol = repositorioFuncionarioIndiretoEol;
        }

        public async Task<PaginacaoResultadoDto<FuncionarioIndiretoEol>> Handle(ObterFuncionariosIndiretosParaIncluirGoogleQuery request, CancellationToken cancellationToken)
            => await repositorioFuncionarioIndiretoEol.ObterFuncionariosIndiretosParaInclusaoAsync(request.UltimaDataExecucao, request.Paginacao, request.Cpf);
    }
}