using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarSincronizacaoCursosCelpGoogleUseCase : ITratarSincronizacaoCursosCelpGoogleUseCase
    {
        private readonly IMediator mediator;

        public TratarSincronizacaoCursosCelpGoogleUseCase(IMediator mediator)
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

                var emailCoordenadorCurso = await ObterInformacoesCoordenadorCurso(filtroSincronizacao.AnoLetivo);

                if (emailCoordenadorCurso == null)
                {
                    await mediator.Send(new SalvarLogViaRabbitCommand($"O e-mail do Coordenador dos cursos para o ano de {filtroSincronizacao.AnoLetivo} não foi localizado. Sincronização Celp encerrada", LogNivel.Negocio, LogContexto.CelpGsa, string.Empty, rastreamento: string.Empty));
                    return true;
                }

                //configsCelp = new List<ConfiguracaoCelpDto>() { configsCelp.FirstOrDefault() };
                
                foreach (var configCelp in configsCelp)
                {
                    var cursosCelpEolParaInserir = cursosCelpEol.Where(f =>f.UeCodigo.Equals(configCelp.UeCodigo) && f.DreCodigo.Equals(configCelp.DreCodigo));

                    // cursosCelpEolParaInserir = new List<CursoCelpEolDto>(){cursosCelpEolParaInserir.FirstOrDefault()};
                    
                    foreach (var cursoCelpEolParaInserir in cursosCelpEolParaInserir)
                    {
                        if (cursoCelpEolParaInserir != null)
                        {
                            var filtroCursoCelp = new FiltroCursoCelpDto()
                            {
                                TurmaId = long.Parse(cursoCelpEolParaInserir.TurmaCodigo),
                                ComponenteCurricularId = long.Parse(cursoCelpEolParaInserir.ComponenteCodigo),
                                ComponenteCurricularNome = cursoCelpEolParaInserir.DescricaoGradePrograma,
                                Secao = cursoCelpEolParaInserir.Secao,
                                UeCodigo = cursoCelpEolParaInserir.UeCodigo,
                                TipoId = cursoCelpEolParaInserir.TurmaTipo,
                                EmailProfessor = configCelp.Email,
                                TipoEscola = cursoCelpEolParaInserir.TipoEscola,
                                EmailCoordenador = emailCoordenadorCurso.Email,
                                IndiceCoordenador = emailCoordenadorCurso.Indice,
                                RfCoordenador = emailCoordenadorCurso.Rf,
                                AnoLetivo = filtroSincronizacao.AnoLetivo
                            };

                            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoCelpIncluir, filtroCursoCelp));    
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                mediator.Send(new SalvarLogViaRabbitCommand($"Erro ao iniciar a sincronização dos cursos CELP", LogNivel.Critico, LogContexto.CelpGsa, ex.Message, rastreamento: ex.StackTrace));
                return false;
            }
        }

        private async Task<FuncionarioGoogle> ObterInformacoesCoordenadorCurso(int anoLetivo)
        {
            var parametroEmailCoordenadorCurso = await ObterParametroEmailCoordenador(anoLetivo);

            return await ObterCoordenadorCurso(parametroEmailCoordenadorCurso.Valor);
        }

        private async Task<FuncionarioGoogle> ObterCoordenadorCurso(string emailCoordenadorCursoParametro)
        {
            var coordenadorDoCurso = await mediator.Send(new ObterFuncionariosGooglePorEmailQuery(emailCoordenadorCursoParametro));
            
            return coordenadorDoCurso.FirstOrDefault();
        }

        private async Task<ParametrosSistema> ObterParametroEmailCoordenador(int anoLetivo)
        {
            var parametroEmailCoordenador = await ObterParametroSistema(TipoParametroSistema.EmailCoordenadorCELP,anoLetivo);
            if (parametroEmailCoordenador is null)
                throw new NegocioException(
                    $"Parâmetro do E-mail do Coordenador do CELP não localizado para o ano {anoLetivo}");
            return parametroEmailCoordenador;
        }

        private async Task<IEnumerable<int>> ObterComponentesCurriculares(int anoLetivo)
        {
            var parametrosComponentesCelp = await ObterParametroSistema(TipoParametroSistema.ComponentesCurricularesCELP, anoLetivo);
            return parametrosComponentesCelp.Valor.Split(',').Select(s => int.Parse(s)).ToList();
        }

        private async Task<ParametrosSistema> ObterParametroSistema(TipoParametroSistema tipoParametroSistema, int anoVigencia)
        {
            return await mediator.Send(new ObterParametroSistemaPorTipoEAnoQuery(tipoParametroSistema,anoVigencia));
        }
    }
}