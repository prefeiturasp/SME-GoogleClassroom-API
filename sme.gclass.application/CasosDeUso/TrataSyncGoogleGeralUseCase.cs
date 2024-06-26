﻿using System;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleGeralUseCase : ITrataSyncGoogleGeralUseCase
    {
        private readonly IMediator mediator;
        private readonly ConsumoDeFilasOptions consumoDeFilasOptions;

        public TrataSyncGoogleGeralUseCase(IMediator mediator, ConsumoDeFilasOptions consumoDeFilasOptions)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
            this.consumoDeFilasOptions = consumoDeFilasOptions ?? throw new System.ArgumentNullException(nameof(consumoDeFilasOptions));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var resposta = mensagemRabbit.Mensagem;

            var publicarCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoSync, RotasRabbit.FilaCursoSync, resposta));
            var publicarFuncionario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaFuncionarioSync, RotasRabbit.FilaFuncionarioSync, resposta));
            var publicarProfessor = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorSync, RotasRabbit.FilaProfessorSync, resposta));
            var publicarAluno = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaAlunoSync, RotasRabbit.FilaAlunoSync, resposta));
            var publicarAtribuicoesProfessores = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorCursoAtribuicaoSync, RotasRabbit.FilaProfessorCursoAtribuicaoSync, resposta));
            var publicarGradesAlunos = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoGradeSync, RotasRabbit.FilaCursoGradeSync, resposta));
            var publicarFuncionarioIndireto = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaFuncionarioIndiretoSync, RotasRabbit.FilaFuncionarioIndiretoSync, resposta));
            var publicarCursoUsuarioRemovido = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmasCarregar, resposta));
            var publicarTratamentoDeErrosAlunos = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaAlunoErroSync, RotasRabbit.FilaAlunoErroSync, resposta));
            var publicarTratamentoDeErrosProfessores = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorErroSync, RotasRabbit.FilaProfessorErroSync, resposta));
            var publicarTratamentoDeErrosFuncionarios = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaFuncionarioErroSync, RotasRabbit.FilaFuncionarioErroSync, resposta));
            var publicarCursoErro = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoErroSync, RotasRabbit.FilaCursoErroSync, resposta));
            
            var mensagemCelp = new MensagemRabbit(JsonConvert.SerializeObject(new FiltroSincronizacaoCelpDto(DateTime.Now.Year)));
            var publicarCursoCelp = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursosCelpSync, RotasRabbit.FilaGsaCursosCelpSync, mensagemCelp));

            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoExtintoArquivarCarregar, new FiltroArquivamentoTurmasDto()));

            #region Cargas GSA
            // Mural de Avisos
            if (consumoDeFilasOptions.Gsa.CargaMuralAvisosGsa)
            {
                // Mural de Avisos
                var filtroAvisosGsa = new FiltroCargaMuralAvisosCursoDto();
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaMuralAvisosCarregar, filtroAvisosGsa));
            }
            // Atividades
            if (consumoDeFilasOptions.Gsa.CargaAtividadesGsa)
            {
                var filtroGsa = new FiltroCargaGsaDto();
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaAtividadesCarregar, filtroGsa));

                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaNotasAtividadesCarregar, filtroGsa));
            }
            #endregion

            var publicarInativarUsuario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaInativarUsuarioCarregar, RotasRabbit.FilaGsaInativarUsuarioCarregar, resposta));

            if (!publicarCurso)
                throw new NegocioException("Erro ao enviar a sync de cursos.");

            if (!publicarFuncionario)
                throw new NegocioException("Erro ao enviar a sync de funcionários.");

            if (!publicarProfessor)
                throw new NegocioException("Erro ao enviar a sync de professores.");

            if (!publicarAluno)
                throw new NegocioException("Erro ao enviar a sync de alunos.");

            if (!publicarAtribuicoesProfessores)
                throw new NegocioException("Erro ao enviar a sync de atribuições de professores.");

            if(!publicarGradesAlunos)
                throw new NegocioException("Erro ao enviar a sync de grades.");

            if (!publicarCursoUsuarioRemovido)
                throw new NegocioException("Erro ao enviar a sync de cursos usuários removidos.");

            if (!publicarFuncionarioIndireto)
                throw new NegocioException("Erro ao enviar a sync de funcionários indiretos.");

            if (!publicarTratamentoDeErrosAlunos)
                throw new NegocioException("Erro ao enviar o tratamento de erros de alunos.");

            if (!publicarTratamentoDeErrosProfessores)
                throw new NegocioException("Erro ao enviar o tratamento de erros de professores.");

            if (!publicarTratamentoDeErrosFuncionarios)
                throw new NegocioException("Erro ao enviar o tratamento de erros de funcionarios.");

            if (!publicarCursoErro)
                throw new NegocioException("Erro ao enviar a sync de cursos erro.");

            if (!publicarInativarUsuario)
                throw new NegocioException("Erro ao enviar a sync de inativar usuários (alunos).");
            
            if (!publicarCursoCelp)
                throw new NegocioException("Erro ao realizar a sincronização de cursos CELP.");

            return await Task.FromResult(true);
        }
    }
}
