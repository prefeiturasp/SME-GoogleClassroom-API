using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IRabbitUseCase : IUseCase<MensagemRabbit, bool>
    {
    }
}
