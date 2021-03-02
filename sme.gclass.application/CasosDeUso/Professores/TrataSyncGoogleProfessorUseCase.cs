using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
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
            try
            {
                var ultimaAtualizacao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.ProfessorAdicionar));

                var paginacao = new Paginacao(0, 0);
                var professoresParaIncluirGoogle = await mediator.Send(new ObterProfessoresParaIncluirGoogleQuery(ultimaAtualizacao, paginacao));
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

                await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.ProfessorAdicionar, DateTime.Today));
                return true;
            }
            catch (Exception ex)
            {
                throw new NegocioException($"Não foi possível iniciar a inclusão de novos professores no Google Classroom. {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        private async Task IncluirProfessorComErroAsync(ProfessorEol professorParaIncluirGoogle, string mensagem)
        {
            var professorComErro = new IncluirUsuarioErroCommand(
                                professorParaIncluirGoogle.Rf,
                                professorParaIncluirGoogle.Email,
                                mensagem,
                                UsuarioTipo.Professor,
                                ExecucaoTipo.ProfessorAdicionar,
                                DateTime.Now);
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