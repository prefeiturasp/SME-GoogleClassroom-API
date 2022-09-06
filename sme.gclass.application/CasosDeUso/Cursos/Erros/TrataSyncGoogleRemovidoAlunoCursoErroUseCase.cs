using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Queries.Cursos.ObterAlunoCursoRemovidoErro;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleRemovidoAlunoCursoErroUseCase : ITrataSyncGoogleRemovidoAlunoCursoErroUseCase
    {
        private readonly IMediator mediator;
        private readonly bool _deveExecutarIntegracao;

        public TrataSyncGoogleRemovidoAlunoCursoErroUseCase(IMediator mediator,
            VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
        
            var errosParaTratar = await mediator.Send(new ObterAlunoCursoRemovidoErroQuery());
            if (errosParaTratar != null && errosParaTratar.Any())
            {
                foreach (var erroParaTratar in errosParaTratar)
                {
                    try
                    {
                        var dto = new CursoUsuarioRemoverDto
                        {
                            CursoUsuarioId = erroParaTratar.CursoUsuarioId,
                            TipoUsuario = erroParaTratar.UsuarioTipo.Equals(1) ? (int)UsuarioTipo.Aluno : (int)UsuarioTipo.Professor,
                            TipoGsa = erroParaTratar.UsuarioTipo.Equals(1) ? (int)UsuarioCursoGsaTipo.Estudante : (int)UsuarioCursoGsaTipo.Professor,
                            UsuarioId = erroParaTratar.UsuarioId,
                            CursoId = erroParaTratar.CursoId,
                            UsuarioGsaId = erroParaTratar.UsuarioIdGsa,
                        };

                        await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoSync, dto));

                        await ExcluirCursoErroAsync(erroParaTratar);
                    }
                    catch (Exception ex)
                    {
                        await mediator.Send(new SalvarLogViaRabbitCommand($"TrataSyncGoogleRemovidoAlunoCursoErroUseCase - Não foi possível excluir curso", LogNivel.Critico, LogContexto.CelpGsa, ex.Message, ex.StackTrace));
                        return false;
                    }
                }
            }
            return true;
        }

        private async Task ExcluirCursoErroAsync(CursoUsuarioRemovidoGsaErro cursoUsuarioRemovidoGsaErro)
        {
            if (!_deveExecutarIntegracao) return;
            if (!await mediator.Send(new ExcluirRemoverCursoAlunoErroCommand(cursoUsuarioRemovidoGsaErro.UsuarioId,
                cursoUsuarioRemovidoGsaErro.UsuarioId)))
            {
                await mediator.Send(new SalvarLogViaRabbitCommand($"TrataSyncGoogleRemovidoAlunoCursoErroUseCase - Não foi possível excluir o erro do usuario Id {cursoUsuarioRemovidoGsaErro.UsuarioId} do curso id {cursoUsuarioRemovidoGsaErro.CursoId}", LogNivel.Critico, LogContexto.CelpGsa, null, null));
            }
        }
    }
}