using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirCursoGoogleUseCase : IIncluirCursoUseCase
    {
        private readonly IMediator mediator;

        public InserirCursoGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            //TODO: Remover qnd for para produção

            //try
            //{
            //    var cursoParaIncluir = JsonConvert.DeserializeObject<CursoParaInclusaoDto>(mensagemRabbit.Mensagem.ToString());

            //    if (cursoParaIncluir != null)
            //    {
            //        var existeCurso = await mediator.Send(new ExisteCursoPorTurmaComponenteCurricularQuery(cursoParaIncluir.TurmaId, cursoParaIncluir.ComponenteCurricularId));

            //        if (!existeCurso)
            //        {
            //            if (string.IsNullOrEmpty(cursoParaIncluir.Email))
            //                await mediator.Send(new InserirCursoErroCommand(cursoParaIncluir.TurmaId, cursoParaIncluir.ComponenteCurricularId, string.Empty, null, Dominio.ExecucaoTipo.CursoAdicionar, Dominio.ErroTipo.CursoSemEmail));
            //            else await mediator.Send(new InserirCursoGoogleCommand(cursoParaIncluir));
            //        }
            //    }

            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    await mediator.Send(new InserirCursoErroCommand(0, 0, $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit}", null, Dominio.ExecucaoTipo.CursoAdicionar, Dominio.ErroTipo.Interno));
            //    throw;
            //}
            
            return default;
        }
    }
}
