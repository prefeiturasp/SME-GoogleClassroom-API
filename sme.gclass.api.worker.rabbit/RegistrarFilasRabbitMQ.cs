using RabbitMQ.Client;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit
{
    public static class RegistrarFilasRabbitMQ
    {
        private static IDictionary<string, object> argumentos;

        public static async Task RegistrarFilas(IChannel canalRabbit, ConsumoDeFilasOptions consumoDeFilasOptions)
        {
            argumentos = new Dictionary<string, object>
            {
                { "x-queue-mode", "lazy" }
            };

            if (consumoDeFilasOptions == null)
                return;

            if (consumoDeFilasOptions.ConsumirFilasSync)
                await RegistrarFilasSync(canalRabbit);

            if (consumoDeFilasOptions.ConsumirFilasDeInclusao)
                await RegistrarFilasDeInclusao(canalRabbit);

            await RegistrarFilasGsa(canalRabbit, consumoDeFilasOptions);
        }

        private static async Task DeclararEVincularFilas(IChannel canalRabbit, params string[] filas)
        {
            if (filas == null) return;

            foreach (var fila in filas)
            {
                if (string.IsNullOrWhiteSpace(fila)) continue;

                await canalRabbit.QueueDeclareAsync(fila, true, false, false, argumentos);
                await canalRabbit.QueueBindAsync(fila, ExchangeRabbit.GoogleSync, fila);
            }
        }

        #region Filas Sync

        private static async Task RegistrarFilasSync(IChannel canalRabbit)
        {
            await DeclararEVincularFilas(canalRabbit, RotasRabbit.FilaGoogleSync);

            await RegistrarFilasCursoSync(canalRabbit);
            await RegistrarFilasAlunoSync(canalRabbit);
            await RegistrarFilasProfessorSync(canalRabbit);
            await RegistrarFilasFuncionarioSync(canalRabbit);
            await RegistrarFilasUsuarioSync(canalRabbit);
            await RegistrarFilasRemoverUsuariosCursoSync(canalRabbit);
            await RegistrarFilasInativarAlunosSync(canalRabbit);
            await RegistrarFilasInativarProfessoresEFuncionariosSync(canalRabbit);
            await RegistrarFilasFormacaoCidadeSync(canalRabbit);
            await RegistrarFilasCelpSync(canalRabbit);
        }

        private static async Task RegistrarFilasCelpSync(IChannel canalRabbit)
        {
            await DeclararEVincularFilas(canalRabbit,
                RotasRabbit.FilaGsaCursosCelpSync,
                RotasRabbit.FilaGsaCursoCelpIncluir,
                RotasRabbit.FilaGsaCursosAlunosCelpSync,
                RotasRabbit.FilaGsaFuncionarioCursoCelpIncluir,
                RotasRabbit.FilaGsaAlunoCelpIncluir,
                RotasRabbit.FilaGsaCursoAlunoCelpIncluir,
                RotasRabbit.FilaGsaCursoUsuarioRemovidoAlunosCelpTratar);
        }

        private static async Task RegistrarFilasFormacaoCidadeSync(IChannel canalRabbit)
        {
            await DeclararEVincularFilas(canalRabbit,
                RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarSmeDre,
                RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarSmeDreErro,
                RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarComponente,
                RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarComponenteErro,
                RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCurso,
                RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCursoErro,
                RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAluno,
                RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAlunoErro);
        }

        private static async Task RegistrarFilasCursoSync(IChannel canalRabbit)
        {
            await DeclararEVincularFilas(canalRabbit,
                RotasRabbit.FilaCursoSync,
                RotasRabbit.FilaCursoProfessorSync,
                RotasRabbit.FilaCursoAlunoSync,
                RotasRabbit.FilaCursoGradeSync,
                RotasRabbit.FilaCursoFuncionarioSync,
                RotasRabbit.FilaCursoErroSync,
                RotasRabbit.FilaCursoErroTratar,
                RotasRabbit.FilaCursoExtintoArquivarCarregar,
                RotasRabbit.FilaCursoArquivarTratar,
                RotasRabbit.FilaCursoArquivarTratarErro,
                RotasRabbit.FilaCursoArquivarSync,
                RotasRabbit.FilaCursoArquivarSyncErro,
                RotasRabbit.FilaCursoArquivarAnoAnteriorCarregar,
                RotasRabbit.FilaCursoArquivarCarregar);
        }

        private static async Task RegistrarFilasAlunoSync(IChannel canalRabbit)
        {
            await DeclararEVincularFilas(canalRabbit,
                RotasRabbit.FilaAlunoSync,
                RotasRabbit.FilaAlunoCursoSync,
                RotasRabbit.FilaAlunoErroSync,
                RotasRabbit.FilaAlunoErroTratar);
        }

        private static async Task RegistrarFilasProfessorSync(IChannel canalRabbit)
        {
            await DeclararEVincularFilas(canalRabbit,
                RotasRabbit.FilaProfessorSync,
                RotasRabbit.FilaProfessorCursoSync,
                RotasRabbit.FilaProfessorCursoAtribuicaoSync,
                RotasRabbit.FilaProfessorErroSync,
                RotasRabbit.FilaProfessorErroTratar);
        }

        private static async Task RegistrarFilasFuncionarioSync(IChannel canalRabbit)
        {
            await DeclararEVincularFilas(canalRabbit,
                RotasRabbit.FilaFuncionarioSync,
                RotasRabbit.FilaFuncionarioCursoSync,
                RotasRabbit.FilaFuncionarioIndiretoSync,
                RotasRabbit.FilaFuncionarioErroSync,
                RotasRabbit.FilaFuncionarioErroTratar);
        }

        private static async Task RegistrarFilasUsuarioSync(IChannel canalRabbit)
        {
            await DeclararEVincularFilas(canalRabbit, RotasRabbit.FilaUsuarioGoogleIdSync);
        }

        private static async Task RegistrarFilasRemoverUsuariosCursoSync(IChannel canalRabbit)
        {
            await DeclararEVincularFilas(canalRabbit,
                RotasRabbit.FilaGsaCursoUsuarioRemovidoSync,
                RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmasCarregar,
                RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmaTratar,
                RotasRabbit.FilaGsaCursoUsuarioRemovidoAlunosTratar,
                RotasRabbit.FilaGsaCursoUsuarioRemovidoProfessoresTratar,
                RotasRabbit.FilaGsaCursoUsuarioRemovidoFuncionarioTratar,
                RotasRabbit.FilaGsaCursoUsuarioRemovidoErroTratar,
                RotasRabbit.FilaGsaCursoUsuarioRemovidoProfessoresTratarErro,
                RotasRabbit.FilaGsaCursoUsuarioRemovidoFuncionarioTratarErro,
                RotasRabbit.FilaCursoAhRemover);
        }

        private static async Task RegistrarFilasInativarAlunosSync(IChannel canalRabbit)
        {
            await DeclararEVincularFilas(canalRabbit,
                RotasRabbit.FilaGsaInativarUsuarioIniciar,
                RotasRabbit.FilaGsaInativarUsuarioCarregar,
                RotasRabbit.FilaGsaInativarUsuarioSync,
                RotasRabbit.FilaGsaInativarUsuarioCarregar,
                RotasRabbit.FilaGsaInativarUsuarioIncluir);
        }

        private static async Task RegistrarFilasInativarProfessoresEFuncionariosSync(IChannel canalRabbit)
        {
            await DeclararEVincularFilas(canalRabbit,
                RotasRabbit.FilaInativarProfessoresEFuncionariosIniciar,
                RotasRabbit.FilaCarregarProfessoresEFuncionariosInativar,
                RotasRabbit.FilaTratarProfessoresEFuncionariosInativar,
                RotasRabbit.FilaInativarProfessoresEFuncionariosInativarSync,
                RotasRabbit.FilaGsaInativarProfessorSync,
                RotasRabbit.FilaInativarProfessorErroTratar);
        }

        #endregion Filas Sync

        #region Filas de Inclusão/Atualização/Tratamento

        private static async Task RegistrarFilasDeInclusao(IChannel canalRabbit)
        {
            await RegistrarFilasCursoDeInclusao(canalRabbit);
            await RegistrarFilasAlunoDeInclusao(canalRabbit);
            await RegistrarFilasProfessorDeInclusao(canalRabbit);
            await RegistrarFilasFuncionarioDeInclusao(canalRabbit);
            await RegistrarFilasUsuarioAtualizar(canalRabbit);
        }

        private static async Task RegistrarFilasCursoDeInclusao(IChannel canalRabbit)
        {
            await DeclararEVincularFilas(canalRabbit, RotasRabbit.FilaCursoIncluir);
        }

        private static async Task RegistrarFilasAlunoDeInclusao(IChannel canalRabbit)
        {
            await DeclararEVincularFilas(canalRabbit,
                RotasRabbit.FilaAlunoIncluir,
                RotasRabbit.FilaAlunoCursoIncluir);
        }

        private static async Task RegistrarFilasProfessorDeInclusao(IChannel canalRabbit)
        {
            await DeclararEVincularFilas(canalRabbit,
                RotasRabbit.FilaProfessorIncluir,
                RotasRabbit.FilaProfessorCursoIncluir,
                RotasRabbit.FilaProfessorCursoRemover);
        }

        private static async Task RegistrarFilasFuncionarioDeInclusao(IChannel canalRabbit)
        {
            await DeclararEVincularFilas(canalRabbit,
                RotasRabbit.FilaFuncionarioIncluir,
                RotasRabbit.FilaFuncionarioCursoIncluir,
                RotasRabbit.FilaFuncionarioIndiretoIncluir);
        }

        private static async Task RegistrarFilasUsuarioAtualizar(IChannel canalRabbit)
        {
            await DeclararEVincularFilas(canalRabbit, RotasRabbit.FilaUsuarioGoogleIdAtualizar);
        }

        #endregion Filas de Inclusão/Atualização/Tratamento

        #region Filas GSA

        private static async Task RegistrarFilasGsa(IChannel canalRabbit, ConsumoDeFilasOptions consumoDeFilasOptions)
        {
            await DeclararEVincularFilas(canalRabbit,
                RotasRabbit.FilaGsaGoogleSync,
                RotasRabbit.FilaGsaCargaInicial,
                RotasRabbit.FilaGsaAtividadesIncluir,
                RotasRabbit.FilaGsaAtividadesIncluirErro);

            await RegistrarFilasDeCargasGsa(canalRabbit, consumoDeFilasOptions);
            await RegistrarFilasDeProcessamentoGsa(canalRabbit, consumoDeFilasOptions);
        }

        private static async Task RegistrarFilasDeCargasGsa(IChannel canalRabbit, ConsumoDeFilasOptions consumoDeFilasOptions)
        {
            if (consumoDeFilasOptions?.Gsa?.CargaMuralAvisosGsa == true)
            {
                await DeclararEVincularFilas(canalRabbit,
                    RotasRabbit.FilaGsaMuralAvisosCarregar,
                    RotasRabbit.FilaGsaMuralAvisosTratar,
                    RotasRabbit.FilaGsaMuralAvisosIncluir,
                    RotasRabbit.FilaGsaMuralAvisosIncluirErro);
            }

            if (consumoDeFilasOptions?.Gsa?.CargaAtividadesGsa == true)
            {
                await DeclararEVincularFilas(canalRabbit,
                    RotasRabbit.FilaGsaAtividadesCarregar,
                    RotasRabbit.FilaGsaAtividadesTratar,
                    RotasRabbit.FilaGsaAtividadesIncluir,
                    RotasRabbit.FilaGsaAtividadesIncluirErro);

                await DeclararEVincularFilas(canalRabbit,
                    RotasRabbit.FilaGsaNotasAtividadesCarregar,
                    RotasRabbit.FilaGsaNotasAtividadesSync,
                    RotasRabbit.FilaGsaNotasAtividadesTratar,
                    RotasRabbit.FilaGsaNotasAtividadesSyncErro);
            }

            if (consumoDeFilasOptions?.Gsa?.CargaCursoGsa == true)
            {
                await DeclararEVincularFilas(canalRabbit, RotasRabbit.FilaGsaCursoCarregar);
            }

            if (consumoDeFilasOptions?.Gsa?.CargaUsuarioGsa == true)
            {
                await DeclararEVincularFilas(canalRabbit,
                    RotasRabbit.FilaGsaUsuarioCarregar,
                    RotasRabbit.FilaGsaUsuarioCarregarErro);
            }

            if (consumoDeFilasOptions?.Gsa?.CargaCursoUsuarioGsa == true)
            {
                await DeclararEVincularFilas(canalRabbit, RotasRabbit.FilaGsaCursoUsuarioCarregar);
            }
        }

        private static async Task RegistrarFilasDeProcessamentoGsa(IChannel canalRabbit, ConsumoDeFilasOptions consumoDeFilasOptions)
        {
            if (consumoDeFilasOptions?.Gsa?.ProcessarCursoGsa == true)
            {
                await DeclararEVincularFilas(canalRabbit,
                    RotasRabbit.FilaGsaCursoIncluir,
                    RotasRabbit.FilaGsaCursoValidar);
            }

            if (consumoDeFilasOptions?.Gsa?.ProcessarUsuarioGsa == true)
            {
                await DeclararEVincularFilas(canalRabbit,
                    RotasRabbit.FilaGsaUsuarioIncluir,
                    RotasRabbit.FilaGsaUsuarioIncluirErro,
                    RotasRabbit.FilaGsaUsuarioValidar);
            }

            if (consumoDeFilasOptions?.Gsa?.ProcessarCursoUsuarioGsa == true)
            {
                await DeclararEVincularFilas(canalRabbit, RotasRabbit.FilaGsaCursoUsuarioIncluir);
            }
        }

        #endregion Filas GSA
    }
}