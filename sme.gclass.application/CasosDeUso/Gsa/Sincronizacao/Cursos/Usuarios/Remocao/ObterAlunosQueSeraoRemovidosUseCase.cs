using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosQueSeraoRemovidosUseCase : AbstractUseCase, IObterAlunosQueSeraoRemovidosUseCase
    {
        public ObterAlunosQueSeraoRemovidosUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<PaginacaoResultadoDto<AlunoEol>> Executar(FiltroObterAlunosQueSeraoRemovidosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);

            var ehDataReferenciaPrincipal = false;
            if(filtro.DataReferencia == DateTime.MinValue) filtro.DataReferencia = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.UsuarioCursoRemover));
            if (filtro.DataReferencia == DateTime.Today || filtro.DataReferencia.AddDays(1) == DateTime.Today)
            {
                ehDataReferenciaPrincipal = true;
            }

            return await mediator.Send(new ObterAlunosQueSeraoRemovidosPorAnoLetivoETurmaQuery(paginacao, filtro.AnoLetivo, filtro.TurmaId, filtro.DataReferencia, ehDataReferenciaPrincipal));
        }
    }
}
