using System.Collections.Generic;
using System.Threading.Tasks;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioConectaFormacao
    {
        Task<IEnumerable<InscricaoConfirmadaDTO>> ListagemInscricoesConfirmadas(long codigoDaTurma);
        Task<IEnumerable<FormacaoCodigoNomeDataRealizacaoCoordenadoriaTurmasDTO>> ListagemFormacoesPorAno(int ano);
        Task<IEnumerable<CodigoNomeTurmaProfessoresDTO>> ListagemTurmasPorCodigosFormacoes(long[] codigosDasFormacoes);
        Task<IEnumerable<ProfessorCodigoTurmaRfCpfNomeEmailTutorDTO>> ListagemProfessoresRegentesPorCodigosFormacoes(long[] codigosDasFormacoes);
        Task<IEnumerable<ProfessorCodigoTurmaRfCpfNomeEmailTutorDTO>> ListagemProfessoresTutoresPorCodigosFormacoes(long[] codigosDasFormacoes);
    }
}
