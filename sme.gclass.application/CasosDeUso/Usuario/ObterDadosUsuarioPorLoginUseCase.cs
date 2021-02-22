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

        public async Task<UsuarioDto> Executar(string login)
        {
            var retorno = await mediator.Send(new ObterAcessoRandomicoQuery());
            return await mediator.Send(new ObterDadosUsuarioPorLoginQuery(login));
        }
    }
}
