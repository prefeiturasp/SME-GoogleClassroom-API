using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizarComponentesCurricularesNotasUseCase : AbstractUseCase, ISincronizarComponentesCurricularesNotasUseCase
    {
        public SincronizarComponentesCurricularesNotasUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            var filtro = mensagem.ObterObjetoMensagem<FiltroComponenteCurricularAtividadeDto>();

            if (filtro != null)
            {
                var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
                var atividadesPaginadas = await mediator.Send(new ObterAtividadesPorComponenteCurricularEAnoLetivoQuery(filtro.ComponenteCurricularId, DateTime.Now.Year, paginacao));
                foreach(var avaliacao in atividadesPaginadas.Items)
                {

                }
            }
            return true;
        }
    }
}
