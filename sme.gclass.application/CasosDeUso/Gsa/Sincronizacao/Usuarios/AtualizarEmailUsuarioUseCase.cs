using System;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtualizarEmailUsuarioUseCase : IAtualizarEmailUsuarioUseCase
    {
        private readonly IMediator mediator;

        public AtualizarEmailUsuarioUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Executar(InserirAtualizarEmailDTO filtro)
        {
            // Etapas para serem realizadas
            // Buscar os usuarios no banco de acordo com o filtro
            // verificar os usuarios que não existem na lista vinda do banco
            // atualizar os usuarios que existem na lista vinda do banco
            // inserir os usuarios que não existem na lista vinda do banco
            throw new System.NotImplementedException();
        }
    }
}