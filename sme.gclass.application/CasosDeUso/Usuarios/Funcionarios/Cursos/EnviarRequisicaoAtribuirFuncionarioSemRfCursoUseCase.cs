using Google;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
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

            var funcionarioGoogle = await ObterFuncionario(atribuirFuncionarioSemRfCurso.Email);
            
            var curso = await ObterCurso(atribuirFuncionarioSemRfCurso.TurmaId, atribuirFuncionarioSemRfCurso.ComponenteCurricularId);

            if (curso is null)
                throw new NegocioException("Curso ainda não inserido no Google Classroom");
           
            var existe = await mediator.Send(new ExisteFuncionarioCursoGoogleQuery(funcionarioGoogle.Indice, curso.Id));

            if (existe)
                throw new NegocioException("Curso já associado para o funcionário");

            try
            {                
                await InserirFuncionarioCursoGoogleAsync(funcionarioGoogle, curso);
                return true;
            }
            catch (Exception ex)
            {                
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
            var funcionario = await mediator.Send(new ObterFuncionarioPorEmailQuery(email));

            if (funcionario is null)
            {                
                try
                {
                    var usuarioGoogle = await mediator.Send(new ObterUsuarioGoogleQuery(email));
                    if (usuarioGoogle is null)
                        throw new NegocioException("Funcionário não localizado no google classroom e nem na base de dados");
                    
                    var funcionarioGoogle = new FuncionarioGoogle(null, usuarioGoogle.Nome, usuarioGoogle.Email, usuarioGoogle.OrganizationPath);
                    funcionarioGoogle.GoogleClassroomId = usuarioGoogle.Id;

                    await InserirFuncionarioAsync(funcionarioGoogle);

                    return funcionarioGoogle;
                }
                catch (GoogleApiException gEx)
                {
                    if (gEx.RegistroNaoEncontrado())
                        throw new NegocioException("Funcionário não localizado no Google Classroom e nem na base de dados");
                    if (gEx.AcessoNaoAutorizado())
                        throw new NegocioException("Acesso ao Google Classroom não autorizado");
                    if (gEx.EmailContaServicoInvalido())
                        throw new NegocioException("Email ou id de acesso ao Google Classrom inválido");
                }
            }

            return funcionario;
        }

        private async Task InserirFuncionarioCursoGoogleAsync(FuncionarioGoogle funcionarioGoogle, CursoGoogle cursoGoogle)
        {
            var funcionarioCursoGoogle = new FuncionarioCursoGoogle(funcionarioGoogle.Indice, cursoGoogle.Id);
            try
            {
                var funcionarioCursoSincronizado = await mediator.Send(new InserirFuncionarioCursoGoogleCommand(funcionarioCursoGoogle.CursoId, funcionarioGoogle.Email));
                if (funcionarioCursoSincronizado)
                {
                    await InserirFuncionarioCursoAsync(funcionarioCursoGoogle);
                }
            }
            catch (GoogleApiException gEx)
            {
                if (gEx.EhErroDeDuplicidade())            
                    await InserirFuncionarioCursoAsync(funcionarioCursoGoogle);
                else if (gEx.RegistroNaoEncontrado())
                    throw new NegocioException("Funcionário não localizado no Google Classroom");
                else
                    throw;
            }
        }

        private async Task InserirFuncionarioCursoAsync(FuncionarioCursoGoogle funcionarioCursoGoogle)
        {
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
