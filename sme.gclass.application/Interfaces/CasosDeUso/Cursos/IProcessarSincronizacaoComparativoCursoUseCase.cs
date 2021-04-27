using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IProcessarSincronizacaoComparativoCursoUseCase
    {
        Task<bool> Executar(MensagemRabbit mensagemRabbit);
    }
}