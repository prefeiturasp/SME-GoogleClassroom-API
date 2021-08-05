using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosInativosUseCase : IObterAlunosInativosUseCase
    {
        private readonly IMediator mediator;

        public ObterAlunosInativosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<UsuarioInativo>> Executar(FiltroObterAlunosInativosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            return await mediator.Send(new ObterUsuariosInativosPorTipoQuery(paginacao, new[] { UsuarioTipo.Aluno }));
        }
    }

    
}