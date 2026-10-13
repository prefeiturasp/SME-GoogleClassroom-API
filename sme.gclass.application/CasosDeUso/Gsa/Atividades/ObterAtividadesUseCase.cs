using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Atividades;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAtividadesUseCase : IObterAtividadesUseCase
    {
        private readonly IMediator mediator;

        public ObterAtividadesUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<AtividadeDto>> Executar(FiltroAtividadesDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);

            var resultado = await mediator.Send(new AtividadesQuery(paginacao, filtro.DataReferencia, filtro.CursoId));

            return new PaginacaoResultadoDto<AtividadeDto>
            {
                Items = resultado.Items.Select(MapearParaDto),
                TotalPaginas = resultado.TotalPaginas,
                TotalRegistros = resultado.TotalRegistros
            };
        }

        private static AtividadeDto MapearParaDto(AtividadeGsa atividade)
            => new AtividadeDto
            {
                Id = atividade.Id,
                Titulo = atividade.Titulo,
                Descricao = atividade.Descricao,
                UsuarioGsaId = atividade.UsuarioGsaId,
                CursoGsaId = atividade.CursoGsaId,
                DataInclusao = atividade.DataInclusao,
                DataAlteracao = atividade.DataAlteracao,
                DataEntrega = atividade.DataEntrega,
                NotaMaxima = atividade.NotaMaxima
            };
    }
}