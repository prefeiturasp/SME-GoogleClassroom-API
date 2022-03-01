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
                var aluno = await mediator.Send(new ObterUsuariosPorCodigosQuery(filtro.CodigoAluno));
                if (aluno is null || !aluno.Any())
                {
                    var usuarioGoogle = await mediator.Send(new ObterUsuariosGooglePorCodigosQuery(filtro.CodigoAluno));
                    var alunoGoogle = new AlunoGoogle(int.Parse(usuarioGoogle.Id), usuarioGoogle.Nome, usuarioGoogle.Email, usuarioGoogle.OrganizationPath);

                    var incluiuAlunoGoogle = await mediator.Send(new InserirAlunoGoogleCommand(alunoGoogle));
                    if (!incluiuAlunoGoogle)
                    {
                        alunoGoogle.MensagemErro = $"O aluno (usuario) '{filtro.CodigoAluno}' não foi possível incluir o aluno no Google Classroom.";
                        await mediator.Send(new SalvarLogViaRabbitCommand($"{RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAluno} - {alunoGoogle.MensagemErro}", LogNivel.Critico, LogContexto.FormacaoCidade, JsonConvert.SerializeObject(alunoGoogle)));
                    }                    
                }
                else
                {
                    var alunoFirst = aluno.FirstOrDefault();
                    var alunoCursoGoogle = new AlunoCursoGoogle(alunoFirst.Indice, filtro.CursoId);

                    await InserirAlunoCursoGoogleAsync(alunoCursoGoogle, alunoFirst.Email);
                }                
            }
            catch (Exception ex)
            {
                filtro.MensagemErro = $"{ex.Message}";
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAlunoErro, filtro));
                await mediator.Send(new SalvarLogViaRabbitCommand($"{RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAluno} - {ex.Message}", LogNivel.Critico, LogContexto.FormacaoCidade, mensagemRabbit.Mensagem.ToString()));
            }

            return true;
        }

        private async Task InserirAlunoCursoGoogleAsync(AlunoCursoGoogle alunoCursoGoogle, string email)
        {
            await mediator.Send(new InserirAlunoCursoGoogleCommand(alunoCursoGoogle, email));
        }
    }
}
