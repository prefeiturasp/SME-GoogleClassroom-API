using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Aplicacao.Usuarios;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarFuncionarioRemovidosCursosUseCase : ITratarFuncionarioRemovidosCursosUseCase
    {
        private readonly IMediator mediator;

        public TratarFuncionarioRemovidosCursosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<FiltroTurmaRemoverCursoUsuarioDto>();
            
            try
            {
                var funcionariosASeremRemovidos = await mediator.Send(
                    new ObterFuncionariosParaRemoverCursoQuery(dto.TurmaId.ToString(), dto.DatasAluno.DataInicio, dto.DatasAluno.DataFim));

                foreach (var funcionarioASeremRemovido in funcionariosASeremRemovidos)
                {
                    var funcionarioECurso = await ObterFuncionarioECurso(funcionarioASeremRemovido);

                    if (funcionarioECurso.funcionarioCurso is null || funcionarioECurso.curso is null)
                        continue;

                    var cursoFuncionarioRemover = new CursoUsuarioRemoverDto
                    {
                        CursoUsuarioId = funcionarioECurso.funcionarioCurso.CursoUsuarioId,
                        CursoId = funcionarioECurso.curso.Id,
                        TipoUsuario = (int) UsuarioTipo.Funcionario,
                        TipoGsa = (int) UsuarioCursoGsaTipo.Funcionario,
                        UsuarioId = funcionarioECurso.funcionarioCurso.UsuarioId,
                        UsuarioGsaId = funcionarioECurso.funcionarioCurso.UsuarioGsaId.ToString(),
                    };

                    if (FuncionarioEResponsavelPeloCurso(funcionarioECurso.funcionarioCurso.Email,
                        funcionarioECurso.curso.Email))
                    {
                        var funcionariosDoCurso =
                            await mediator.Send(new ObterFuncionariosPorCursoQuery(funcionarioECurso.curso.Id));

                        var novoResponsavel =
                            DefinaNovoResponsavelPeloCurso(funcionariosDoCurso, funcionarioECurso.funcionarioCurso);

                        var donoDoCursoAlterado = await mediator.Send(new AtribuirDonoCursoCommand(
                            funcionarioECurso.curso.TurmaId, funcionarioECurso.curso.ComponenteCurricularId,
                            novoResponsavel.GoogleClassroomId, novoResponsavel.Email));
                        if (!donoDoCursoAlterado)
                        {
                            await mediator.Send(new PublicaFilaRabbitCommand(
                                RotasRabbit.FilaGsaCursoUsuarioRemovidoFuncionarioTratarErro,
                                dto));
                            continue;
                        }
                    }

                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoSync,
                        cursoFuncionarioRemover));
                }


            }
            catch (Exception exception)
            {
                SentrySdk.CaptureException(exception);
                await mediator.Send(new PublicaFilaRabbitCommand(
                    RotasRabbit.FilaGsaCursoUsuarioRemovidoFuncionarioTratarErro,
                    dto));
            }


            return true;
        }

        private async Task<(CursoGoogle curso, FuncionarioCurso funcionarioCurso)> ObterFuncionarioECurso(
            RemoverAtribuicaoFuncionarioTurmaEolDto funcionarioASeremRemovido)
        {
            FuncionarioCurso funcionarioCurso = null;
            var curso = await mediator.Send(new ObterCursoPorTurmaComponenteCurricularQuery(
                funcionarioASeremRemovido.TurmaCodigo, funcionarioASeremRemovido.ComponenteCurricularCodigo));
            if (curso != null)
            {
                funcionarioCurso =
                    await mediator.Send(
                        new ObterFuncionarioCursoPorUsuarioRfCursoIdQuery(
                            long.Parse(funcionarioASeremRemovido.UsuarioRf), curso.Id));
            }

            return (curso, funcionarioCurso);
        }

        private bool FuncionarioEResponsavelPeloCurso(string funcionarioEmail, string cursoEmail)
        {
            return funcionarioEmail.Equals(cursoEmail);
        }

        private UsuarioGoogleDto DefinaNovoResponsavelPeloCurso(IEnumerable<UsuarioGoogleDto> funcionariosDoCurso,
            FuncionarioCurso professor)
        {
            UsuarioGoogleDto funcionarioResponsavel;

            var tiposFuncionarios = new[] {"/Professores", "/Admin/CP", "/Admin/AD", "/Admin/DIRETOR"};
            var funcionarios = funcionariosDoCurso.Where(o => !o.Email.Equals(professor.Email)).ToList();

            foreach (var tipoFuncionario in tiposFuncionarios)
            {
                funcionarioResponsavel = funcionarios.FirstOrDefault(o => o.OrganizationPath.Equals(tipoFuncionario));

                if (funcionarioResponsavel != null)
                    return funcionarioResponsavel;
            }

            throw new NegocioException(
                "Não foi possível localizar novo responsável pelo curso. O professor não poderá ser removido.");
        }
    }
}