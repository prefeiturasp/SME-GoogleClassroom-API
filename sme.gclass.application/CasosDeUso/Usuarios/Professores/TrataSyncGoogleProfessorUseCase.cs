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
    public class TrataSyncGoogleProfessorUseCase : ITrataSyncGoogleProfessorUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleProfessorUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            var filtro = mensagem.Mensagem != null ? mensagem.ObterObjetoMensagem<FiltroCargaInicialDto>() : null;
            var ultimaAtualizacao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.ProfessorAdicionar));
            var paginacao = new Paginacao(0, 0);
            var parametrosCargaInicialDto = filtro != null ? new ParametrosCargaInicialDto(filtro.TiposUes, filtro.Ues, filtro.Turmas, filtro.AnoLetivo) :
                await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));
            var professoresParaIncluirGoogle = await mediator.Send(new ObterProfessoresParaIncluirGoogleQuery(ultimaAtualizacao, paginacao, string.Empty, parametrosCargaInicialDto));

            foreach (var professorParaIncluirGoogle in professoresParaIncluirGoogle.Items)
            {
                try
                {
                    var publicarProfessor = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorIncluir, RotasRabbit.FilaProfessorIncluir, professorParaIncluirGoogle));                    
                    if (!publicarProfessor)
                    {
                        await IncluirProfessorComErroAsync(professorParaIncluirGoogle, ObterMensagemDeErro(professorParaIncluirGoogle.Rf));
                    }
                }
                catch (Exception ex)
                {
                    await IncluirProfessorComErroAsync(professorParaIncluirGoogle, ObterMensagemDeErro(professorParaIncluirGoogle.Rf, ex));
                }
            }

            if (professoresParaIncluirGoogle.TotalRegistros > 1)
                await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.ProfessorAdicionar, DateTime.Today));

            return true;
        }

        private async Task IncluirProfessorComErroAsync(ProfessorEol professorParaIncluirGoogle, string mensagem)
        {
            var professorComErro = new IncluirUsuarioErroCommand(
                                professorParaIncluirGoogle.Rf,
                                professorParaIncluirGoogle.Email,
                                mensagem,
                                UsuarioTipo.Professor,
                                ExecucaoTipo.ProfessorAdicionar);
            await mediator.Send(professorComErro);
        }

        private static string ObterMensagemDeErro(long cdRegistroFuncional, Exception ex = null)
        {
            var mensagem = $"Não foi possível inserir o professor RF{cdRegistroFuncional} na fila para inclusão no Google Classroom.";
            if (ex is null) return mensagem;
            return $"{mensagem}. {ex.InnerException?.Message ?? ex.Message}";
        }
    }
}