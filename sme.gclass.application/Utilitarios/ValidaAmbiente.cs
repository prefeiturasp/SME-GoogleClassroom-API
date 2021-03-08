using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public abstract class ValidaAmbiente
    {
        public bool DeveExecutarIntegracao { get; }
        public ValidaAmbiente(VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            DeveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }
    }
}
