using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ImportarMuralAvisosCursoGsaUseCase : IImportarMuralAvisosCursoGsaUseCase
    {
        private readonly IMediator mediator;

        public ImportarMuralAvisosCursoGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            if (mensagem?.Mensagem is null)
                throw new NegocioException("Não foi possível realizar a importação do aviso do mural. Mensagem não recebida");

            var avisoGsa = mensagem.ObterObjetoMensagem<AvisoMuralGsaDto>();
            var usuario = await ObterUsuario(avisoGsa.UsuarioClassroomId);
            try
            {
                await GravarAvisoGsa(avisoGsa, usuario.Indice);
                if (!await EnviarParaSgp(avisoGsa, usuario))
                    throw new NegocioException("Erro ao publicar aviso do mural para sincronização no SGP");

                return true;
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureMessage($"Não foi possível importar o aviso do mural GSA do curso {avisoGsa.CursoId} e e usuario {avisoGsa.UsuarioClassroomId}: {ex.Message}");
                await EnviarErro(avisoGsa);
                throw;
            }        
        }

        private async Task EnviarErro(AvisoMuralGsaDto avisoGsa)
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaMuralAvisosIncluirErro, avisoGsa));
        }

        private async Task<UsuarioGoogle> ObterUsuario(string usuarioClassroomId)
        {
            var usuario = await mediator.Send(new ObterUsuarioPorClassroomIdQuery(usuarioClassroomId));

            if (usuario == null)
                throw new NegocioException("Usuário não localizado na base GCA para gravação do aviso do mural");

            return usuario;
        }

        private async Task<bool> EnviarParaSgp(AvisoMuralGsaDto avisoGsa, UsuarioGoogle usuario)
        {
            var curso = await mediator.Send(new ObterCursoGooglePorIdQuery(avisoGsa.CursoId));

            var avisoDto = new AvisoMuralIntegracaoSgpDto()
            {
                AvisoClassroomId = avisoGsa.Id,
                TurmaId = curso.TurmaId.ToString(),
                ComponenteCurricularId = curso.ComponenteCurricularId,
                UsuarioRf = usuario.Id.ToString(),
                Mensagem = avisoGsa.Mensagem,
                DataCriacao = avisoGsa.CriadoEm,
                DataAlteracao = avisoGsa.AlteradoEm,
                Email = usuario.Email
            };

            return await mediator.Send(new PublicaFilaRabbitSgpCommand(RotasRabbitSgp.RotaMuralAvisosSync, avisoDto, usuario.Id.ToString(), usuario.Nome));
        }

        private async Task GravarAvisoGsa(AvisoMuralGsaDto avisoGsa, long usuarioIndice)
        {
            await mediator.Send(new GravarAvisoGsaCommand(avisoGsa, usuarioIndice));
        }

    }
}
