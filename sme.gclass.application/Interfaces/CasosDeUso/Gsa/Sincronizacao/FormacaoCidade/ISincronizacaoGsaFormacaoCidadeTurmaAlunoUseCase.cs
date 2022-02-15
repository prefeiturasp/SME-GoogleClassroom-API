using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface ISincronizacaoGsaFormacaoCidadeTurmaAlunoUseCase : IUseCase<MensagemRabbit, bool>
    {
    }
}