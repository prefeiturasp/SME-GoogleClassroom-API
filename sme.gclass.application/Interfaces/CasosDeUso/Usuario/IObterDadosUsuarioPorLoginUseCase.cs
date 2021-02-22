using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterDadosUsuarioPorLoginUseCase : IUseCase<string, UsuarioDto>
    {
    }
}
