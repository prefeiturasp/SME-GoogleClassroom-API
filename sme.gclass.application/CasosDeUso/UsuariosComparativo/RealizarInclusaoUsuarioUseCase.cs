using Google.Apis.Admin.Directory.directory_v1.Data;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarInclusaoUsuarioUseCase : IRealizarInclusaoUsuarioUseCase
    {
        public RealizarInclusaoUsuarioUseCase()
        {
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var usuarioGsa = mensagemRabbit.ObterObjetoMensagem<User>();

            return true;
        }
    }
}
