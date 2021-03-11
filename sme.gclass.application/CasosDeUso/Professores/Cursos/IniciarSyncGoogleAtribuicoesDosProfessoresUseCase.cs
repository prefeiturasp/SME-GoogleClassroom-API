using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncGoogleAtribuicoesDosProfessoresUseCase : IIniciarSyncGoogleAtribuicoesDosProfessoresUseCase
    {
        private readonly IMediator mediator;

        public IniciarSyncGoogleAtribuicoesDosProfessoresUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar()
        {
            var publicarSyncAtribuicao = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorCursoAtribuicaoSync, RotasRabbit.FilaProfessorCursoAtribuicaoSync, true));
            if (!publicarSyncAtribuicao)
            {
                throw new NegocioException("Não foi possível iniciar a sincronização de atribuições de cursos dos professores.");
            }

            return publicarSyncAtribuicao;
        }
    }
}