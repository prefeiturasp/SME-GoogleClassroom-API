using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresCursosGoogleQueryHandler : IRequestHandler<ObterProfessoresCursosGoogleQuery, PaginacaoResultadoDto<ProfessorCursosCadastradosDto>>
    {
        private readonly IRepositorioCursoUsuario repositorioCursoUsuario;

        public ObterProfessoresCursosGoogleQueryHandler(IRepositorioCursoUsuario repositorioCursoUsuario)
        {
            this.repositorioCursoUsuario = repositorioCursoUsuario ?? throw new ArgumentNullException(nameof(repositorioCursoUsuario));
        }

        public async Task<PaginacaoResultadoDto<ProfessorCursosCadastradosDto>> Handle(ObterProfessoresCursosGoogleQuery request, CancellationToken cancellationToken)
            => await repositorioCursoUsuario.ObterProfessoresCursosAsync(request.Paginacao, request.Rf, request.TurmaId, request.ComponenteCurricularId);
    }
}
