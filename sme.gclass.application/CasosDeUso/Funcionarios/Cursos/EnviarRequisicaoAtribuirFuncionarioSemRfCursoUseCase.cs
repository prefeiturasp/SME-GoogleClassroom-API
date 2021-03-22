using Google;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class EnviarRequisicaoAtribuirFuncionarioSemRfCursoUseCase : IEnviarRequisicaoAtribuirFuncionarioSemRfCursoUseCase
    {
        private readonly IMediator mediator;
        private readonly bool _deveExecutarIntegracao;

        public EnviarRequisicaoAtribuirFuncionarioSemRfCursoUseCase(IMediator mediator, VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public async Task<bool> Executar(AtribuirFuncionarioSemRfCursoDto atribuirFuncionarioSemRfCurso)
        {
            //TODO : Verficar se usuario já existe na nossa base
            var funcionarioGoogle = await ObterFuncionario(atribuirFuncionarioSemRfCurso.Email);

            try
            {
                // TODO : Verificar se o curso existe na base
                var curso = await ObterCurso(atribuirFuncionarioSemRfCurso.TurmaId, atribuirFuncionarioSemRfCurso.ComponenteCurricularId);

                if (curso != null)
                    throw new NegocioException("Curso ainda não inserido no google classroom");

                //TODO : Verficar se relacionamento já existe na nossa base
                var existe = await mediator.Send(new ExisteFuncionarioCursoGoogleQuery(funcionarioGoogle.Indice, curso.Id));

                if (existe)
                    throw new NegocioException("Curso já associado para o funcionário");

                //TODO : Se relacionamento não existir na nossa base inserir relacionameto no google e depois na nossa base de curso usuario.
                await InserirFuncionarioCursoGoogleAsync(funcionarioGoogle, curso);
                return true;
            }
            catch (Exception ex)
            {
                //TODO : qualquer erro inserir na tabela de erro
                await IncluirCursoDoFuncionarioComErroAsync(atribuirFuncionarioSemRfCurso.Email, atribuirFuncionarioSemRfCurso.TurmaId, atribuirFuncionarioSemRfCurso.ComponenteCurricularId,
                    $"ex.: {ex.Message}");
                throw;
            }
        }

        private async Task InserirFuncionarioAsync(FuncionarioGoogle funcionarioGoogle)
        {
            if (_deveExecutarIntegracao)
                funcionarioGoogle.Indice = await mediator.Send(new IncluirUsuarioCommand(funcionarioGoogle));
        }

        private async Task<CursoGoogle> ObterCurso(long turmaId, long componenteCurricularId)
        {
            return await mediator.Send(new ObterCursoPorTurmaComponenteCurricularQuery(turmaId, componenteCurricularId));
        }

        private async Task<FuncionarioGoogle> ObterFuncionario(string email)
        {
            var paginacao = new Paginacao(0, 0);
            var funcionario = await mediator.Send(new ObterFuncionariosGoogleQuery(paginacao, null, email));

            if (funcionario.Items is null)
            {
                //TODO : Se não existir consulta usuario no google, se tiver cadastrado retorna o usuario e cadastra na nossa base, se não retorna erro
                try
                {
                    var usuarioGoogle = await mediator.Send(new ObterUsuarioGoogleQuery(email));
                    var funcionarioGoogle = new FuncionarioGoogle(null, usuarioGoogle.Nome, usuarioGoogle.Email, usuarioGoogle.OrganizationPath);
                    await InserirFuncionarioAsync(funcionarioGoogle);

                    return funcionarioGoogle;
                }
                catch (Exception)
                {
                    throw new NegocioException("Funcionário não encontrado no google classroom");
                }
            }

            return funcionario.Items.First();
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
            if (!_deveExecutarIntegracao) return;
            funcionarioCursoGoogle.Id = await mediator.Send(new IncluirCursoUsuarioCommand(funcionarioCursoGoogle.UsuarioId, funcionarioCursoGoogle.CursoId));
        }

        private async Task IncluirCursoDoFuncionarioComErroAsync(string email, long turmaId, long componenteCurricularId, string mensagem)
        {
            var command = new IncluirCursoUsuarioErroCommand(
                null,
                email,
                turmaId,
                componenteCurricularId,
                ExecucaoTipo.FuncionarioCursoAdicionar,
                ErroTipo.Negocio,
                mensagem);

            await mediator.Send(command);
        }
    }
}
