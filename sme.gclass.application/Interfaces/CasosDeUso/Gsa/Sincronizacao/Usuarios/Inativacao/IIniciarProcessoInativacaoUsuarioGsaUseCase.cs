using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarProcessoInativacaoUsuariosGsaUseCase
    {
        Task<bool> Executar(long? alunoId);
    }
}
