using MediatR;
using Newtonsoft.Json;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ProcessarSincronizacaoComparativoCursoUseCase : IProcessarSincronizacaoComparativoCursoUseCase
    {
        private readonly IMediator mediator;

        public ProcessarSincronizacaoComparativoCursoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var comparativoCurso = JsonConvert.DeserializeObject<CursoComparativo>(mensagemRabbit.Mensagem.ToString());
            if (comparativoCurso is null) return false;

            try
            {
                var cursoGoogle = await mediator.Send(new ObterCursoGooglePorIdQuery(Convert.ToInt64(comparativoCurso.Id)));

                if(cursoGoogle == null)
                {
                    var command = new InserirComparativoCursoCommand(comparativoCurso);
                    return await mediator.Send(command);
                }
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return false;
            }
            return false;
        }
    }
}