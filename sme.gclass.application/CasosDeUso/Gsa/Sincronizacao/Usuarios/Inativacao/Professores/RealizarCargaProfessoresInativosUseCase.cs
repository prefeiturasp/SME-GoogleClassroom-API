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
    public class RealizarCargaProfessoresInativosUseCase : ICarregarProfessoresEFuncionariosParaInativar
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

            await TratarInativacaoFuncionariosIndiretos(dto);

            await TratarInativacaoDeProfessoresEFuncionarios(dto);

            await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.ProfessorInativar));

            return true;
        }

        private async Task TratarInativacaoDeProfessoresEFuncionarios(CarregarProfessoresInativosDto dto)
        {
            var professoresEFuncionariosParaInativar = await mediator.Send(new ObterProfessoresInativosPorAnoLetivoQuery(DateTime.Now.Year, dto.DataReferencia, dto.Rf));
            if (professoresEFuncionariosParaInativar != null && professoresEFuncionariosParaInativar.Any())
            {
                var professoresEFuncionariosInativacao = new FiltroProfessoresEFuncionarioInativosDto(dto.DataReferencia, professoresEFuncionariosParaInativar, null);
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaTratarPreofessoresEFuncionariosInativar, professoresEFuncionariosInativacao));
            }
            else
            {
                SentrySdk.CaptureMessage($"Não foi possível localizar a professores e funcionários para o ANO: {DateTime.Now.Year}, REFERÊNCIA: {dto.DataReferencia} e RF: {dto.Rf} na base do EOL!");
            }
        }

        private async Task TratarInativacaoFuncionariosIndiretos(CarregarProfessoresInativosDto dto)
        {
            var funcionariosIndiretosInativar = await mediator.Send(new ObterFuncionariosIndiretosQueSeraoInativadosQuery(dto.Cpf));
            if (funcionariosIndiretosInativar != null && funcionariosIndiretosInativar.Any())
            {
                var funcionariosIndiretosInativacao = new FiltroProfessoresEFuncionarioInativosDto(dto.DataReferencia, null, funcionariosIndiretosInativar);
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaTratarPreofessoresEFuncionariosInativar, funcionariosIndiretosInativacao));
            }
            else
            {
                SentrySdk.CaptureMessage($"Não foi possível localizar a funcionários indiretos para o ANO: {DateTime.Now.Year}, REFERÊNCIA: {dto.DataReferencia} e CPF: {dto.Cpf} na base do EOL!");
            }
        }

        private async Task ObterUltimaDataExecucao(CarregarProfessoresInativosDto dto)
        {
            var dataUltimaExecucao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.ProfessorInativar));
            var diasInativacaoFuncionario = await mediator.Send(new ObterParametroSistemaPorTipoEAnoQuery(TipoParametroSistema.DiasInativacaoFuncionario, 2021));
            dto.DataReferencia = dataUltimaExecucao.AddDays(-double.Parse(diasInativacaoFuncionario.Valor));
        }
    }
}

