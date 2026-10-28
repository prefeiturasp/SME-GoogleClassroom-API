using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosParaCadastrarUseCase : IObterAlunosParaCadastrarUseCase
    {
        private readonly IMediator mediator;

        public ObterAlunosParaCadastrarUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<AlunoParaCadastrarDto>> Executar(FiltroObterAlunosIncluirGoogleDto filtro)
        {
            if (filtro.UltimaExecucao == default)
                throw new NegocioException("A data da última execução deve ser informada.");

            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            var parametrosCargaInicialDto = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));

            var alunosEol = await mediator.Send(new ObterAlunosNovosQuery(paginacao, filtro.UltimaExecucao, filtro.CodigoEol, parametrosCargaInicialDto));

            return new PaginacaoResultadoDto<AlunoParaCadastrarDto>
            {
                Items = MapearParaDto(alunosEol.Items),
                TotalPaginas = alunosEol.TotalPaginas,
                TotalRegistros = alunosEol.TotalRegistros
            };
        }

        private static List<AlunoParaCadastrarDto> MapearParaDto(IEnumerable<AlunoEol> alunosEol)
        {
            var itens = alunosEol is ICollection<AlunoEol> colecao
                ? new List<AlunoParaCadastrarDto>(colecao.Count)
                : new List<AlunoParaCadastrarDto>();

            if (alunosEol is null)
                return itens;

            foreach (var aluno in alunosEol)
            {
                itens.Add(new AlunoParaCadastrarDto
                {
                    Codigo = aluno.Codigo,
                    NomePessoa = aluno.NomePessoa,
                    NomeSocial = aluno.NomeSocial,
                    Email = aluno.Email,
                    OrganizationPath = aluno.OrganizationPath,
                    DataNascimento = aluno.DataNascimento,
                    TurmaId = aluno.TurmaId,
                    SituacaoMatricula = aluno.SituacaoMatricula,
                    DataSituacao = aluno.DataSituacao
                });
            }

            return itens;
        }
    }
}