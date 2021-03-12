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
            var funcionarioCursoEolParaIncluir = JsonConvert.DeserializeObject<FuncionarioCursoEol>(mensagemRabbit.Mensagem.ToString());
            if (funcionarioCursoEolParaIncluir is null) return true;

            try
            {
                var funcionario = await mediator.Send(new ObterFuncionariosGooglePorRfsQuery(funcionarioCursoEolParaIncluir.Rf));
                if (funcionario is null || !funcionario.Any()) return false;

                var curso = await mediator.Send(new ObterCursoPorTurmaComponenteCurricularQuery(funcionarioCursoEolParaIncluir.TurmaId, funcionarioCursoEolParaIncluir.ComponenteCurricularId));
                if (curso is null) return false;

                var existeProfessorCurso = await mediator.Send(new ExisteFuncionarioCursoGoogleQuery(funcionarioCursoEolParaIncluir.Rf, curso.Id));
                if (existeProfessorCurso) return true;

                var funcionarioParaUtilizar = funcionario.FirstOrDefault();

                var funcionarioCursoGoogle = new FuncionarioCursoGoogle(funcionarioParaUtilizar.Indice, curso.Id);

                await mediator.Send(new InserirFuncionarioCursoGoogleCommand(funcionarioCursoGoogle, funcionarioParaUtilizar.Email));
                if (_deveExecutarIntegracao) funcionarioCursoGoogle.Id = await mediator.Send(new IncluirCursoUsuarioCommand(funcionarioCursoGoogle.UsuarioId, funcionarioCursoGoogle.CursoId));

                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirCursoUsuarioErroCommand(funcionarioCursoEolParaIncluir.Rf, funcionarioCursoEolParaIncluir.TurmaId,
                    funcionarioCursoEolParaIncluir.ComponenteCurricularId, ExecucaoTipo.FuncionarioAdicionar, ErroTipo.Interno, $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit}"));
                throw;
            }
        }
    }
}
