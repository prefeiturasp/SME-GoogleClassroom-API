using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAtribuicoesDeCursosDosAlunosUseCase : IObterAtribuicoesDeCursosDosAlunosUseCase
    {
        private readonly IMediator mediator;

        public ObterAtribuicoesDeCursosDosAlunosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<AtribuicaoAlunoCursoEolDto>> Executar(FiltroObterAtribuicoesDeCursosDosAlunosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            var resultadoDto = new PaginacaoResultadoDto<AtribuicaoAlunoCursoEol>();  // TODO : Ajustar com a query da outra atividade

            return new PaginacaoResultadoDto<AtribuicaoAlunoCursoEolDto>()
            {
                TotalPaginas = resultadoDto.TotalPaginas,
                TotalRegistros = resultadoDto.TotalRegistros,
                Items = await MapearParaDto(resultadoDto.Items)
            };
        }

        private async Task<IEnumerable<AtribuicaoAlunoCursoEolDto>> MapearParaDto(IEnumerable<AtribuicaoAlunoCursoEol> Atribuicoes)
        {
            var alunosGoogle = new List<AlunoGoogle>();

            var atribuicoesAlunoCursoEol = new List<AtribuicaoAlunoCursoEolDto>();

            var codigosAluno = Atribuicoes.Select(a => a.CodigoAluno).Distinct().ToArray();

            double totalCodigos = Atribuicoes.Select(a => a.CodigoAluno).Distinct().Count();

            var i = 0;

            do
            {
                var paginacao = new Paginacao(i, 100);
                var professores = await mediator.Send(new ObterAlunosPorCodigosPaginadoQuery(paginacao, codigosAluno));

                alunosGoogle.AddRange(professores.Items);
                i++;

            } while (i < (int)Math.Truncate(totalCodigos / 100));

            foreach (var item in Atribuicoes)
            {
                var atribuicaoParaRetornar = new AtribuicaoAlunoCursoEolDto();

                atribuicaoParaRetornar.CodigoAluno = item.CodigoAluno;
                atribuicaoParaRetornar.Nome = alunosGoogle.FirstOrDefault(x => x.Codigo == item.CodigoAluno)?.Nome ?? "";
                atribuicaoParaRetornar.TurmaId = item.TurmaId;
                atribuicaoParaRetornar.ComponenteCurricularId = item.ComponenteCurricularId;
                atribuicaoParaRetornar.DataAtribuicao = item.DataAtribuicao;
                atribuicaoParaRetornar.CdUe = item.CdUe;

                atribuicoesAlunoCursoEol.Add(atribuicaoParaRetornar);
            }

            return atribuicoesAlunoCursoEol.OrderBy(a => a.CodigoAluno);
        }
    }
}
