using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioElasticTurma : IRepositorioElasticBase<DocumentoElasticTurma>
    {
        Task<IEnumerable<AlunoNaTurmaDTO>> ObterAlunosAtivosNaTurmaAsync(int codigoTurma, DateTime dataAula);
        Task<IEnumerable<TurmaComponentesDto>> ObterListaTurmasAsync(
            string codigoUe, int[] tiposEscolaModalidade, long codigoTurma, int anoLetivo,
            bool ehProfessor, string codigoRf, bool consideraHistorico,
            DateTime? periodoEscolarInicio, int modalidade);
    }
}
