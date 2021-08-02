using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Queries;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarCargaProfessoresInativosUseCase : IRealizarCargaProfessoresInativosUseCase
    {
        private readonly IMediator mediator;

        public RealizarCargaProfessoresInativosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<CarregarProfessoresInativosDto>();

            await ObterUltimaDataExecucao(dto);

            var professoresParaInativar = await mediator.Send(new ObterProfessoresInativosPorAnoLetivoQuery(DateTime.Now.Year, dto.DataReferencia, dto.Rf));

            if (professoresParaInativar != null && professoresParaInativar.Any())
            {
                var professoresEFuncionariosInativacao = new FiltroProfessoresInativosDto(dto.DataReferencia, professoresParaInativar);
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaInativarProfessorTratar, professoresEFuncionariosInativacao));
            }
            else
            {
                SentrySdk.CaptureMessage($"Não foi possível localizar a alunos para o ANO: {DateTime.Now.Year}, REFERÊNCIA: {dto.DataReferencia} e ALUNO: {dto.Rf} na base do EOL!");
            }

            await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.ProfessorInativar));

            return true;
        }

        private async Task ObterUltimaDataExecucao(CarregarProfessoresInativosDto dto)
        {
            var dataUltimaExecucao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.ProfessorInativar));
            var diasInativacaoFuncionario = await mediator.Send(new ObterParametroSistemaPorTipoEAnoQuery(ETipoParametroSistema.DiasInativacaoFuncionario, 2021));
            dto.DataReferencia = dataUltimaExecucao.AddDays(-double.Parse(diasInativacaoFuncionario.Valor));
        }
    }
}

