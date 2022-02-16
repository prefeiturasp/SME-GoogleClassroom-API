using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Constantes;
using SME.GoogleClassroom.Infra.Enumeradores;
using System;
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
                var funcionarios = Enumerable.Empty<string>();

                funcionarios = (TipoConsultaFormacaoCidade)filtro.TipoConsultaProfessor switch
                {
                    TipoConsultaFormacaoCidade.ComponenteCurricular => await mediator.Send(new ObterProfessoresPorDreComponenteCurricularModalidadeQuery(filtro.CodigoDre, filtro.ComponentesCurricularesIds, filtro.ModalidadesIds, filtro.TipoEscola, filtro.AnoLetivo, filtro.AnoTurma)),
                    TipoConsultaFormacaoCidade.CP => await mediator.Send(new ObterCoordenadoresPedagogicosPorTipoEscolaAnoQuery(filtro.CodigoDre, filtro.TipoEscola, filtro.AnoLetivo)),
                    TipoConsultaFormacaoCidade.PAP => await mediator.Send(new ObterProfessoresPAPPAEEorTipoEscolaAnoQuery(filtro.CodigoDre, filtro.TipoEscola, (int)TipoConsultaFormacaoCidade.PAP)),
                    TipoConsultaFormacaoCidade.PAEE => await mediator.Send(new ObterProfessoresPAPPAEEorTipoEscolaAnoQuery(filtro.CodigoDre, filtro.TipoEscola, (int)TipoConsultaFormacaoCidade.PAEE)),
                    _ => throw new Exception("Tipo de consulta formação cidade inválida."),
                };
                                
                var cursoGsa = await mediator.Send(new ObterCursoGsaPorNomeQuery(filtro.SalaVirtual));
                if (cursoGsa == null)
                {
                    var inserirCursoGsa = new CursoGsa(long.Parse(filtro.CodigoDre), filtro.SalaVirtual, ConstanteFormacaoCidade.PREFIXO_SALA_VIRTUAL, ConstanteFormacaoCidade.CRIADOR, ConstanteFormacaoCidade.DESCRICAO, true, DateTime.Now);
                    var retorno = await mediator.Send(new InserirCursoGsaCommand(inserirCursoGsa));
                }

                var cursoGoogle = new CursoGoogle(filtro.SalaVirtual, ConstanteFormacaoCidade.PREFIXO_SALA_VIRTUAL, ConstanteFormacaoCidade.EMAIL_DONO_CURSO);
                var cursoId = await mediator.Send(new ExisteCursoPorNomeQuery(cursoGoogle.Nome));
                if (cursoId == 0)
                    await mediator.Send(new InserirCursoGoogleCommand(cursoGoogle));

                foreach (var funcionario in funcionarios)
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCurso, new AlunoCursoEol(long.Parse(funcionario),cursoId)));
            }
            catch (Exception)
            {
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCursoErro, filtro));
            }

            return true;
        }
    }
}
