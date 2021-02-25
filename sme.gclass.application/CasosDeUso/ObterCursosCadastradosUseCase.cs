using MediatR;
using SME.GoogleClassroom.Dominio;
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
        public async Task<IEnumerable<Curso>> Executar()
        {
            return await mediator.Send(new ObterCursosCadastradosQuery());
        }
    }
}
