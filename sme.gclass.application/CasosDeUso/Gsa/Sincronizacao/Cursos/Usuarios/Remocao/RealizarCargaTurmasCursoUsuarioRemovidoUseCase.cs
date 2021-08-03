using MediatR;
using Sentry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarCargaTurmasCursoUsuarioRemovidoUseCase : IRealizarCargaTurmasCursoUsuarioRemovidoUseCase
    {
        private readonly IMediator mediator;

        public RealizarCargaTurmasCursoUsuarioRemovidoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<CarregarTurmaRemoverCursoUsuarioDto>();

            var datasReferencias = await ObterDatasReferencias(dto.ProcessarAlunos, dto.ProcessarProfessores, dto.ProcessarFuncionario);

            var turmas = await mediator.Send(new ObterTurmasIdsCadastradasQuery(DateTime.Now.Year, dto.TurmaId));
            if (turmas != null && turmas.Any())
            {
                foreach (var turma in turmas)
                {
                    var filtroTurma = new FiltroTurmaRemoverCursoUsuarioDto(
                        datasReferencias.datasAluno,
                        datasReferencias.datasProfessor,
                        datasReferencias.datasFuncionario,
                        turma,
                        dto.ProcessarAlunos,
                        dto.ProcessarProfessores,
                        dto.ProcessarFuncionario);

                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmaTratar, filtroTurma));
                }
            }
            else
            {
                SentrySdk.CaptureMessage($"Não foi possível localizar curso de turma id {dto.TurmaId} na base do GSA!");
            }

            if (!dto.TurmaId.HasValue)
                await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.UsuarioCursoRemover));

            return true;
        }

        private async Task<(VigenciaDto datasAluno, VigenciaDto datasProfessor, VigenciaDto datasFuncionario)> ObterDatasReferencias(bool processarAlunos, bool processarProfessores, bool processarFuncionarios)
        {
            var ano = DateTime.Now.Year;
            var diasRemocaoAluno = processarAlunos ?
                await ObterDataInicio(TipoParametroSistema.DiasRemocaoAluno, ano) : 0;
            var diasRemocaoProfessor = processarProfessores ?
                await ObterDataInicio(TipoParametroSistema.DiasRemocaoProfessor, ano) : 0;
            var diasRemocaoFuncionario = processarFuncionarios ?
                await ObterDataInicio(TipoParametroSistema.DiasRemocaoFuncionario, ano) : 0;

            var dataUltimaExecucao =
                await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.UsuarioCursoRemover));

            return (new VigenciaDto(dataUltimaExecucao.AddDays(-diasRemocaoAluno), DateTime.Today.AddDays(-diasRemocaoAluno))
                , new VigenciaDto(dataUltimaExecucao.AddDays(-diasRemocaoProfessor), DateTime.Today.AddDays(-diasRemocaoProfessor))
                , new VigenciaDto(dataUltimaExecucao.AddDays(-diasRemocaoFuncionario), DateTime.Today.AddDays(-diasRemocaoFuncionario)));
        }

        private async Task<int> ObterDataInicio(TipoParametroSistema tipoParametro, int ano)
        {
            var parametroDiasRemocao = await mediator.Send(new ObterParametroSistemaPorTipoEAnoQuery(tipoParametro, ano));
            if (parametroDiasRemocao is null || !parametroDiasRemocao.Ativo)
                throw new NegocioException($"Não localizado o parâmetro de controle de dias para execução de remoção do curso. Tipo: {tipoParametro}");

            return int.Parse(parametroDiasRemocao.Valor);
        }
    }
}