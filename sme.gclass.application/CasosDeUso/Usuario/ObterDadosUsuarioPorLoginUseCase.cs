using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterDadosUsuarioPorLoginUseCase : AbstractUseCase, IObterDadosUsuarioPorLoginUseCase
    {
        public ObterDadosUsuarioPorLoginUseCase(IMediator mediator) : base(mediator)
        {
        }

        public Task<UsuarioDto> Executar(string login)
        {
            return mediator.Send(new ObterDadosUsuarioPorLoginQuery(login));
        }
    }
}
