using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosCadastradosUseCase : IObterCursosCadastradosUseCase
    {
        private readonly IMediator mediator;

        public ObterCursosCadastradosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }
        public async Task<PaginacaoResultadoDto<Curso>> Executar(int registrosQuantidade, int paginaNumero)
        {
            var paginacao = new Paginacao(paginaNumero, registrosQuantidade);

            return await mediator.Send(new ObterCursosCadastradosQuery(paginacao));
        }
    }
}
