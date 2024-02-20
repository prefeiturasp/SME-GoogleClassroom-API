using SME.GoogleClassroom.Infra.Dtos.ConectaFormacao;
using SME.GoogleClassroom.Infra.Dtos.Gsa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioConectaFormacao
    {
        Task<IEnumerable<InscricaoConfirmadaDTO>> ListagemInscricoesConfirmadas(long codigoDaTurma);
        Task<IEnumerable<FormacaoDTO>> ListagemFormacoesPorAno(int ano);
        Task<IEnumerable<FormacaoTurmaDTO>> ListagemTurmasPorCodigosFormacoes(long[] codigosDasFormacoes);
        Task<IEnumerable<FormacaoTurmaProfessoresDTO>> ListagemProfessoresRegentesPorCodigosFormacoes(long[] codigosDasFormacoes);
        Task<IEnumerable<FormacaoTurmaProfessoresDTO>> ListagemProfessoresTutoresPorCodigosFormacoes(long[] codigosDasFormacoes);
    }
}
