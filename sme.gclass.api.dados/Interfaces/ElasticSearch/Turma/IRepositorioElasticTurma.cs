using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioElasticTurma : IRepositorioElasticBase<DocumentoElasticTurma>
    {
        Task<IEnumerable<AlunoNaTurmaDTO>> ObterMatriculasAlunoNaTurma(int codigoTurma, int codigoAluno);
        Task<IEnumerable<AlunoNaTurmaDTO>> ObterAlunosPorTurmaMultiplexConnetionAsync(int codigoTurma);
        Task<IEnumerable<AlunoNaTurmaDTO>> ObterAlunosNaTurmaAsync(int codigoTurma, int? anoLetivo);
        Task<IEnumerable<AlunoNaTurmaDTO>> ObterAlunosAtivosNaTurmaAsync(int codigoTurma, DateTime dataAula);
        Task<IReadOnlyList<AlunoNaTurmaDTO>> ObterAlunosPorTurmaAsync(int codigoTurma, int codigoAluno, bool consideraInativos = false);

        Task<IEnumerable<TurmaComponentesDto>> ObterListaTurmasAsync(
            string codigoUe, int[] tiposEscolaModalidade, long codigoTurma, int anoLetivo,
            bool ehProfessor, string codigoRf, bool consideraHistorico,
            DateTime periodoEscolarInicio, int modalidade);
        Task<IEnumerable<AlunoNaTurmaDTO>> ObterMatriculasTurmaDoAlunoAsync(string codigoAluno, DateTime? dataAula, int? anoLetivo);

        Task<IReadOnlyList<AlunoNaTurmaDTO>> ObterTodosAlunosNaTurmaAsync(int codigoTurma, int? codigoAluno);
    }
}
