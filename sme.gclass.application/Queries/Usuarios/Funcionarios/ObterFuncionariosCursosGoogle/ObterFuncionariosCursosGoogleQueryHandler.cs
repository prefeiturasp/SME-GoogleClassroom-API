using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosCursosGoogleQueryHandler : IRequestHandler<ObterFuncionariosCursosGoogleQuery, PaginacaoResultadoDto<FuncionarioCursosCadastradosDto>>
    {
        private readonly IRepositorioCursoUsuario repositorioCursoUsuario;

        public ObterFuncionariosCursosGoogleQueryHandler(IRepositorioCursoUsuario repositorioCursoUsuario)
        {
            this.repositorioCursoUsuario = repositorioCursoUsuario ?? throw new ArgumentNullException(nameof(repositorioCursoUsuario));
        }

        public async Task<PaginacaoResultadoDto<FuncionarioCursosCadastradosDto>> Handle(ObterFuncionariosCursosGoogleQuery request, CancellationToken cancellationToken)
            => await repositorioCursoUsuario.ObterFuncionariosCursosAsync(request.Paginacao, request.Rf, request.TurmaId, request.ComponenteCurricularId);
    }
}
