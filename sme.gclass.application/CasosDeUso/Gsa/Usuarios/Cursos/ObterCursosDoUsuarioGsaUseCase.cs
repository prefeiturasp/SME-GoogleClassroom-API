using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosDoUsuarioGsaUseCase : IObterCursosDoUsuarioGsaUseCase
    {
        private readonly IMediator mediator;

        public ObterCursosDoUsuarioGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<ConsultaCursosDoUsuarioGsa> Executar(string usuarioId)
            => await mediator.Send(new ObterCursosDoUsuarioGsaQuery(usuarioId));
    }
}