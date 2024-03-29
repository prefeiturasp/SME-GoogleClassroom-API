﻿using RabbitMQ.Client;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Worker.Rabbit
{
    public static class RegistrarFilasRabbitMQ
    {
        private static IDictionary<string, object> argumentos;
        public static void RegistrarFilas(IModel canalRabbit, ConsumoDeFilasOptions consumoDeFilasOptions)
        {
            argumentos = new Dictionary<string, object>
            {
                { "x-queue-mode", "lazy" }
            };

            if (consumoDeFilasOptions.ConsumirFilasSync)
                RegistrarFilasSync(canalRabbit);

            if (consumoDeFilasOptions.ConsumirFilasDeInclusao)
                RegistrarFilasDeInclusao(canalRabbit);

            RegistrarFilasGsa(canalRabbit, consumoDeFilasOptions);
        }

        #region Filas Sync

        private static void RegistrarFilasSync(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaGoogleSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGoogleSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGoogleSync);

            RegistrarFilasCursoSync(canalRabbit);
            RegistrarFilasAlunoSync(canalRabbit);
            RegistrarFilasProfessorSync(canalRabbit);
            RegistrarFilasFuncionarioSync(canalRabbit);
            RegistrarFilasUsuarioSync(canalRabbit);
            RegistrarFilasRemoverUsuariosCursoSync(canalRabbit);
            RegistrarFilasInativarAlunosSync(canalRabbit);
            RegistrarFilasInativarProfessoresEFuncionariosSync(canalRabbit);
            RegistrarFilasFormacaoCidadeSync(canalRabbit);
            RegistrarFilasCelpSync(canalRabbit);
        }

        private static void RegistrarFilasCelpSync(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCursosCelpSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaCursosCelpSync, ExchangeRabbit.GoogleSync,
                RotasRabbit.FilaGsaCursosCelpSync);
            
            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCursoCelpIncluir, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaCursoCelpIncluir, ExchangeRabbit.GoogleSync,
                RotasRabbit.FilaGsaCursoCelpIncluir);
            
            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCursosAlunosCelpSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaCursosAlunosCelpSync, ExchangeRabbit.GoogleSync,
                RotasRabbit.FilaGsaCursosAlunosCelpSync);
            
            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaFuncionarioCursoCelpIncluir, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaFuncionarioCursoCelpIncluir, ExchangeRabbit.GoogleSync,
                RotasRabbit.FilaGsaFuncionarioCursoCelpIncluir);
            
            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaAlunoCelpIncluir, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaAlunoCelpIncluir, ExchangeRabbit.GoogleSync,
                RotasRabbit.FilaGsaAlunoCelpIncluir);
            
            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCursoAlunoCelpIncluir, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaCursoAlunoCelpIncluir, ExchangeRabbit.GoogleSync,
                RotasRabbit.FilaGsaCursoAlunoCelpIncluir);
            
            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCursoUsuarioRemovidoAlunosCelpTratar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaCursoUsuarioRemovidoAlunosCelpTratar, ExchangeRabbit.GoogleSync, 
                RotasRabbit.FilaGsaCursoUsuarioRemovidoAlunosCelpTratar);
        }

        private static void RegistrarFilasFormacaoCidadeSync(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarSmeDre, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarSmeDre, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarSmeDre);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarSmeDreErro, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarSmeDreErro, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarSmeDreErro);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarComponente, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarComponente, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarComponente);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarComponenteErro, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarComponenteErro, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarComponenteErro);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCurso, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCurso, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCurso);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCursoErro, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCursoErro, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCursoErro);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAluno, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAluno, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAluno);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAlunoErro, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAlunoErro, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAlunoErro);
        }

        private static void RegistrarFilasCursoSync(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaCursoSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoProfessorSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoProfessorSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaCursoProfessorSync);
            
            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoAlunoSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoAlunoSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaCursoAlunoSync);
            
            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoGradeSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoGradeSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaCursoGradeSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoFuncionarioSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoFuncionarioSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaCursoFuncionarioSync);
            
            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoErroSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoErroSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaCursoErroSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoErroTratar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoErroTratar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaCursoErroTratar);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoExtintoArquivarCarregar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoExtintoArquivarCarregar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaCursoExtintoArquivarCarregar);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoArquivarTratar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoArquivarTratar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaCursoArquivarTratar);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoArquivarTratarErro, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoArquivarTratarErro, ExchangeRabbit.GoogleSync, RotasRabbit.FilaCursoArquivarTratarErro);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoArquivarSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoArquivarSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaCursoArquivarSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoArquivarSyncErro, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoArquivarSyncErro, ExchangeRabbit.GoogleSync, RotasRabbit.FilaCursoArquivarSyncErro);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoArquivarAnoAnteriorCarregar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoArquivarAnoAnteriorCarregar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaCursoArquivarAnoAnteriorCarregar);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoArquivarCarregar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoArquivarCarregar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaCursoArquivarCarregar);
        }

        private static void RegistrarFilasAlunoSync(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaAlunoSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaAlunoSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaAlunoSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaAlunoCursoSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaAlunoCursoSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaAlunoCursoSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaAlunoErroSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaAlunoErroSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaAlunoErroSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaAlunoErroTratar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaAlunoErroTratar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaAlunoErroTratar);
        }

        private static void RegistrarFilasProfessorSync(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaProfessorSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaProfessorSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaProfessorSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaProfessorCursoSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaProfessorCursoSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaProfessorCursoSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaProfessorCursoAtribuicaoSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaProfessorCursoAtribuicaoSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaProfessorCursoAtribuicaoSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaProfessorErroSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaProfessorErroSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaProfessorErroSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaProfessorErroTratar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaProfessorErroTratar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaProfessorErroTratar);
        }

        private static void RegistrarFilasFuncionarioSync(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaFuncionarioSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaFuncionarioSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaFuncionarioSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaFuncionarioCursoSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaFuncionarioCursoSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaFuncionarioCursoSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaFuncionarioIndiretoSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaFuncionarioIndiretoSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaFuncionarioIndiretoSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaFuncionarioErroSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaFuncionarioErroSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaFuncionarioErroSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaFuncionarioErroTratar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaFuncionarioErroTratar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaFuncionarioErroTratar);
        }

        private static void RegistrarFilasUsuarioSync(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaUsuarioGoogleIdSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaUsuarioGoogleIdSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaUsuarioGoogleIdSync);
        }
        
        private static void RegistrarFilasRemoverUsuariosCursoSync(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCursoUsuarioRemovidoSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaCursoUsuarioRemovidoSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaCursoUsuarioRemovidoSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmasCarregar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmasCarregar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmasCarregar);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmaTratar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmaTratar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmaTratar);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCursoUsuarioRemovidoAlunosTratar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaCursoUsuarioRemovidoAlunosTratar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaCursoUsuarioRemovidoAlunosTratar);
            
            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCursoUsuarioRemovidoProfessoresTratar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaCursoUsuarioRemovidoProfessoresTratar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaCursoUsuarioRemovidoProfessoresTratar);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCursoUsuarioRemovidoFuncionarioTratar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaCursoUsuarioRemovidoFuncionarioTratar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaCursoUsuarioRemovidoFuncionarioTratar);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCursoUsuarioRemovidoErroTratar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaCursoUsuarioRemovidoErroTratar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaCursoUsuarioRemovidoErroTratar);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCursoUsuarioRemovidoProfessoresTratarErro, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaCursoUsuarioRemovidoProfessoresTratarErro, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaCursoUsuarioRemovidoProfessoresTratarErro);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCursoUsuarioRemovidoFuncionarioTratarErro, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaCursoUsuarioRemovidoFuncionarioTratarErro, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaCursoUsuarioRemovidoFuncionarioTratarErro);
            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoAhRemover, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoAhRemover, ExchangeRabbit.GoogleSync, RotasRabbit.FilaCursoAhRemover);
        }

        private static void RegistrarFilasInativarAlunosSync(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaInativarUsuarioIniciar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaInativarUsuarioIniciar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaInativarUsuarioIniciar);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaInativarUsuarioCarregar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaInativarUsuarioCarregar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaInativarUsuarioCarregar);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaInativarUsuarioSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaInativarUsuarioSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaInativarUsuarioSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaInativarUsuarioCarregar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaInativarUsuarioCarregar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaInativarUsuarioCarregar);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaInativarUsuarioIncluir, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaInativarUsuarioIncluir, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaInativarUsuarioIncluir);        
        }

        private static void RegistrarFilasInativarProfessoresEFuncionariosSync(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaInativarProfessoresEFuncionariosIniciar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaInativarProfessoresEFuncionariosIniciar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaInativarProfessoresEFuncionariosIniciar);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCarregarProfessoresEFuncionariosInativar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaCarregarProfessoresEFuncionariosInativar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaCarregarProfessoresEFuncionariosInativar);

            canalRabbit.QueueDeclare(RotasRabbit.FilaTratarProfessoresEFuncionariosInativar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaTratarProfessoresEFuncionariosInativar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaTratarProfessoresEFuncionariosInativar);

            canalRabbit.QueueDeclare(RotasRabbit.FilaInativarProfessoresEFuncionariosInativarSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaInativarProfessoresEFuncionariosInativarSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaInativarProfessoresEFuncionariosInativarSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaInativarProfessorSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaInativarProfessorSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaInativarProfessorSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaInativarProfessorErroTratar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaInativarProfessorErroTratar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaInativarProfessorErroTratar);
        }
        #endregion Filas Sync

        #region Filas de Inclusão/Atualização/Tratamento

        private static void RegistrarFilasDeInclusao(IModel canalRabbit)
        {
            RegistrarFilasCursoDeInclusao(canalRabbit);
            RegistrarFilasAlunoDeInclusao(canalRabbit);
            RegistrarFilasProfessorDeInclusao(canalRabbit);
            RegistrarFilasFuncionarioDeInclusao(canalRabbit);
            RegistrarFilasUsuarioAtualizar(canalRabbit);
        }

        private static void RegistrarFilasCursoDeInclusao(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoIncluir, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoIncluir, ExchangeRabbit.GoogleSync, RotasRabbit.FilaCursoIncluir);
        }

        private static void RegistrarFilasAlunoDeInclusao(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaAlunoIncluir, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaAlunoIncluir, ExchangeRabbit.GoogleSync, RotasRabbit.FilaAlunoIncluir);

            canalRabbit.QueueDeclare(RotasRabbit.FilaAlunoCursoIncluir, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaAlunoCursoIncluir, ExchangeRabbit.GoogleSync, RotasRabbit.FilaAlunoCursoIncluir);
        }

        private static void RegistrarFilasProfessorDeInclusao(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaProfessorIncluir, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaProfessorIncluir, ExchangeRabbit.GoogleSync, RotasRabbit.FilaProfessorIncluir);

            canalRabbit.QueueDeclare(RotasRabbit.FilaProfessorCursoIncluir, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaProfessorCursoIncluir, ExchangeRabbit.GoogleSync, RotasRabbit.FilaProfessorCursoIncluir);

            canalRabbit.QueueDeclare(RotasRabbit.FilaProfessorCursoRemover, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaProfessorCursoRemover, ExchangeRabbit.GoogleSync, RotasRabbit.FilaProfessorCursoRemover);
        }

        private static void RegistrarFilasFuncionarioDeInclusao(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaFuncionarioIncluir, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaFuncionarioIncluir, ExchangeRabbit.GoogleSync, RotasRabbit.FilaFuncionarioIncluir);

            canalRabbit.QueueDeclare(RotasRabbit.FilaFuncionarioCursoIncluir, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaFuncionarioCursoIncluir, ExchangeRabbit.GoogleSync, RotasRabbit.FilaFuncionarioCursoIncluir);

            canalRabbit.QueueDeclare(RotasRabbit.FilaFuncionarioIndiretoIncluir, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaFuncionarioIndiretoIncluir, ExchangeRabbit.GoogleSync, RotasRabbit.FilaFuncionarioIndiretoIncluir);
        }

        private static void RegistrarFilasUsuarioAtualizar(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaUsuarioGoogleIdAtualizar, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaUsuarioGoogleIdAtualizar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaUsuarioGoogleIdAtualizar);
        }

        #endregion Filas de Inclusão/Atualização/Tratamento

        #region Filas GSA

        private static void RegistrarFilasGsa(IModel canalRabbit, ConsumoDeFilasOptions consumoDeFilasOptions)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaGoogleSync, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaGoogleSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaGoogleSync);
            
            canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCargaInicial, true, false, false, argumentos);
            canalRabbit.QueueBind(RotasRabbit.FilaGsaCargaInicial, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaCargaInicial);

            RegistrarFilasDeCargasGsa(canalRabbit, consumoDeFilasOptions);
            RegistrarFilasDeProcessamentoGsa(canalRabbit, consumoDeFilasOptions);
        }

        private static void RegistrarFilasDeCargasGsa(IModel canalRabbit, ConsumoDeFilasOptions consumoDeFilasOptions)
        {
            if (consumoDeFilasOptions.Gsa.CargaMuralAvisosGsa)
            {
                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaMuralAvisosCarregar, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaMuralAvisosCarregar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaMuralAvisosCarregar);

                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaMuralAvisosTratar, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaMuralAvisosTratar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaMuralAvisosTratar);

                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaMuralAvisosIncluir, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaMuralAvisosIncluir, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaMuralAvisosIncluir);

                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaMuralAvisosIncluirErro, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaMuralAvisosIncluirErro, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaMuralAvisosIncluirErro);
            }

            if (consumoDeFilasOptions.Gsa.CargaAtividadesGsa)
            {
                // Atividades
                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaAtividadesCarregar, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaAtividadesCarregar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaAtividadesCarregar);

                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaAtividadesTratar, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaAtividadesTratar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaAtividadesTratar);

                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaAtividadesIncluir, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaAtividadesIncluir, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaAtividadesIncluir);

                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaAtividadesIncluirErro, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaAtividadesIncluirErro, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaAtividadesIncluirErro);

                // Notas
                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaNotasAtividadesCarregar, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaNotasAtividadesCarregar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaNotasAtividadesCarregar);

                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaNotasAtividadesSync, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaNotasAtividadesSync, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaNotasAtividadesSync);

                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaNotasAtividadesTratar, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaNotasAtividadesTratar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaNotasAtividadesTratar);

                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaNotasAtividadesSyncErro, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaNotasAtividadesSyncErro, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaNotasAtividadesSyncErro);
            }

            if (consumoDeFilasOptions.Gsa.CargaCursoGsa)
            {
                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCursoCarregar, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaCursoCarregar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaCursoCarregar);
            }

            if (consumoDeFilasOptions.Gsa.CargaUsuarioGsa)
            {
                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaUsuarioCarregar, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaUsuarioCarregar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaUsuarioCarregar);

                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaUsuarioCarregarErro, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaUsuarioCarregarErro, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaUsuarioCarregarErro);
            }

            if (consumoDeFilasOptions.Gsa.CargaCursoUsuarioGsa)
            {
                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCursoUsuarioCarregar, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaCursoUsuarioCarregar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaCursoUsuarioCarregar);
            } 
            
        }

        private static void RegistrarFilasDeProcessamentoGsa(IModel canalRabbit, ConsumoDeFilasOptions consumoDeFilasOptions)
        {
            if (consumoDeFilasOptions.Gsa.ProcessarCursoGsa)
            {
                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCursoIncluir, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaCursoIncluir, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaCursoIncluir);

                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCursoValidar, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaCursoValidar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaCursoValidar);
            }

            if (consumoDeFilasOptions.Gsa.ProcessarUsuarioGsa)
            {
                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaUsuarioIncluir, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaUsuarioIncluir, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaUsuarioIncluir);

                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaUsuarioIncluirErro, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaUsuarioIncluirErro, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaUsuarioIncluirErro);

                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaUsuarioValidar, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaUsuarioValidar, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaUsuarioValidar);
            }

            if (consumoDeFilasOptions.Gsa.ProcessarCursoUsuarioGsa)
            {
                canalRabbit.QueueDeclare(RotasRabbit.FilaGsaCursoUsuarioIncluir, true, false, false, argumentos);
                canalRabbit.QueueBind(RotasRabbit.FilaGsaCursoUsuarioIncluir, ExchangeRabbit.GoogleSync, RotasRabbit.FilaGsaCursoUsuarioIncluir);
            }
        }

        #endregion Filas GSA
    }
}