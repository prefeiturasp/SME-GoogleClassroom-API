using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarCursoErrosTratamentoUseCase : IIniciarCursoErrosTratamentoUseCase
    {
        private readonly IMediator mediator;

        public IniciarCursoErrosTratamentoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var CursoParaIncluir = JsonConvert.DeserializeObject<CursoErro>(mensagemRabbit.Mensagem.ToString());
            if (CursoParaIncluir is null) return true;

            try
            {
                //TODO :  Verificar turma ativa
                var turmaAtiva = await mediator.Send(new ExisteTurmaAtivaPorIdQuery(CursoParaIncluir.TurmaId));

                //TODO : Buscar o curso no eol por turmaId
                    // se a turma tiver ativa 
                        // verificar se tem email
                            // sim : publica na fila cursos.incluir
                            // não : inserir na tabela de erro
            }
            catch (Exception ex)
            {
                await mediator.Send(new InserirCursoErroCommand(CursoParaIncluir.TurmaId, CursoParaIncluir.ComponenteCurricularId, $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit.Mensagem}", null, ExecucaoTipo.CursoAdicionar, ErroTipo.Interno));
            }

            return true;
        }
    }
}