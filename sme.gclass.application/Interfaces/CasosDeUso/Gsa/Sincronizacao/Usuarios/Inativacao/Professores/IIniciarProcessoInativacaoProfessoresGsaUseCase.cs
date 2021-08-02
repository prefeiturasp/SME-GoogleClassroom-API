using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarProcessoInativacaoProfessoresGsaUseCase
    {
        Task<bool> Executar(string rf);
    }
}
