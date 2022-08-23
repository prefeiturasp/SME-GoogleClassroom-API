using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarSincronizacaoCursosCelpUseCase : ITratarSincronizacaoCursosCelpUseCase
    {
        private readonly IMediator mediator;

        public TratarSincronizacaoCursosCelpUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            try
            {
                if (mensagem?.Mensagem is null)
                    throw new NegocioException("Não foi possível iniciar a sincronização com GSA dos cursos do CELP.");

                var filtroSincronizacao = mensagem.ObterObjetoMensagem<FiltroSincronizacaoCelpDto>();
                
                var configsCelp = await mediator.Send(new ObterConfiguracaoInicialCelpQuery());

                var componentesCurricularsIds = await ObterComponentesCurriculares(filtroSincronizacao.AnoLetivo);

                var cursosCelpEol = await mediator.Send(new ObterCursosCelpQuery(componentesCurricularsIds,filtroSincronizacao.AnoLetivo));

                foreach (var configCelp in configsCelp)
                {
                    var cursoCelp = cursosCelpEol.FirstOrDefault(f =>f.UeCodigo.Equals(configCelp.UeCodigo) && f.DreCodigo.Equals(configCelp.DreCodigo));

                    if (cursoCelp != null)
                    {
                        var filtroFilaTurma = new FiltroTurmaComponenteCurricularUeDto()
                        {
                            TurmaCodigo = cursoCelp.TurmaCodigo,
                            ComponenteCurricularCodigo = cursoCelp.ComponenteCodigo,
                            ComponenteCurricularNome = cursoCelp.DescricaoGradePrograma
                        };

                        await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursosCelpTurmaTratar, filtroFilaTurma));    
                    }
                    else
                        await mediator.Send(new SalvarLogViaRabbitCommand($"O código da Ue {configCelp.UeCodigo} e da Dre {configCelp.DreCodigo} não foi localizado no retorno do EOL", LogNivel.Negocio, LogContexto.CelpGsa, string.Empty, rastreamento: string.Empty));
                }

                return true;
            }
            catch (Exception ex)
            {
                mediator.Send(new SalvarLogViaRabbitCommand($"Erro ao iniciar a sincronização dos cursos CELP", LogNivel.Critico, LogContexto.CelpGsa, ex.Message, rastreamento: ex.StackTrace));
                return false;
            }
        }

        private async Task<int[]> ObterComponentesCurriculares(int anoLetivo)
        {
            var parametrosComponentesCelp = await ObterParametroSistema(TipoParametroSistema.ComponentesCurricularesCELP, anoLetivo);
            return parametrosComponentesCelp.Valor.Split(',').Select(s => int.Parse(s)).ToArray();
        }

        private async Task<ParametrosSistema> ObterParametroSistema(TipoParametroSistema componentesCurricularesCELP, int anoLetivo)
        {
            return await mediator.Send(new ObterParametroSistemaPorTipoEAnoQuery(componentesCurricularesCELP,anoLetivo));
        }
    }
}