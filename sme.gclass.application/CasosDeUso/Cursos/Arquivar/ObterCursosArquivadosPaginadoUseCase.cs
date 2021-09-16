using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Aplicacao.Queries.Cursos.ObterCursosArquivadosPorDataArquivamentoPaginado;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosArquivadosPaginadoUseCase : AbstractUseCase, IObterCursosArquivadosPaginadoUseCase
    {
        public ObterCursosArquivadosPaginadoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<PaginacaoResultadoDto<CursoArquivadoDto>> Executar(FiltroCursoArquivadoDto param)
        {
            var paginacao = new Paginacao(param.PaginaNumero, param.RegistrosQuantidade);
            return await mediator.Send(new ObterCursosArquivadosPorDataArquivamentoPaginadoQuery(param.DataArquivamento, paginacao));
        }
    }
}
