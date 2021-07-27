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
    public class ObterProfessoresParaRemoverCursoQueryHandler : IRequestHandler<ObterProfessoresParaRemoverCursoQuery, IEnumerable<RemoverAtribuicaoProfessorCursoEolDto>>
    {
        private readonly IRepositorioProfessorEol repositorio;

        public ObterProfessoresParaRemoverCursoQueryHandler(IRepositorioProfessorEol repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<IEnumerable<RemoverAtribuicaoProfessorCursoEolDto>> Handle(ObterProfessoresParaRemoverCursoQuery request, CancellationToken cancellationToken)
            => await repositorio.ObterProfessoresParaRemoverCurso(request.TurmaId, request.DataInicio, request.DataFim);
    }
}
