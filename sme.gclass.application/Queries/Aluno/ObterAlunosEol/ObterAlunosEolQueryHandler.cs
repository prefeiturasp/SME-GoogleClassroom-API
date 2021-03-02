using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    class ObterAlunosEolQueryHandler : IRequestHandler<ObterAlunosEolQuery, PaginacaoResultadoDto<AlunoDto>>
    {
        private readonly IRepositorioAlunoEol repositorioAlunoEol;

        public ObterAlunosEolQueryHandler(IRepositorioAlunoEol repositorioAlunoEol)
        {
            this.repositorioAlunoEol = repositorioAlunoEol ?? throw new System.ArgumentNullException(nameof(repositorioAlunoEol));
        }
        public async Task<PaginacaoResultadoDto<AlunoDto>> Handle(ObterAlunosEolQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAlunoEol.ObterAlunosAsync(request.Paginacacao, request.AnoLetivo, request.DataReferencia);
        }
    }
}
