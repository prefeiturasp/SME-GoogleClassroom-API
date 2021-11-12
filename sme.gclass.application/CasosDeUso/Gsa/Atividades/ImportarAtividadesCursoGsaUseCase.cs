using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ImportarAtividadesCursoGsaUseCase : IImportarAtividadesCursoGsaUseCase
    {
        private readonly IMediator mediator;

        public ImportarAtividadesCursoGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            if (mensagem?.Mensagem is null)
                throw new NegocioException("Não foi possível realizar a importação do atividades avaliativas. Mensagem não recebida");

            var atividadesGsa = mensagem.ObterObjetoMensagem<AtividadeGsaDto[]>();

            foreach (var atividadeGsa in atividadesGsa)
            {
                var usuario = await ObterUsuario(atividadeGsa.UsuarioClassroomId);
                try
                {
                    // Atividades sem descrição devem ser importadadas com o Título
                    atividadeGsa.Descricao = string.IsNullOrEmpty(atividadeGsa.Descricao?.Trim()) ?
                        atividadeGsa.Titulo :
                        atividadeGsa.Descricao;

                    await GravarAtividadeGsa(atividadeGsa, usuario.Indice);
                    if(!atividadeGsa.CursoCriadoManualmente)
                    if (!await EnviarParaSgp(atividadeGsa, usuario))
                        throw new NegocioException("Erro ao publicar aviso do mural para sincronização no SGP");                    
                }
                catch (Exception ex)
                {
                    await EnviarErro(atividadeGsa);
                    SentrySdk.CaptureMessage($"Não foi possível importar o aviso do mural GSA do curso {atividadeGsa.CursoId} e e usuario {atividadeGsa.UsuarioClassroomId}: {ex.Message}");
                    throw;
                }
            }

            return true;
        }

        private async Task EnviarErro(AtividadeGsaDto atividadeGsa)
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaAtividadesIncluirErro, atividadeGsa));
        }

        private async Task<UsuarioGoogleDto> ObterUsuario(string usuarioClassroomId)
        {
            var usuario = await mediator.Send(new ObterUsuarioPorClassroomIdQuery(usuarioClassroomId));

            if (usuario == null)
                throw new NegocioException("Usuário não localizado na base GCA para gravação do aviso do mural");

            return usuario;
        }

        private async Task<bool> EnviarParaSgp(AtividadeGsaDto atividadeGsa, UsuarioGoogleDto usuario)
        {
            var curso = await mediator.Send(new ObterCursoGooglePorIdQuery(atividadeGsa.CursoId));

            var avisoDto = new AtividadeIntegracaoSgpDto()
            {
                AtividadeClassroomId = atividadeGsa.Id,
                TurmaId = curso.TurmaId.ToString(),
                ComponenteCurricularId = curso.ComponenteCurricularId,
                UsuarioRf = usuario.Id.ToString(),
                Titulo = atividadeGsa.Titulo,
                Descricao = atividadeGsa.Descricao,
                DataCriacao = atividadeGsa.CriadoEm,
                DataAlteracao = atividadeGsa.AlteradoEm,
            };

            return await mediator.Send(new PublicaFilaRabbitSgpCommand(RotasRabbitSgp.RotaAtividadesSync, avisoDto, usuario.Id.ToString(), usuario.Nome));
        }

        private async Task GravarAtividadeGsa(AtividadeGsaDto atividadeGsa, long usuarioIndice)
        {
            await mediator.Send(new GravarAtividadeGsaCommand(atividadeGsa, usuarioIndice));
        }
    }
}
