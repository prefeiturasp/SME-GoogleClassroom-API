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

        public ObterAlunosNovosQueryHandler(IRepositorioAlunoEol repositorioAlunoEol)
        {
            this.repositorioAlunoEol = repositorioAlunoEol ?? throw new ArgumentNullException(nameof(repositorioAlunoEol));
        }

        public async Task<PaginacaoResultadoDto<AlunoEol>> Handle(ObterAlunosNovosQuery request, CancellationToken cancellationToken)
        {
            var anoLetivo = request.DataReferencia?.Year ?? DateTime.Now.Year;            
            var alunos = await repositorioAlunoEol.ObterAlunosParaInclusaoAsync(request.Paginacao, anoLetivo, request.DataReferencia, request.CodigoEol, request.ParametrosCargaInicialDto);
            return alunos;
        }
    }
}
