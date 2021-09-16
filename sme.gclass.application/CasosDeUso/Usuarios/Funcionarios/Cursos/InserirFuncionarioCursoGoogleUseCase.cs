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
    public class InserirFuncionarioCursoGoogleUseCase : IInserirFuncionarioCursoGoogleUseCase
    {
        private readonly IMediator mediator;
        private readonly bool _deveExecutarIntegracao;

        public InserirFuncionarioCursoGoogleUseCase(IMediator mediator, VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit.Mensagem is null)
                throw new NegocioException("Não foi possível incluir o funcionário no curso. A mensagem enviada é inválida.");

            var funcionarioCursoEolParaIncluir = JsonConvert.DeserializeObject<FuncionarioCursoEol>(mensagemRabbit.Mensagem.ToString());
            if (funcionarioCursoEolParaIncluir is null) return true;

            try
            {
                var funcionario = await mediator.Send(new ObterFuncionariosGooglePorRfsQuery(funcionarioCursoEolParaIncluir.Rf));
                if (funcionario is null || !funcionario.Any()) return false;

                var curso = await mediator.Send(new ObterCursoPorTurmaComponenteCurricularQuery(funcionarioCursoEolParaIncluir.TurmaId, funcionarioCursoEolParaIncluir.ComponenteCurricularId));
                if (curso is null) return false;

                var existeFuncionarioCurso = await mediator.Send(new ExisteFuncionarioCursoGoogleQuery(funcionario.First().Indice, curso.Id));
                if (existeFuncionarioCurso) return true;

                await InserirFuncionarioCursoGoogleAsync(funcionario.First(), curso);
                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirCursoUsuarioErroCommand(funcionarioCursoEolParaIncluir.Rf, funcionarioCursoEolParaIncluir.TurmaId,
                    funcionarioCursoEolParaIncluir.ComponenteCurricularId, ExecucaoTipo.FuncionarioAdicionar, ErroTipo.Interno, 
                    $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit}. StackTrace: {ex.StackTrace}."));
                throw;
            }
        }

        private async Task InserirFuncionarioCursoGoogleAsync(FuncionarioGoogle funcionarioGoogle, CursoGoogle cursoGoogle)
        {
            var funcionarioCursoGoogle = new FuncionarioCursoGoogle(funcionarioGoogle.Indice, cursoGoogle.Id);

            try
            {
                var funcionarioCursoSincronizado = await mediator.Send(new InserirFuncionarioCursoGoogleCommand(funcionarioCursoGoogle, funcionarioGoogle.Email));
                if (funcionarioCursoSincronizado)
                {
                    await InserirFuncionarioCursoAsync(funcionarioCursoGoogle);
                }
            }
            catch (GoogleApiException gEx)
            {
                if (gEx.EhErroDeDuplicidade())
                    await InserirFuncionarioCursoAsync(funcionarioCursoGoogle);
                else
                    throw;
            }
        }

        private async Task InserirFuncionarioCursoAsync(FuncionarioCursoGoogle funcionarioCursoGoogle)
        {
            funcionarioCursoGoogle.Id = await mediator.Send(new IncluirCursoUsuarioCommand(funcionarioCursoGoogle.UsuarioId, funcionarioCursoGoogle.CursoId));
        }
    }
}
