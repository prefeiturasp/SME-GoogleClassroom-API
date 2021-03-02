using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCadastradosUseCase : IObterAlunosCadastradosUseCase
    {
        private readonly IMediator mediator;

        public ObterAlunosCadastradosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }
        public async Task<PaginacaoResultadoDto<Usuario>> Executar(int registrosQuantidade, int paginaNumero)
        {
            var paginacao = new Paginacao(paginaNumero, registrosQuantidade);

            return await mediator.Send(new ObterAlunosCadastradosQuery(paginacao));
        }
    }
}
