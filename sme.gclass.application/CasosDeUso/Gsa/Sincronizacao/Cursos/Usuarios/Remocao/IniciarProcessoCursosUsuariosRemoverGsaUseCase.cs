using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarProcessoCursosUsuariosRemoverGsaUseCase : IIniciarProcessoCursosUsuariosRemoverGsaUseCase
    {
        private readonly IMediator mediator;

        public IniciarProcessoCursosUsuariosRemoverGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(long? turmaId = null, bool processarAlunos = true, bool processarProfessores = true, bool processarFuncionario = true)
        {
            if (turmaId.HasValue)
            {
                var turmaExiste = await mediator.Send(new ExisteTurmaPorCodigoQuery(turmaId.Value));
                if (!turmaExiste)
                    throw new NegocioException("A turma informada não foi localizada na base do EOL.");
            }

            var dto = new CarregarTurmaRemoverCursoUsuarioDto(turmaId, processarAlunos, processarProfessores, processarFuncionario);

            var publicado = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmasCarregar, dto));
            if (!publicado)
                throw new NegocioException("Não foi possível publicar a mensagem para remoção de usuários dos cursos.");

            return publicado;
        }
    }
}