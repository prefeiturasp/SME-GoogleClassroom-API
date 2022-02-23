using MediatR;
using SME.GoogleClassroom.Dados;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresPorDreComponenteCurricularModalidadeQueryHandler : IRequestHandler<ObterProfessoresPorDreComponenteCurricularModalidadeQuery, IEnumerable<string>>
    {
        private readonly IRepositorioProfessorEol repositorioProfessorEol;

        public ObterProfessoresPorDreComponenteCurricularModalidadeQueryHandler(IRepositorioProfessorEol repositorioProfessorEol)
        {
            this.repositorioProfessorEol = repositorioProfessorEol;
        }

        public async Task<IEnumerable<string>> Handle(ObterProfessoresPorDreComponenteCurricularModalidadeQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProfessorEol.ObterProfessoresPorDreComponenteCurricularModalidade(request.CodigoDre, request.ComponentesCurricularIds, request.ModalidadesIds, request.TipoEscola, request.AnoLetivo, request.AnoTurma);
        }
    }
}