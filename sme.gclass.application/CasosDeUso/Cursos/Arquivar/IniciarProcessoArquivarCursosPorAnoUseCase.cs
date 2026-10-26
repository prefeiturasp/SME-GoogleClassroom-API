using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarProcessoArquivarCursosPorAnoUseCase : AbstractUseCase, IIniciarProcessoArquivarCursosPorAnoUseCase
    {
        public IniciarProcessoArquivarCursosPorAnoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(int? anoLetivo, long? turmaId = null)
        {
            if (!anoLetivo.HasValue || anoLetivo.Value <= 0 || anoLetivo.Value < 1900 || anoLetivo.Value > DateTime.Today.Year + 10)
                throw new NegocioException("O ano letivo deve ser informado e válido.");

            if (turmaId.HasValue)
            {
                var turmaExiste = await mediator.Send(new ExisteTurmaPorCodigoQuery(turmaId.Value));
                if (!turmaExiste)
                    throw new NegocioException("A turma informada não foi localizada na base do EOL.");
            }

            var filtro = new FiltroArquivamentoCursoDto(anoLetivo.Value, turmaId);
            var publicado = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoArquivarCarregar, filtro));
            if (!publicado)
                throw new NegocioException("Não foi possível publicar a mensagem para arquivamento de cursos.");

            return publicado;
        }
    }
}
