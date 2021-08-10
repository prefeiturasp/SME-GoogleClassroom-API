using MediatR;
using Sentry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarProfessoresInativosGsaUseCase : ITratarProfessoresEFuncionariosParaInativarUseCase
    {
        private readonly IMediator mediator;

        public TratarProfessoresInativosGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<FiltroProfessoresEFuncionarioInativosDto>();

            if (dto.ProcessarFuncionariosIndiretos)
            {
                var funcionariosIndiretosGoogle = await mediator.Send(new ObterFuncionariosIndiretosPorCpfQuery(dto.Cpfs.ToArray()));
                if (funcionariosIndiretosGoogle != null && funcionariosIndiretosGoogle.Any())
                    await TratarFuncionariosIndiretos(funcionariosIndiretosGoogle);
            }

            if (dto.ProcessarProfessoresEFuncionarios)
            {
                var professoresEFuncionariosGoogle = await mediator.Send(new ObterProfessoresEFuncionariosPorCodigosQuery(dto.Rfs.ToArray()));
                if (professoresEFuncionariosGoogle != null && professoresEFuncionariosGoogle.Any())
                    await TratarProfessoresEFuncionarios(professoresEFuncionariosGoogle);
            }
            return true;
        }

        private async Task TratarFuncionariosIndiretos(IEnumerable<FuncionarioIndiretoGoogle> funcionariosIndiretosGoogle)
        {
            foreach (var funcionarioIndireto in funcionariosIndiretosGoogle)
            {
                var usuario = await mediator.Send(new ObterUsuarioPorClassroomIdQuery(funcionarioIndireto.GoogleClassroomId.ToString()));
                var UsuarioEhDonoDoCurso = await mediator.Send(new VerificaUsuarioEhDonoCursoQuery(usuario.Indice, usuario.Email));

                if (UsuarioEhDonoDoCurso)
                {
                    SentrySdk.CaptureMessage($"Não foi possível prosseguir com a inativação.(Usuário é o dono do curso) Email: {usuario.Email}");
                    var funcionarioIndiretoInativar = new ProfessorEFuncionarioInativoDto(usuario.Indice, funcionarioIndireto.Indice, funcionarioIndireto.Email, usuario.UsuarioTipo);
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaInativarProfessorErroTratar, funcionarioIndiretoInativar));
                }

                if (usuario != null & UsuarioEhDonoDoCurso == false)
                {
                    var funcionarioIndiretoInativar = new ProfessorEFuncionarioInativoDto(usuario.Indice, funcionarioIndireto.Indice, funcionarioIndireto.Email, usuario.UsuarioTipo);
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaInativarProfessoresEFuncionariosInativarSync, funcionarioIndiretoInativar));
                }
            }
        }

        private async Task TratarProfessoresEFuncionarios(IEnumerable<ProfessorGoogle> professoresEFuncionariosGoogle)
        {
            foreach (var professor in professoresEFuncionariosGoogle)
            {
                var usuario = await mediator.Send(new ObterUsuarioPorClassroomIdQuery(professor.GoogleClassroomId.ToString()));
                var UsuarioEhDonoDoCurso = await mediator.Send(new VerificaUsuarioEhDonoCursoQuery(usuario.Indice, usuario.Email));

                if (UsuarioEhDonoDoCurso)
                {
                    SentrySdk.CaptureMessage($"Não foi possível prosseguir com a inativação.(Usuário é o dono do curso) Email: {usuario.Email}");
                    var funcionarioIndiretoInativar = new ProfessorEFuncionarioInativoDto(usuario.Indice, professor.Indice, professor.Email, usuario.UsuarioTipo);
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaInativarProfessorErroTratar, funcionarioIndiretoInativar));
                }

                if (usuario != null & UsuarioEhDonoDoCurso == false)
                {
                    var professorFuncionarioInativar = new ProfessorEFuncionarioInativoDto(usuario.Indice, professor.Indice, professor.Email, usuario.UsuarioTipo);
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaInativarProfessoresEFuncionariosInativarSync, professorFuncionarioInativar));
                }
            }
        }
    }
}
