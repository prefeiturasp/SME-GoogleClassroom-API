﻿using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Constantes;
using SME.GoogleClassroom.Infra.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizacaoGsaFormacaoCidadeTurmaCursoUseCase : ISincronizacaoGsaFormacaoCidadeTurmaCursoUseCase
    {
        private readonly IMediator mediator;

        public SincronizacaoGsaFormacaoCidadeTurmaCursoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var filtro = JsonConvert.DeserializeObject<FiltroFormacaoCidadeTurmaCursoDto>(mensagemRabbit.Mensagem.ToString());

            try
            {
                var funcionarios = await ObterAlunos(filtro);

                if (funcionarios.Count() > ConstanteFormacaoCidade.QTDE_MAXIMA_ALUNOS_POR_CURSO)
                {
                    int qtdePorPacote, qtdePorPacoteFinal;
                    CalcularQuantidadePorPacote(funcionarios, out qtdePorPacote, out qtdePorPacoteFinal);

                    for (int i = 0; i < qtdePorPacote; i++)
                    {
                        var nomeSala = i == 0 ? filtro.SalaVirtual : $"{filtro.SalaVirtual}_{i}";

                        await InserirCursoAssociarAluno(nomeSala, filtro.CodigoDre, funcionarios.Skip(i * qtdePorPacoteFinal).Take(qtdePorPacoteFinal).ToList());
                    }
                }
                else
                    await InserirCursoAssociarAluno(filtro.SalaVirtual, filtro.CodigoDre, funcionarios);
            }
            catch (Exception)
            {
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCursoErro, filtro));
            }

            return true;
        }

        private async Task<IEnumerable<string>> ObterAlunos(FiltroFormacaoCidadeTurmaCursoDto filtro)
        {
            var funcionarios = Enumerable.Empty<string>();

            switch ((TipoConsultaFormacaoCidade)filtro.TipoConsultaProfessor)
            {
                case TipoConsultaFormacaoCidade.ComponenteCurricular:
                    funcionarios = await mediator.Send(new ObterProfessoresPorDreComponenteCurricularModalidadeQuery(filtro.CodigoDre, filtro.ComponentesCurricularesIds, filtro.ModalidadesIds, filtro.TipoEscola, filtro.AnoLetivo, filtro.AnoTurma));
                    break;
                case TipoConsultaFormacaoCidade.CP:
                    funcionarios = await mediator.Send(new ObterCoordenadoresPedagogicosPorTipoEscolaAnoQuery(filtro.CodigoDre, filtro.TipoEscola, filtro.AnoLetivo));
                    break;
                case TipoConsultaFormacaoCidade.PAP:
                    funcionarios = await mediator.Send(new ObterProfessoresPAPPAEEorTipoEscolaAnoQuery(filtro.CodigoDre, filtro.TipoEscola, (int)TipoConsultaFormacaoCidade.PAP));
                    break;
                case TipoConsultaFormacaoCidade.PAEE:
                    funcionarios = await mediator.Send(new ObterProfessoresPAPPAEEorTipoEscolaAnoQuery(filtro.CodigoDre, filtro.TipoEscola, (int)TipoConsultaFormacaoCidade.PAEE));
                    break;
                default:
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCursoErro, filtro));
                    break;
            }

            return funcionarios;
        }

        private async Task InserirCursoAssociarAluno(string salaVirtual, string codigoDre, IEnumerable<string> funcionarios)
        {
            var cursoGsa = await mediator.Send(new ObterCursoGsaPorNomeQuery(salaVirtual));
            if (cursoGsa == null)
            {
                var inserirCursoGsa = new CursoGsa(long.Parse(codigoDre), salaVirtual, ConstanteFormacaoCidade.PREFIXO_SALA_VIRTUAL, ConstanteFormacaoCidade.CRIADOR, ConstanteFormacaoCidade.DESCRICAO, true, DateTime.Now);
                var retorno = await mediator.Send(new InserirCursoGsaCommand(inserirCursoGsa));
            }

            var cursoGoogle = new CursoGoogle(salaVirtual, ConstanteFormacaoCidade.PREFIXO_SALA_VIRTUAL, ConstanteFormacaoCidade.EMAIL_DONO_CURSO);
            var cursoId = await mediator.Send(new ExisteCursoPorNomeQuery(cursoGoogle.Nome));
            if (cursoId == 0)
                await mediator.Send(new InserirCursoGoogleCommand(cursoGoogle));

            foreach (var funcionario in funcionarios)
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCurso, new AlunoCursoEol(long.Parse(funcionario), cursoId)));
        }

        private static void CalcularQuantidadePorPacote(IEnumerable<string> funcionarios, out int qtdePorPacote, out int qtdePorPacoteFinal)
        {
            int qtdePorPacoteGlobal = funcionarios.Count() / ConstanteFormacaoCidade.QTDE_MAXIMA_ALUNOS_POR_CURSO;
            int qtdeExtraGlobal = funcionarios.Count() % ConstanteFormacaoCidade.QTDE_MAXIMA_ALUNOS_POR_CURSO;
            qtdePorPacote = qtdeExtraGlobal > 0 ? qtdePorPacoteGlobal + 1 : qtdePorPacoteGlobal;
            
            //Distribui os alunos da melhor forma possível
            var qtdePorPacoteRemanescente = funcionarios.Count() / qtdePorPacote;
            int qtdeExtraRemanescente = funcionarios.Count() % qtdePorPacote;
            qtdePorPacoteFinal = qtdeExtraRemanescente > 0 ? qtdePorPacoteRemanescente + 1 : qtdePorPacoteRemanescente;
        }
    }
}
