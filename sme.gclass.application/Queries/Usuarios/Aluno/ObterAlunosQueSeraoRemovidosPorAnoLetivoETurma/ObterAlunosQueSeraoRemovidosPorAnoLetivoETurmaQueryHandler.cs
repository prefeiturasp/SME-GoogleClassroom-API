using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosQueSeraoRemovidosPorAnoLetivoETurmaQueryHandler : IRequestHandler<ObterAlunosQueSeraoRemovidosPorAnoLetivoETurmaQuery, PaginacaoResultadoDto<AlunoEol>>
    {
        private readonly IRepositorioAlunoEol repositorioAlunoEol;

        public ObterAlunosQueSeraoRemovidosPorAnoLetivoETurmaQueryHandler(IRepositorioAlunoEol repositorioAlunoEol)
        {
            this.repositorioAlunoEol = repositorioAlunoEol ?? throw new ArgumentNullException(nameof(repositorioAlunoEol));
        }

        public async Task<PaginacaoResultadoDto<AlunoEol>> Handle(ObterAlunosQueSeraoRemovidosPorAnoLetivoETurmaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAlunoEol.ObterAlunosQueSeraoRemovidosPorAnoLetivoETurma(request.ParametrosCargaInicialDto, request.Paginacao, request.AnoLetivo, request.TurmaId, request.DataReferencia, request.EhDataReferenciaPrincipal);
        }
    }
}
