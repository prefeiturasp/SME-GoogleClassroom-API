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
    public class TratarSyncCursosComparativosUseCase : ITratarSyncCursosComparativosUseCase
    {
        protected readonly IMediator mediator;

        public TratarSyncCursosComparativosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit?.Mensagem is null)
                throw new NegocioException("Não foi possível iniciar a atualização de cursos para comparativo sem GoogleClassroomId.");

            var dto = JsonConvert.DeserializeObject<RetornoPadraoCursosGoogleDto>(mensagemRabbit.Mensagem.ToString());

            var resultadoPaginacao = await mediator.Send(new ObterCursosComparativosQuery(dto.NextToken));
            foreach (var curso in resultadoPaginacao.Courses)
            {
                try
                {
                    var publicarAluno = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoComparativoAtualizar, RotasRabbit.FilaCursoComparativoAtualizar, curso));
                    if (!publicarAluno) continue;
                }
                catch (Exception ex)
                {
                    SentrySdk.CaptureException(ex);
                    continue;
                }
            }

            if (dto.NextToken != null)
                await PublicaProximaPaginaAsync(null);

            return true;
        }

        protected virtual async Task PublicaProximaPaginaAsync(RetornoPadraoCursosGoogleDto dto)
        {
            try
            {
                var syncCursoComparativo = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoComparativoSync, RotasRabbit.FilaCursoComparativoSync, dto));
                if (!syncCursoComparativo)
                    SentrySdk.CaptureMessage("Não foi possível sincronizar os cursos para comparativo");
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }
        }
    }
}
