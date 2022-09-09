using MediatR;
using Sentry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleCursoErroUseCase : ITrataSyncGoogleCursoErroUseCase
    {
        private readonly IMediator mediator;
        private readonly bool _deveExecutarIntegracao;

        public TrataSyncGoogleCursoErroUseCase(IMediator mediator, VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            try
            {
                var filtroCargaInicialDto = UtilsDto.ObterFiltroParametrosIniciais(mensagemRabbit);
                var cursosErroParaTratar = await mediator.Send(new ObterCursosComErroQuery());
                if (cursosErroParaTratar != null && cursosErroParaTratar.Any())
                {
                    foreach (var cursoErroParaTratar in cursosErroParaTratar)
                    {
                       var filtroCursoErro = new FiltroCursoErroDto(cursoErroParaTratar, filtroCargaInicialDto);
                       await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoErroTratar, RotasRabbit.FilaCursoErroTratar, filtroCursoErro));
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new SalvarLogViaRabbitCommand($"TrataSyncGoogleCursoErroUseCase", LogNivel.Critico, LogContexto.Gsa, ex.Message, ex.StackTrace));               
            }
            return false;
        }
    }
}
