using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosParaRemoverCursoPaginadoQueryHandler : IRequestHandler<ObterFuncionariosParaRemoverCursoPaginadoQuery, PaginacaoResultadoDto<RemoverAtribuicaoFuncionarioTurmaEolDto>>
    {
        private readonly IRepositorioFuncionarioEol repositorio;

        public ObterFuncionariosParaRemoverCursoPaginadoQueryHandler(IRepositorioFuncionarioEol repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<PaginacaoResultadoDto<RemoverAtribuicaoFuncionarioTurmaEolDto>> Handle(ObterFuncionariosParaRemoverCursoPaginadoQuery request, CancellationToken cancellationToken)
            => await repositorio.ObterFuncionariosParaRemoverCursoPaginado(request.TurmaId, request.DataInicio, request.DataFim, request.Paginacao, request.ParametrosCargaInicialDto);
    }
}
