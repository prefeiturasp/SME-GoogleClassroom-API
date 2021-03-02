﻿using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleAlunoUseCase : ITrataSyncGoogleAlunoUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleAlunoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            try
            {
                var ultimaAtualizacao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.AlunoAdicionar));

                var paginacao = new Paginacao(0, 0);
                var alunosParaIncluirGoogle = await mediator.Send(new ObterAlunosNovosQuery(ultimaAtualizacao, paginacao));
                foreach (var alunoParaIncluirGoogle in alunosParaIncluirGoogle.Items)
                {
                    try
                    {
                        var publicarAluno = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaAlunoIncluir, RotasRabbit.FilaAlunoIncluir, alunoParaIncluirGoogle));
                        if (!publicarAluno)
                        {
                            await IncluirAlunoComErroAsync(alunoParaIncluirGoogle, ObterMensagemDeErro(alunoParaIncluirGoogle.Codigo));
                        }
                    }
                    catch (Exception ex)
                    {
                        await IncluirAlunoComErroAsync(alunoParaIncluirGoogle, ObterMensagemDeErro(alunoParaIncluirGoogle.Codigo, ex));
                    }
                }

                await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.FuncionarioAdicionar, DateTime.Today));
                return true;
            }
            catch (Exception ex)
            {
                throw new NegocioException($"Não foi possível iniciar a inclusão de novos alunos no Google Classroom. {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        private async Task IncluirAlunoComErroAsync(AlunoEol alunoParaIncluirGoogle, string mensagem)
        {
            var funcionarioComErro = new IncluirUsuarioErroCommand(
                                alunoParaIncluirGoogle.Codigo,
                                alunoParaIncluirGoogle.Email,
                                mensagem,
                                UsuarioTipo.Funcionario,
                                ExecucaoTipo.FuncionarioAdicionar,
                                DateTime.Now);
            await mediator.Send(funcionarioComErro);
        }

        private static string ObterMensagemDeErro(long cdAluno, Exception ex = null)
        {
            var mensagem = $"Não foi possível inserir o aluno RA{cdAluno} na fila para inclusão no Google Classroom.";
            if (ex is null) return mensagem;
            return $"{mensagem}. {ex.InnerException?.Message ?? ex.Message}";
        }
    }
}