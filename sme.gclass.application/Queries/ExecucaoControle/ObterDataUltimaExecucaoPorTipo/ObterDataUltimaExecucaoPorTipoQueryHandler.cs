using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterDataUltimaExecucaoPorTipoQueryHandler : IRequestHandler<ObterDataUltimaExecucaoPorTipoQuery, DateTime>
    {
        private readonly IRepositorioExecucaoControle repositorioExecucaoControle;

        public ObterDataUltimaExecucaoPorTipoQueryHandler(IRepositorioExecucaoControle repositorioExecucaoControle)
        {
            this.repositorioExecucaoControle = repositorioExecucaoControle ?? throw new ArgumentNullException(nameof(repositorioExecucaoControle));
        }
        public async Task<DateTime> Handle(ObterDataUltimaExecucaoPorTipoQuery request, CancellationToken cancellationToken)
        {
            var dataUltimaExecucao = await repositorioExecucaoControle.ObterDataUltimaExecucaoPorTipo(request.ExecucaoTipo);

            if (dataUltimaExecucao == null || dataUltimaExecucao == DateTime.MinValue)
                throw new NegocioException("Não foi possível obter a última data de execução do tipo informado!");

            return dataUltimaExecucao;
        }
    }
}
