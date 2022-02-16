using Google;
using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizacaoGsaFormacaoCidadeTurmaAlunoUseCase : ISincronizacaoGsaFormacaoCidadeTurmaAlunoUseCase
    {
        private readonly IMediator mediator;

        public SincronizacaoGsaFormacaoCidadeTurmaAlunoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var filtro = JsonConvert.DeserializeObject<AlunoCursoEol>(mensagemRabbit.Mensagem.ToString());

            try
            {
                var aluno = await mediator.Send(new ObterAlunosPorCodigosQuery(filtro.CodigoAluno));
                if (aluno is null || !aluno.Any()) return false;

                var alunoFirst = aluno.FirstOrDefault();
                var alunoCursoGoogle = new AlunoCursoGoogle(alunoFirst.Indice, filtro.CursoId);

                //TODO: Precisa validar se tem professor 'ExisteAlunoCursoGoogleQuery' como em 'InserirAlunoCursoGoogleUseCase' ?
                await InserirAlunoCursoGoogleAsync(alunoCursoGoogle, alunoFirst.Email);
            }
            catch (Exception)
            {
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAlunoErro, filtro));
            }

            return true;
        }

        private async Task InserirAlunoCursoGoogleAsync(AlunoCursoGoogle alunoCursoGoogle, string email)
        {
            try
            {
                var professorCursoSincronizado = await mediator.Send(new InserirAlunoCursoGoogleCommand(alunoCursoGoogle, email));
                if (professorCursoSincronizado)
                {
                    await InserirAlunoCursoAsync(alunoCursoGoogle);
                }
            }
            catch (GoogleApiException gEx)
            {
                if (gEx.EhErroDeDuplicidade())
                    await InserirAlunoCursoAsync(alunoCursoGoogle);
                else
                    throw;
            }
        }

        private async Task InserirAlunoCursoAsync(AlunoCursoGoogle alunoCursoGoogle)
        {
            alunoCursoGoogle.Id = await mediator.Send(new IncluirCursoUsuarioCommand(alunoCursoGoogle.UsuarioId, alunoCursoGoogle.CursoId));
        }
    }
}
