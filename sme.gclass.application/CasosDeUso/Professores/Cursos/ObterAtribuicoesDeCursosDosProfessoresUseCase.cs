﻿using MediatR;
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
            var resultadoDto = await mediator.Send(new ObterAtribuicoesDeCursosDosProfessoresQuery(filtro.DataReferencia, paginacao, filtro.Rf.ToString(), filtro.TurmaId, filtro.ComponenteCurricularId));

            return new PaginacaoResultadoDto<AtribuicaoProfessorCursoEolDto>()
            {
                TotalPaginas = resultadoDto.TotalPaginas,
                TotalRegistros = resultadoDto.TotalRegistros,
                Items = await MapearParaDto(resultadoDto.Items)
            };
        }

        private async Task<IEnumerable<AtribuicaoProfessorCursoEolDto>> MapearParaDto(IEnumerable<AtribuicaoProfessorCursoEol> Atribuicoes)
        {
            var professoresGoogle = new List<ProfessorGoogle>();

            var atribuicaoProfessorCursoEol = new List<AtribuicaoProfessorCursoEolDto>();           

            var rfs = Atribuicoes.Select(a => a.Rf).Distinct().ToArray();

            double totalRfs = Atribuicoes.Select(a => a.Rf).Distinct().Count();

            var i = 0;

            do
            {
                var paginacao = new Paginacao(i, 100);
                var professores = await mediator.Send(new ObterProfessoresPorRfsPaginadoQuery(paginacao, rfs));

                professoresGoogle.AddRange(professores.Items);
                i++;

            } while (i < (int)Math.Truncate(totalRfs / 100));

            foreach (var item in Atribuicoes)
            {
                var atribuicaoParaRetornar = new AtribuicaoProfessorCursoEolDto();

                atribuicaoParaRetornar.Rf = item.Rf;
                atribuicaoParaRetornar.Nome = professoresGoogle.FirstOrDefault(x => x.Rf == item.Rf)?.Nome ?? "";
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
