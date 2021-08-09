using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosInativosUseCase : IObterFuncionariosInativosUseCase
    {
        private readonly IMediator mediator;

        public ObterFuncionariosInativosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<UsuarioInativoDto>> Executar(FiltroObterFuncionariosInativosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);

            var usuarioTipo = (UsuarioTipo)filtro.UsuarioTipo;

            return await mediator.Send(new ObterUsuariosInativosPorTipoQuery(paginacao, usuarioTipo));
        }
    }
}