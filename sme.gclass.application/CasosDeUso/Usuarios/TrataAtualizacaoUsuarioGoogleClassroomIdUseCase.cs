using MediatR;
using Newtonsoft.Json;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataAtualizacaoUsuarioGoogleClassroomIdUseCase : ITrataAtualizacaoUsuarioGoogleClassroomIdUseCase
    {
        protected readonly IMediator mediator;
        private const int PrimeiraPagina = 0;

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

            if (dto.Pagina == PrimeiraPagina)
                await mediator.Send(new InciarAtualizacaoUsuarioGoogleClassroomIdCommand());

            var resultadoPaginacao = await mediator.Send(new ObterUsuariosSemGoogleClassroomIdPorTipoQuery(paginacao));
            resultadoPaginacao.Items
                .AsParallel()
                .WithDegreeOfParallelism(10)
                .ForAll(async usuario =>
                {
                    try
                    {
                        var publicarAluno = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaUsuarioGoogleIdAtualizar, RotasRabbit.FilaUsuarioGoogleIdAtualizar, usuario));
                        if (!publicarAluno) return;
                    }
                    catch (Exception ex)
                    {
                        SentrySdk.CaptureException(ex);
                    }
                });

            await ValidaProximaExecucaoAsync(dto, resultadoPaginacao);
            return true;
        }

        private async Task ValidaProximaExecucaoAsync(AtualizacaoUsuarioGoogleClassroomIdPaginadoDto dto, PaginacaoResultadoDto<UsuarioParaAtualizacaoGoogleClassroomIdDto> resultadoPaginacao)
        {
            if (DeveBuscarAProximaPagina(dto, resultadoPaginacao))
            {
                await PublicaProximaPaginaAsync(dto);
                return;
            }

            await mediator.Send(new FinalizarAtualizacaoUsuarioGoogleClassroomIdCommand());
        }


        private bool DeveBuscarAProximaPagina(AtualizacaoUsuarioGoogleClassroomIdPaginadoDto dto, PaginacaoResultadoDto<UsuarioParaAtualizacaoGoogleClassroomIdDto> resultadoPaginacao)
            => resultadoPaginacao.TotalPaginas > (dto.Pagina + 1);

        private async Task PublicaProximaPaginaAsync(AtualizacaoUsuarioGoogleClassroomIdPaginadoDto dto)
        {
            dto.Pagina++;

            try
            {
                var publicarAluno = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaUsuarioGoogleIdSync, RotasRabbit.FilaUsuarioGoogleIdSync, dto));
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