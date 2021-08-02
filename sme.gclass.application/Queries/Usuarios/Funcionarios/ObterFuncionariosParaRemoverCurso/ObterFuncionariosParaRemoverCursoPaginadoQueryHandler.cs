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
    public class ObterFuncionariosParaRemoverCursoQueryHandler : IRequestHandler<ObterFuncionariosParaRemoverCursoQuery, IEnumerable<RemoverAtribuicaoFuncionarioTurmaEolDto>>
    {
        private readonly IRepositorioFuncionarioEol repositorio;

        public ObterFuncionariosParaRemoverCursoQueryHandler(IRepositorioFuncionarioEol repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<IEnumerable<RemoverAtribuicaoFuncionarioTurmaEolDto>> Handle(ObterFuncionariosParaRemoverCursoQuery request, CancellationToken cancellationToken)
            => await repositorio.ObterFuncionariosParaRemoverCurso(request.TurmaId, request.DataInicio, request.DataFim);

    }
}
