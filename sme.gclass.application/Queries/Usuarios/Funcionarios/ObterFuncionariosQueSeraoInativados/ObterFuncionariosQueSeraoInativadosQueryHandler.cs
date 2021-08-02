using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterFuncionariosQueSeraoInativadosQueryHandler: IRequestHandler<ObterFuncionariosQueSeraoInativadosQuery, PaginacaoResultadoDto<FuncionarioEol>>
    {
        private readonly IRepositorioFuncionarioEol repositorioFuncionarioEol;

        public ObterFuncionariosQueSeraoInativadosQueryHandler(IRepositorioFuncionarioEol repositorioFuncionarioEol)
        {
            this.repositorioFuncionarioEol = repositorioFuncionarioEol ?? throw new ArgumentNullException(nameof(repositorioFuncionarioEol));
        }

        public async Task<PaginacaoResultadoDto<FuncionarioEol>> Handle(ObterFuncionariosQueSeraoInativadosQuery request, CancellationToken cancellationToken)
        {
            return await repositorioFuncionarioEol.ObterFuncionariosQueSeraoInativados(request.Paginacao, request.DataReferencia);
        }
    }
}
