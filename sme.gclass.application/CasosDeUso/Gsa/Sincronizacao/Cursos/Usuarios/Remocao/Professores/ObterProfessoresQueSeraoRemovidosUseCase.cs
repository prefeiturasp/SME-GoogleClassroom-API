using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresQueSeraoRemovidosUseCase : AbstractUseCase, IObterProfessoresQueSeraoRemovidosUseCase
    {
        public ObterProfessoresQueSeraoRemovidosUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<PaginacaoResultadoDto<RemoverAtribuicaoProfessorCursoEolDto>> Executar(FiltroObterUsuariosQueSeraoRemovidosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);

            var periodo = await ObterDatas();

            return await mediator.Send(new ObterProfessoresParaRemoverCursoPaginadoQuery(filtro.TurmaId, periodo.dataInicio, periodo.dataFim, paginacao));
        }

        private async Task<(DateTime dataInicio, DateTime dataFim)> ObterDatas()
        {
            var dias = 10;
            var ultimaExecucao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.UsuarioCursoRemover));
            return (ultimaExecucao.AddDays(-dias), DateTime.Today.AddDays(-dias));
        }
    }
}
