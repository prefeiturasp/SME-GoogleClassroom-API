using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Sentry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarAlunosCursoUsuarioRemovidoCelpUseCase :ITratarAlunosCursoUsuarioRemovidoCelpUseCase
    {
        private readonly IMediator mediator;
        private readonly bool _deveExecutarIntegracao;

        public TratarAlunosCursoUsuarioRemovidoCelpUseCase(IMediator mediator, VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<FiltroTurmaRemoverCursoUsuarioDto>();

            var alunosCodigosInativosEOL = await mediator.Send(new ObterAlunosCodigosInativosPorAnoLetivoETurmaCelpQuery(DateTime.Today.Year, dto.TurmaId));

            if (alunosCodigosInativosEOL != null && alunosCodigosInativosEOL.Any())
            {
                var cursosUsuarios = await mediator.Send(new ObterAlunosCodigosComRegistroEmCursosQuery(alunosCodigosInativosEOL, dto.TurmaId));

                if (cursosUsuarios != null && cursosUsuarios.Any())
                {
                    foreach (var cursoUsuario in cursosUsuarios)
                    {
                        var cursoUsuarioRemover = new CursoUsuarioRemoverDto()
                        {
                            CursoUsuarioId = cursoUsuario.CursoUsuarioId,
                            CursoId = cursoUsuario.CursoId,
                            UsuarioId = cursoUsuario.UsuarioId,
                            UsuarioGsaId = cursoUsuario.UsuarioGsaId,
                            TipoUsuario = (int)UsuarioTipo.Aluno,
                            TipoGsa = (int)UsuarioCursoGsaTipo.Estudante,
                        };

                        await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoSync, cursoUsuarioRemover));
                    }
                }
            }
            
            return true;
        }
    }
}
