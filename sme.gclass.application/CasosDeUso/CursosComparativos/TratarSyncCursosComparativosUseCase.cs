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
    public class TratarSyncCursosComparativosUseCase : ITratarSyncCursosComparativosUseCase
    {
        protected readonly IMediator mediator;
        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit?.Mensagem is null)
                throw new NegocioException("Não foi possível iniciar a atualização de usuários sem GoogleClassroomId.");

            //var dto = JsonConvert.DeserializeObject<AtualizacaoUsuarioGoogleClassroomIdPaginadoDto>(mensagemRabbit.Mensagem.ToString());
            //var paginacao = new Paginacao(dto.Pagina, dto.RegistrosPorPagina);

            //var resultadoPaginacao = await mediator.Send(new ObterUsuariosSemGoogleClassroomIdPorTipoQuery(paginacao));
            //foreach (var usuario in resultadoPaginacao.Items)
            //{
            //    try
            //    {
            //        var publicarAluno = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoComparativoSync, RotasRabbit.FilaCursoComparativoSync, usuario));
            //        if (!publicarAluno) continue;
            //    }
            //    catch (Exception ex)
            //    {
            //        SentrySdk.CaptureException(ex);
            //        continue;
            //    }
            //}

            //if (DeveBuscarAProximaPagina(dto, resultadoPaginacao))
            //    await PublicaProximaPaginaAsync(dto);

            return true;
        }


        //protected virtual bool DeveBuscarAProximaPagina(AtualizacaoUsuarioGoogleClassroomIdPaginadoDto dto, PaginacaoResultadoDto<UsuarioParaAtualizacaoGoogleClassroomIdDto> resultadoPaginacao)
        //    => resultadoPaginacao.TotalPaginas > (dto.Pagina + 1);

        //protected virtual async Task PublicaProximaPaginaAsync(AtualizacaoUsuarioGoogleClassroomIdPaginadoDto dto)
        //{
        //    dto.Pagina++;

        //    try
        //    {
        //        var publicarAluno = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaUsuarioGoogleIdSync, RotasRabbit.FilaUsuarioGoogleIdSync, dto));
        //        if (!publicarAluno)
        //            SentrySdk.CaptureMessage("Não foi possível iniciar a próxima página da atualização de GoogleClassroomId.");
        //    }
        //    catch (Exception ex)
        //    {
        //        SentrySdk.CaptureException(ex);
        //    }
        //}
    }
}
