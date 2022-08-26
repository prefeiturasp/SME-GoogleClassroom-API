using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosMatriculadosCelpQueryHandler : IRequestHandler<ObterAlunosMatriculadosCelpQuery, IReadOnlyList<AlunoCelpDto>>
    {
        private readonly IRepositorioAlunoEol repositorioAlunoEol;

        public ObterAlunosMatriculadosCelpQueryHandler(IRepositorioAlunoEol repositorioAlunoEol)
        {
            this.repositorioAlunoEol = repositorioAlunoEol ?? throw new ArgumentNullException(nameof(repositorioAlunoEol));
        }

        public async Task<IReadOnlyList<AlunoCelpDto>> Handle(ObterAlunosMatriculadosCelpQuery request, CancellationToken cancellationToken)
        {
            return (await repositorioAlunoEol.ObterAlunosMatriculadosCelpPorComponenteEAnoLetivo(
                request.ComponenteCurricularId, request.AnoLetivo, request.TurmaId)).ToList();
        }
    }
}