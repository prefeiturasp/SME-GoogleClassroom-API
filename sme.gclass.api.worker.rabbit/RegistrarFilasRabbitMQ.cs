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
        }

        #region Filas Sync

        private static void RegistrarFilasSync(IModel canalRabbit)
        {
            canalRabbit.QueueDeclare(RotasRabbit.FilaGoogleSync, true, false, false);
            canalRabbit.QueueBind(RotasRabbit.FilaGoogleSync, RotasRabbit.ExchangeGoogleSync, RotasRabbit.FilaGoogleSync);

            RegistrarFilasCursoSync(canalRabbit);
            RegistrarFilasAlunoSync(canalRabbit);
            RegistrarFilasProfessorSync(canalRabbit);
            RegistrarFilasFuncionarioSync(canalRabbit);
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
        }

        #endregion Filas Sync

        #region Filas de Inclusão/Tratamento

        private static void RegistrarFilasDeInclusao(IModel canalRabbit)
        {
            RegistrarFilasCursoDeInclusao(canalRabbit);
            RegistrarFilasAlunoDeInclusao(canalRabbit);
            RegistrarFilasProfessorDeInclusao(canalRabbit);
            RegistrarFilasFuncionarioDeInclusao(canalRabbit);
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

        #endregion Filas de Inclusão
    }
}