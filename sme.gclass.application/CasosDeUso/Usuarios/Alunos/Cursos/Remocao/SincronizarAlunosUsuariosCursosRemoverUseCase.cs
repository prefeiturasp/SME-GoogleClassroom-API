using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizarAlunosUsuariosCursosRemoverUseCase : ISincronizarAlunosUsuariosCursosRemoverUseCase
    {
        private readonly IMediator mediator;

        public SincronizarAlunosUsuariosCursosRemoverUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<CursoUsuarioRemoverDto>();
            try
            {
                await mediator.Send(new IncluirUsuarioCursoRemovidoCommand(dto.UsuarioId, dto.CursoId, UsuarioTipo.Aluno));
                var diretorioClassroom = await mediator.Send(new ObterDirectoryServiceGoogleClassroomQuery());
                var usuarioGsa = await diretorioClassroom.Users.Get(dto.EmailUsuario).ExecuteAsync();
                dto.UsuarioGsaId = usuarioGsa.Id;
            }
            catch(Exception e)
            {
                //TODO incluir na tabela de erros
            }

            return true;
        }
    }
}
