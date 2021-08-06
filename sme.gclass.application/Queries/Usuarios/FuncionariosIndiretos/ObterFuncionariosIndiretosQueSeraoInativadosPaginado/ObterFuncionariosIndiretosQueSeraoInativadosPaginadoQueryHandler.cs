using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterFuncionariosIndiretosQueSeraoInativadosPaginadoQueryHandler : IRequestHandler<ObterFuncionariosIndiretosQueSeraoInativadosPaginadoQuery, PaginacaoResultadoDto<FuncionarioIndiretoEol>>
    {
        private readonly IRepositorioFuncionarioIndiretoEol repositorio;

        public ObterFuncionariosIndiretosQueSeraoInativadosPaginadoQueryHandler(IRepositorioFuncionarioIndiretoEol repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<PaginacaoResultadoDto<FuncionarioIndiretoEol>> Handle(ObterFuncionariosIndiretosQueSeraoInativadosPaginadoQuery request, CancellationToken cancellationToken)
        {
            return await repositorio.ObterFuncionariosIndiretosQueSeraoInativadosPaginados(request.Paginacao, request.Cpf);
        }
    }
}
