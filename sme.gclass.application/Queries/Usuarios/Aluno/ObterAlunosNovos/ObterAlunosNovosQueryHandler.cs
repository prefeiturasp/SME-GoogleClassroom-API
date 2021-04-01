using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosNovosQueryHandler : IRequestHandler<ObterAlunosNovosQuery, PaginacaoResultadoDto<AlunoEol>>
    {
        private readonly IRepositorioAlunoEol repositorioAlunoEol;
        private readonly IRepositorioExecucaoControle repositorioExecucaoControle;
        public ObterAlunosNovosQueryHandler(IRepositorioAlunoEol repositorioAlunoEol, IRepositorioExecucaoControle repositorioExecucaoControle)
        {
            this.repositorioAlunoEol = repositorioAlunoEol ?? throw new ArgumentNullException(nameof(repositorioAlunoEol));
            this.repositorioExecucaoControle = repositorioExecucaoControle ?? throw new ArgumentNullException(nameof(repositorioExecucaoControle));
        }
        public async Task<PaginacaoResultadoDto<AlunoEol>> Handle(ObterAlunosNovosQuery request, CancellationToken cancellationToken)
        {
            var alunos = await repositorioAlunoEol.ObterAlunosParaInclusaoAsync(request.Paginacao, request.DataReferencia, request.CodigoEol);
            return alunos;
        }
    }
}
