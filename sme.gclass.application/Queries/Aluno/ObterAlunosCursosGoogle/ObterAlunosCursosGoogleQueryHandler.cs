using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCursosGoogleQueryHandler : IRequestHandler<ObterAlunosCursosGoogleQuery, PaginacaoResultadoDto<AlunoCursosCadastradosDto>>
    {
        private readonly IRepositorioCursoUsuario repositorioCursoUsuario;

        public ObterAlunosCursosGoogleQueryHandler(IRepositorioCursoUsuario repositorioCursoUsuario)
        {
            this.repositorioCursoUsuario = repositorioCursoUsuario ?? throw new ArgumentNullException(nameof(repositorioCursoUsuario));
        }

        public Task<PaginacaoResultadoDto<AlunoCursosCadastradosDto>> Handle(ObterAlunosCursosGoogleQuery request, CancellationToken cancellationToken)
            => repositorioCursoUsuario.ObterAlunosCursosAsync(request.Paginacao, request.CodigoAluno, request.TurmaId, request.ComponenteCurricularId);
    }
}
