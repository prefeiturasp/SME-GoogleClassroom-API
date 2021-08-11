using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAtribuicoesDeCursosDosProfessoresUseCase : IObterAtribuicoesDeCursosDosProfessoresUseCase
    {
        private readonly IMediator mediator;

        public ObterAtribuicoesDeCursosDosProfessoresUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<AtribuicaoProfessorCursoEolDto>> Executar(FiltroObterAtribuicoesDeCursosDosProfessoresDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            var parametrosCargaInicialDto = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));
            var resultadoDto = await mediator.Send(new ObterAtribuicoesDeCursosDosProfessoresQuery(filtro.DataReferencia, paginacao, filtro.Rf.ToString(), filtro.TurmaId, filtro.ComponenteCurricularId, parametrosCargaInicialDto));

            return new PaginacaoResultadoDto<AtribuicaoProfessorCursoEolDto>()
            {
                TotalPaginas = resultadoDto.TotalPaginas,
                TotalRegistros = resultadoDto.TotalRegistros,
                Items = await MapearParaDto(resultadoDto.Items)
            };
        }

        private async Task<IEnumerable<AtribuicaoProfessorCursoEolDto>> MapearParaDto(IEnumerable<AtribuicaoProfessorCursoEol> atribuicoes)
        {
            var professoresGoogle = new List<ProfessorGoogle>();
            var atribuicaoProfessorCursoEol = new List<AtribuicaoProfessorCursoEolDto>();

            if (!atribuicoes.Any())
                return atribuicaoProfessorCursoEol;

            var rfs = atribuicoes.Select(a => a.Rf).Distinct().ToArray();

            double totalRfs = atribuicoes.Select(a => a.Rf).Distinct().Count();

            var i = 1;

            do
            {
                var paginacao = new Paginacao(i, 100);
                // TO DO: Alterar para utilizar classe abstrata quando fizermos a separação
                var professores = await mediator.Send(new ObterProfessoresFuncionariosPorRfsPaginadoQuery(paginacao, rfs));

                professoresGoogle.AddRange(professores.Items);
                i++;

            } while (i <= (int)Math.Ceiling(totalRfs / 100));

            foreach (var item in atribuicoes)
            {
                var atribuicaoParaRetornar = new AtribuicaoProfessorCursoEolDto();
                var professorParaIncluir = professoresGoogle.FirstOrDefault(x => x.Rf == item.Rf);

                atribuicaoParaRetornar.Rf = item.Rf;
                atribuicaoParaRetornar.Nome = professorParaIncluir?.Nome ?? "";
                atribuicaoParaRetornar.Email = professorParaIncluir?.Email ?? "";
                atribuicaoParaRetornar.TurmaId = item.TurmaId;
                atribuicaoParaRetornar.ComponenteCurricularId = item.ComponenteCurricularId;
                atribuicaoParaRetornar.DataAtribuicao = item.DataAtribuicao;
                atribuicaoParaRetornar.CdUe = item.CdUe;

                atribuicaoProfessorCursoEol.Add(atribuicaoParaRetornar);
            }

            return atribuicaoProfessorCursoEol.OrderBy(a => a.Rf);
        }
    }
}
