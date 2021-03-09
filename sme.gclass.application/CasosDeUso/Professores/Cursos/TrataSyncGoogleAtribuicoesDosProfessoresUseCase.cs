﻿using MediatR;
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
            try
            {
                var ultimaAtualizacao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.AtribuicaoProfessorCursoAdicionar));

                var paginacao = new Paginacao(0, 0);
                var atribuicoesDeCursosProfessores = await mediator.Send(new ObterAtribuicoesDeCursosDosProfessoresQuery(ultimaAtualizacao, paginacao));

                foreach (var atribuicaoDeCursoDoProfessor in atribuicoesDeCursosProfessores.Items)
                {
                    var cursoDoProfessorParaIncluir = new ProfessorCursoEol(atribuicaoDeCursoDoProfessor.Rf, atribuicaoDeCursoDoProfessor.TurmaId, atribuicaoDeCursoDoProfessor.ComponenteCurricularId);

                    try
                    {
                        var publicarProfessor = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorIncluir, RotasRabbit.FilaProfessorIncluir, cursoDoProfessorParaIncluir));
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

                await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.ProfessorAdicionar, DateTime.Today));
                return true;
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                throw new NegocioException($"Não foi possível iniciar a inclusão de novos professores no Google Classroom. {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        private async Task IncluirCursoDoProfessorComErroAsync(ProfessorCursoEol cursoDoprofessorParaIncluirGoogle, string mensagem)
        {
            var command = new IncluirCursoUsuarioErroCommand(
                cursoDoprofessorParaIncluirGoogle.Rf,
                cursoDoprofessorParaIncluirGoogle.TurmaId,
                cursoDoprofessorParaIncluirGoogle.ComponenteCurricularId,
                ExecucaoTipo.ProfessorCursoAdicionar,
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