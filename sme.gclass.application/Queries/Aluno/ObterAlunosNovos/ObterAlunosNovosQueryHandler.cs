using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosNovosQueryHandler : IRequestHandler<ObterAlunosNovosQuery, PaginacaoResultadoDto<Aluno>>
    {
        private readonly IRepositorioAlunoEol repositorioAlunoEol;
        private readonly IRepositorioExecucaoControle repositorioExecucaoControle;
        public ObterAlunosNovosQueryHandler(IRepositorioAlunoEol repositorioAlunoEol, IRepositorioExecucaoControle repositorioExecucaoControle)
        {
            this.repositorioAlunoEol = repositorioAlunoEol ?? throw new ArgumentNullException(nameof(repositorioAlunoEol));
            this.repositorioExecucaoControle = repositorioExecucaoControle ?? throw new ArgumentNullException(nameof(repositorioExecucaoControle));
        }
        public async Task<PaginacaoResultadoDto<Aluno>> Handle(ObterAlunosNovosQuery request, CancellationToken cancellationToken)
        {
            var dataReferencia = await repositorioExecucaoControle.ObterDataUltimaExecucaoPorTipo(ExecucaoTipo.UsuarioAdicionar);

            if (dataReferencia == DateTime.MinValue)
                dataReferencia = new DateTime(2021, 01, 01);

            var alunos = await repositorioAlunoEol.ObterAlunosParaInclusao(dataReferencia, request.Paginacao);
            return alunos;
        }
    }
}
