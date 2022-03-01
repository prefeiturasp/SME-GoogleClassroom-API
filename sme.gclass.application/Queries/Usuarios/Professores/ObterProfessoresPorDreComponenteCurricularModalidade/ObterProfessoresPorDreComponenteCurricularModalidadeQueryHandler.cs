using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresPorDreComponenteCurricularModalidadeQueryHandler : IRequestHandler<ObterProfessoresPorDreComponenteCurricularModalidadeQuery, IEnumerable<AlunoCursoEol>>
    {
        private readonly IRepositorioProfessorEol repositorioProfessorEol;

        public ObterProfessoresPorDreComponenteCurricularModalidadeQueryHandler(IRepositorioProfessorEol repositorioProfessorEol)
        {
            this.repositorioProfessorEol = repositorioProfessorEol;
        }

        public async Task<IEnumerable<AlunoCursoEol>> Handle(ObterProfessoresPorDreComponenteCurricularModalidadeQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProfessorEol.ObterProfessoresPorDreComponenteCurricularModalidade(request.ComponentesCurricularIds, request.ModalidadesIds, request.TipoEscola, request.AnoLetivo, request.AnoTurma, request.CodigosDre);
        }
    }
}