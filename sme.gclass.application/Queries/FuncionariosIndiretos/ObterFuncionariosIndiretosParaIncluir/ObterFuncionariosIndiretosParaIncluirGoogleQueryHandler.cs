using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosIndiretosParaIncluirGoogleQueryHandler : IRequestHandler<ObterFuncionariosIndiretosParaIncluirGoogleQuery, PaginacaoResultadoDto<FuncionarioIndiretoEol>>
    {
        public ObterFuncionariosIndiretosParaIncluirGoogleQueryHandler()
        {
        }

        public Task<PaginacaoResultadoDto<FuncionarioIndiretoEol>> Handle(ObterFuncionariosIndiretosParaIncluirGoogleQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}