using MediatR;
using Nest;
using SME.GoogleClassroom.Aplicacao.Queries;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterEscolasUseCase : IObterEscolasUseCase
    {
        private readonly IMediator mediator;

        public ObterEscolasUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public Task<IEnumerable<EscolaDTO>> Executar() => mediator.Send(new ObterEscolasQuery());


    }
}