using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleAtribuicoesDosProfessoresUseCase : ITrataSyncGoogleAtribuicoesDosProfessoresUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleAtribuicoesDosProfessoresUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            
            var filtro = mensagemRabbit.Mensagem != null ? mensagemRabbit.ObterObjetoMensagem<FiltroCargaInicialDto>() : null;
            var ultimaAtualizacao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.AtribuicaoProfessorCursoAdicionar));

            var paginacao = new Paginacao(0, 0);
            var parametrosCargaInicialDto = filtro != null ? new ParametrosCargaInicialDto(filtro.TiposUes, filtro.Ues, filtro.Turmas, filtro.AnoLetivo) : 
                await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));
            var atribuicoesDeCursosProfessores = await mediator.Send(new ObterAtribuicoesDeCursosDosProfessoresQuery(ultimaAtualizacao, paginacao, parametrosCargaInicialDto));

            foreach (var atribuicaoDeCursoDoProfessor in atribuicoesDeCursosProfessores.Items)
            {
                var cursoDoProfessorParaIncluir = new ProfessorCursoEol(atribuicaoDeCursoDoProfessor.Rf, atribuicaoDeCursoDoProfessor.TurmaId, atribuicaoDeCursoDoProfessor.ComponenteCurricularId);

                try
                {
                    var publicarProfessor = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorCursoIncluir, RotasRabbit.FilaProfessorCursoIncluir, cursoDoProfessorParaIncluir));
                    if (!publicarProfessor)
                    {
                        await IncluirCursoDoProfessorComErroAsync(cursoDoProfessorParaIncluir, ObterMensagemDeErro(cursoDoProfessorParaIncluir));
                    }
                }
                catch (Exception ex)
                {
                    await IncluirCursoDoProfessorComErroAsync(cursoDoProfessorParaIncluir, ObterMensagemDeErro(cursoDoProfessorParaIncluir, ex));
                }
            }

            await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.AtribuicaoProfessorCursoAdicionar, DateTime.Today));
            return true;
        }

        private async Task IncluirCursoDoProfessorComErroAsync(ProfessorCursoEol cursoDoprofessorParaIncluirGoogle, string mensagem)
        {
            var command = new IncluirCursoUsuarioErroCommand(
                cursoDoprofessorParaIncluirGoogle.Rf,
                cursoDoprofessorParaIncluirGoogle.TurmaId,
                cursoDoprofessorParaIncluirGoogle.ComponenteCurricularId,
                ExecucaoTipo.AtribuicaoProfessorCursoAdicionar,
                ErroTipo.Negocio,
                mensagem);

            await mediator.Send(command);
        }

        private static string ObterMensagemDeErro(ProfessorCursoEol cursoDoprofessorParaIncluirGoogle, Exception ex = null)
        {
            var mensagem = $"Não foi possível inserir o curso [TurmaId:{cursoDoprofessorParaIncluirGoogle.TurmaId}, ComponenteCurricularId:{cursoDoprofessorParaIncluirGoogle.ComponenteCurricularId}] professor RF{cursoDoprofessorParaIncluirGoogle.Rf} na fila para inclusão no Google Classroom.";
            if (ex is null) return mensagem;
            return $"{mensagem}. {ex.InnerException?.Message ?? ex.Message}. {ex.StackTrace}";
        }
    }
}