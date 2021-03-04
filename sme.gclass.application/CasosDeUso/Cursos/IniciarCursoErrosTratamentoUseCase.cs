using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarCursoErrosTratamentoUseCase : IIniciarCursoErrosTratamentoUseCase
    {
        private readonly IMediator mediator;

        public IniciarCursoErrosTratamentoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Executar()
        {
            var cursosComErroComEmail = await mediator.Send(new ObterCursosComErroComEmailQuery());
        }
    }
}