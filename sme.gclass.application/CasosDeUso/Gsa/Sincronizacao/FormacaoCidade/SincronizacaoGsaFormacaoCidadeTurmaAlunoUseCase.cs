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
                var alunoCursoGoogle = new AlunoCursoGoogle();

                var aluno = await mediator.Send(new ObterUsuariosPorCodigosQuery(filtro.CodigoAluno));
                if (aluno is null || !aluno.Any())
                {
                    
                        var professorEol = new ProfessorEol(filtro.CodigoRF, filtro.NomePessoa, filtro.NomeSocial?? string.Empty, filtro.OrganizationPath);

                        var professorGoogle = new ProfessorGoogle(filtro.CodigoRF, filtro.NomePessoa, professorEol.Email, filtro.OrganizationPath);
                        var indiceInserido = await InserirProfessorGoogleAsync(professorGoogle);

                        if (indiceInserido > 0)
                        {
                            var usuarioGsa = new UsuarioGsa(filtro.CodigoRF.ToString(), professorEol.Email, filtro.NomePessoa, null, false, filtro.OrganizationPath, false, DateTime.Now);
                            var usuarioGsaInserido = await mediator.Send(new IncluirUsuarioGsaCommand(usuarioGsa));

                            alunoCursoGoogle = new AlunoCursoGoogle(indiceInserido, filtro.CursoId);
                            await InserirAlunoCursoGoogleAsync(alunoCursoGoogle, professorEol.Email);
                        }
                        else
                        {
                            filtro.MensagemErro += $" Inserido: {indiceInserido}";
                            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAlunoErro, filtro));
                        }                        
                }
                else
                {
                    var alunoFirst = aluno.FirstOrDefault();
                    alunoCursoGoogle = new AlunoCursoGoogle(alunoFirst.Indice, filtro.CursoId);
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

        private async Task<long> InserirProfessorGoogleAsync(ProfessorGoogle professorGoogle)
        {
            try
            {
                var professorSincronizado = await mediator.Send(new InserirProfessorGoogleCommand(professorGoogle));
                if (!professorSincronizado)
                {
                    await mediator.Send(new SalvarLogViaRabbitCommand($"{RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAluno} - {$"Não foi possível incluir o professor no Google Classroom. {professorGoogle}"}", LogNivel.Critico, LogContexto.FormacaoCidade, JsonConvert.SerializeObject(professorGoogle)));
                    return 0;
                }

                return await InserirProfessorAsync(professorGoogle);
            }
            catch (GoogleApiException gEx)
            {
                await mediator.Send(new SalvarLogViaRabbitCommand($"{RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAluno} - {$"Não foi possível incluir o professor no Google Classroom. {gEx.Message}"}", LogNivel.Critico, LogContexto.FormacaoCidade, JsonConvert.SerializeObject(professorGoogle)));
                return 0;
            }
        }
        private async Task<long> InserirProfessorAsync(ProfessorGoogle professorGoogle)
        {
            return await mediator.Send(new IncluirUsuarioCommand(professorGoogle));
        }

        private async Task InserirAlunoCursoGoogleAsync(AlunoCursoGoogle alunoCursoGoogle, string email)
        {
            await mediator.Send(new InserirAlunoCursoGoogleCommand(alunoCursoGoogle, email));
        }
    }
}
