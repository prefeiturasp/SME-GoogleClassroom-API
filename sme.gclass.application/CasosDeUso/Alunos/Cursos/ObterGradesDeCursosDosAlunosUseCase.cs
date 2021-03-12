using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterGradesDeCursosDosAlunosUseCase : IObterGradesDeCursosDosAlunosUseCase
    {
        private readonly IMediator mediator;

        public ObterGradesDeCursosDosAlunosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<GradeAlunoCursoEolDto>> Executar(FiltroObterGradesDeCursosDosAlunosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            var resultadoDto = await mediator.Send(new ObterGradesDeCursosDosAlunosQuery(filtro.DataReferencia, paginacao, filtro.CodigoAluno, filtro.TurmaId, filtro.ComponenteCurricularId));

            return new PaginacaoResultadoDto<GradeAlunoCursoEolDto>()
            {
                TotalPaginas = resultadoDto.TotalPaginas,
                TotalRegistros = resultadoDto.TotalRegistros,
                Items = await MapearParaDto(resultadoDto.Items)
            };
        }

        private async Task<IEnumerable<GradeAlunoCursoEolDto>> MapearParaDto(IEnumerable<GradeAlunoCursoEol> grades)
        {
            var alunosGoogle = new List<AlunoGoogle>();

            var gradesAlunoCursoEol = new List<GradeAlunoCursoEolDto>();

            if (!grades.Any()) return gradesAlunoCursoEol;

            var codigosAluno = grades.Select(a => a.CodigoAluno).Distinct().ToArray();

            double totalCodigos = grades.Select(a => a.CodigoAluno).Distinct().Count();

            var i = 0;

            do
            {
                var paginacao = new Paginacao(i, 100);
                var professores = await mediator.Send(new ObterAlunosPorCodigosPaginadoQuery(paginacao, codigosAluno));

                alunosGoogle.AddRange(professores.Items);
                i++;

            } while (i < (int)Math.Truncate(totalCodigos / 100));

            foreach (var item in grades)
            {
                var gradeAlunoParaRetornar = new GradeAlunoCursoEolDto();

                gradeAlunoParaRetornar.CodigoAluno = item.CodigoAluno;
                gradeAlunoParaRetornar.Nome = alunosGoogle.FirstOrDefault(x => x.Codigo == item.CodigoAluno)?.Nome ?? "";
                gradeAlunoParaRetornar.TurmaId = item.TurmaId;
                gradeAlunoParaRetornar.ComponenteCurricularId = item.ComponenteCurricularId;
                gradeAlunoParaRetornar.DataAtribuicao = item.DataInicioGrade;
                gradeAlunoParaRetornar.CdUe = item.CdUe;

                gradesAlunoCursoEol.Add(gradeAlunoParaRetornar);
            }

            return gradesAlunoCursoEol.OrderBy(a => a.CodigoAluno);
        }
    }
}
