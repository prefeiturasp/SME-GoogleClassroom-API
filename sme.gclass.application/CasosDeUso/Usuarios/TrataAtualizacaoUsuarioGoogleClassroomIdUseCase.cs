using MediatR;
using Newtonsoft.Json;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public abstract class TrataAtualizacaoUsuarioGoogleClassroomIdUseCase<TEntity> : ITrataAtualizacaoUsuarioGoogleClassroomIdUseCase
        where TEntity : UsuarioGoogle
    {
        protected readonly IMediator mediator;

        public TrataAtualizacaoUsuarioGoogleClassroomIdUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit?.Mensagem is null)
                throw new NegocioException("Não foi possível iniciar a atualização de usuários sem GoogleClassroomId.");

            var dto = JsonConvert.DeserializeObject<AtualizacaoUsuarioGoogleClassroomIdPaginadoDto>(mensagemRabbit.Mensagem.ToString());
            var paginacao = new Paginacao(dto.Pagina, dto.RegistrosPorPagina);

            var resultadoPaginacao = await mediator.Send(new ObterUsuariosSemGoogleClassroomIdPorTipoQuery<TEntity>(paginacao, UsuarioTipo));
            foreach (var usuario in resultadoPaginacao.Items)
            {
                var usuarioAtualizacaoDto = new UsuarioParaAtualizacaoGoogleClassroomIdDto
                {
                    Email = usuario.Email,
                    UsuarioId = usuario.Indice
                };

                try
                {
                    var publicarAluno = await mediator.Send(new PublicaFilaRabbitCommand(RotaFilaRabbitAtualizar, RotaFilaRabbitAtualizar, usuarioAtualizacaoDto));
                    if (!publicarAluno) continue;
                }
                catch (Exception ex)
                {
                    SentrySdk.CaptureException(ex);
                    continue;
                }
            }

            if (DeveBuscarAProximaPagina(dto, resultadoPaginacao))
                await PublicaProximaPaginaAsync(dto);

            return true;
        }

        protected abstract UsuarioTipo UsuarioTipo { get; }

        protected abstract string RotaFilaRabbitSync { get; }

        protected abstract string RotaFilaRabbitAtualizar { get; }

        protected virtual bool DeveBuscarAProximaPagina(AtualizacaoUsuarioGoogleClassroomIdPaginadoDto dto, PaginacaoResultadoDto<TEntity> resultadoPaginacao)
            => resultadoPaginacao.TotalPaginas > (dto.Pagina + 1);

        protected virtual async Task PublicaProximaPaginaAsync(AtualizacaoUsuarioGoogleClassroomIdPaginadoDto dto)
        {
            dto.Pagina++;

            try
            {
                var publicarAluno = await mediator.Send(new PublicaFilaRabbitCommand(RotaFilaRabbitSync, RotaFilaRabbitSync, dto));
                if (!publicarAluno)
                    SentrySdk.CaptureMessage("Não foi possível iniciar a próxima página da atualização de GoogleClassroomId.");
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }
        }
    }
}