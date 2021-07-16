using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ProcessarCursoUsuarioGsaUseCase : IProcessarCursoUsuarioGsaUseCase
    {
        private readonly IMediator mediator;

        public ProcessarCursoUsuarioGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit?.Mensagem is null)
                throw new NegocioException("Não foi possível processar o curso do usuário GSA. A mensagem enviada é inválida.");

            var usuarioCursoGsaDto = JsonConvert.DeserializeObject<UsuarioCursoGsaDto>(mensagemRabbit.Mensagem.ToString());
            if (usuarioCursoGsaDto is null)
                throw new NegocioException("Não foi possível processar o curso do usuário GSA. A mensagem enviada é inválida.");

            var usuarioCursoExiste = await mediator.Send(new ExisteCursoDoUsuarioGsaPorUsuarioIdCursoIdQuery(usuarioCursoGsaDto.UsuarioId, usuarioCursoGsaDto.CursoId.ToString()));
            if (usuarioCursoExiste) return true;

            var usuarioCursoTipo = Enum.Parse<UsuarioCursoGsaTipo>(usuarioCursoGsaDto.UsuarioCursoTipo.ToString());
            var usuarioGsa = new UsuarioCursoGsa(usuarioCursoGsaDto.UsuarioId, usuarioCursoGsaDto.CursoId, usuarioCursoTipo);

            var retorno = await mediator.Send(new IncluirUsuarioCursoGsaCommand(usuarioGsa));
            return retorno;
        }
    }
}