using RabbitMQ.Client;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Worker.Rabbit
{
    public static class RegistrarFilasRabbitMQ
    {
        public static void RegistrarFilas(IModel canalRabbit, ConsumoDeFilasOptions consumoDeFilasOptions)
        {
            if (consumoDeFilasOptions.ConsumirFilasSync)
                RegistrarFilasSync(canalRabbit);

            if (consumoDeFilasOptions.ConsumirFilasDeInclusao)
                RegistrarFilasDeInclusao(canalRabbit);

            if (consumoDeFilasOptions.ConsumirFilasDeCarga)
                RegistrarFilasDeCargas(canalRabbit);
        }

        #region Filas Sync

        private static void RegistrarFilasSync(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaGoogleSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaGoogleSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaGoogleSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaComparativoGoogleSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaComparativoGoogleSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaComparativoGoogleSync);

            RegistrarFilasCursoSync(canalRabbit);
            RegistrarFilasAlunoSync(canalRabbit);
            RegistrarFilasProfessorSync(canalRabbit);
            RegistrarFilasFuncionarioSync(canalRabbit);
            RegistrarFilasUsuarioSync(canalRabbit);
        }

        private static void RegistrarFilasCursoSync(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaCursoSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoProfessorSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoProfessorSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaCursoProfessorSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoAlunoSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoAlunoSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaCursoAlunoSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoGradeSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoGradeSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaCursoGradeSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoFuncionarioSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoFuncionarioSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaCursoFuncionarioSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoErroSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoErroSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaCursoErroSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoErroTratar, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoErroTratar, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaCursoErroTratar);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoCarregar, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoCarregar, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaCursoCarregar);

            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoComparativoAtualizar, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoComparativoAtualizar, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaCursoComparativoAtualizar);
        }

        private static void RegistrarFilasAlunoSync(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaAlunoSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaAlunoSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaAlunoSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaAlunoCursoSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaAlunoCursoSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaAlunoCursoSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaAlunoErroSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaAlunoErroSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaAlunoErroSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaAlunoErroTratar, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaAlunoErroTratar, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaAlunoErroTratar);
        }

        private static void RegistrarFilasProfessorSync(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaProfessorSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaProfessorSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaProfessorSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaProfessorCursoSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaProfessorCursoSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaProfessorCursoSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaProfessorCursoAtribuicaoSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaProfessorCursoAtribuicaoSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaProfessorCursoAtribuicaoSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaProfessorErroSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaProfessorErroSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaProfessorErroSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaProfessorErroTratar, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaProfessorErroTratar, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaProfessorErroTratar);
        }

        private static void RegistrarFilasFuncionarioSync(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaFuncionarioSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaFuncionarioSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaFuncionarioSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaFuncionarioCursoSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaFuncionarioCursoSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaFuncionarioCursoSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaFuncionarioIndiretoSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaFuncionarioIndiretoSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaFuncionarioIndiretoSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaFuncionarioErroSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaFuncionarioErroSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaFuncionarioErroSync);

            canalRabbit.QueueDeclare(RotasRabbit.FilaFuncionarioErroTratar, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaFuncionarioErroTratar, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaFuncionarioErroTratar);
        }


        private static void RegistrarFilasComparativoCursosSync(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoComparativoAtualizar, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoComparativoAtualizar, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaCursoComparativoAtualizar);
        }

        private static void RegistrarFilasUsuarioSync(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaUsuarioGoogleIdSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaUsuarioGoogleIdSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaUsuarioGoogleIdSync);
        }

        #endregion Filas Sync

        #region Filas de Inclusão/Atualização/Tratamento

        private static void RegistrarFilasDeInclusao(IModel canalRabbit)
        {
            RegistrarFilasCursoDeInclusao(canalRabbit);
            RegistrarFilasAlunoDeInclusao(canalRabbit);
            RegistrarFilasProfessorDeInclusao(canalRabbit);
            RegistrarFilasFuncionarioDeInclusao(canalRabbit);
            RegistrarFilasComparativoCursosSync(canalRabbit);
            RegistrarFilasUsuarioAtualizar(canalRabbit);
        }

        private static void RegistrarFilasCursoDeInclusao(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaCursoIncluir, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaCursoIncluir, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaCursoIncluir);            
        }

        private static void RegistrarFilasAlunoDeInclusao(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaAlunoIncluir, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaAlunoIncluir, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaAlunoIncluir);

            canalRabbit.QueueDeclare(RotasRabbit.FilaAlunoCursoIncluir, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaAlunoCursoIncluir, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaAlunoCursoIncluir);
        }

        private static void RegistrarFilasProfessorDeInclusao(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaProfessorIncluir, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaProfessorIncluir, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaProfessorIncluir);

            canalRabbit.QueueDeclare(RotasRabbit.FilaProfessorCursoIncluir, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaProfessorCursoIncluir, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaProfessorCursoIncluir);

            canalRabbit.QueueDeclare(RotasRabbit.FilaProfessorCursoRemover, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaProfessorCursoRemover, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaProfessorCursoRemover);
        }

        private static void RegistrarFilasFuncionarioDeInclusao(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaFuncionarioIncluir, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaFuncionarioIncluir, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaFuncionarioIncluir);

            canalRabbit.QueueDeclare(RotasRabbit.FilaFuncionarioCursoIncluir, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaFuncionarioCursoIncluir, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaFuncionarioCursoIncluir);

            canalRabbit.QueueDeclare(RotasRabbit.FilaFuncionarioIndiretoIncluir, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaFuncionarioIndiretoIncluir, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaFuncionarioIndiretoIncluir);
        }

        private static void RegistrarFilasUsuarioAtualizar(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaUsuarioGoogleIdAtualizar, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaUsuarioGoogleIdAtualizar, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaUsuarioGoogleIdAtualizar);
        }

        #endregion Filas de Inclusão

        #region Filas Cargas
        private static void RegistrarFilasDeCargas(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaUsuariosCarregar, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaUsuariosCarregar, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaUsuariosCarregar);
        }
        #endregion
    }
}