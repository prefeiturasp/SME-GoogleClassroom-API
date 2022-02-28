using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSincronizacaoGsaFormacaoCidadeTurmasExcluirUseCase : IIniciarSincronizacaoGsaFormacaoCidadeTurmasExcluirUseCase
    {
        private readonly IMediator mediator;

        public IniciarSincronizacaoGsaFormacaoCidadeTurmasExcluirUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(string jsonCursos)
        {
            var jsonResult = JsonConvert.DeserializeObject<FiltroFormacaoCidadeTurmaCursoExcluirDto>(jsonCursos);

            foreach (var curso in jsonResult.courses)
                await mediator.Send(new ExcluirCursoGoogleCommand(curso.id));
            return true;
        }
    }
}