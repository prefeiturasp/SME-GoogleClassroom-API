using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarCargaMuralAvisosGsaUseCase : IRealizarCargaMuralAvisosGsaUseCase
    {
        private readonly IMediator mediator;

        public RealizarCargaMuralAvisosGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            var anoAtual = DateTime.Now.Year;
            var cursos = await mediator.Send(new ObterCursosComResponsaveisPorAnoQuery(anoAtual));

            foreach (var curso in cursos)
            {
                try
                {
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaMuralAvisosTratar, new FiltroCargaMuralAvisosCursoDto(curso)));
                }
                catch (Exception ex)
                {
                    SentrySdk.CaptureException(ex);
                    continue;
                }
            }

            return true;
        }
    }
}
