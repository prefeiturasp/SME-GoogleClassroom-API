using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCursosParaCadastrarGoogleUseCase : IObterAlunosCursosParaCadastrarGoogleUseCase
    {
        private readonly IMediator mediator;

        public ObterAlunosCursosParaCadastrarGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IEnumerable<CursoAlunoParaCadastrarDto>> Executar(long codigoAluno)
        {
            if (codigoAluno <= 0)
                throw new NegocioException("O código do aluno deve ser informado.");

            var parametrosCargaInicialDto = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));

            var alunosCursos = await mediator.Send(new ObterCursosDoAlunoParaIncluirGoogleQuery(codigoAluno, DateTime.Now.Year, parametrosCargaInicialDto));

            return await MapearParaCursoAlunoParaCadastrarDto(alunosCursos);
        }

        private async Task<IEnumerable<CursoAlunoParaCadastrarDto>> MapearParaCursoAlunoParaCadastrarDto(IEnumerable<AlunoCursoEol> alunosCursos)
        {
            var retorno = new List<CursoAlunoParaCadastrarDto>();
            var grupos = alunosCursos.GroupBy(ac => new { ac.CodigoAluno, ac.DataNascimento });

            foreach (var grupo in grupos)
            {
                var cursos = new List<CursoParaCadastrarDto>();
                foreach (var alunoCurso in grupo)
                {
                    var curso = await mediator.Send(new ObterCursoPorTurmaComponenteCurricularQuery(alunoCurso.TurmaId, alunoCurso.ComponenteCurricularId));
                    cursos.Add(new CursoParaCadastrarDto
                    {
                        ComponenteCurricularId = alunoCurso.ComponenteCurricularId,
                        CursoId = curso?.Id ?? 0,
                        TurmaId = alunoCurso.TurmaId,
                        UeCodigo = alunoCurso.UeCodigo
                    });
                }
                retorno.Add(new CursoAlunoParaCadastrarDto
                {
                    CodigoAluno = grupo.Key.CodigoAluno.ToString(),
                    DataNascimento = grupo.Key.DataNascimento.ToString("dd/MM/yyyy"),
                    Cursos = cursos
                });
            }
            return retorno;
        }
    }
}
