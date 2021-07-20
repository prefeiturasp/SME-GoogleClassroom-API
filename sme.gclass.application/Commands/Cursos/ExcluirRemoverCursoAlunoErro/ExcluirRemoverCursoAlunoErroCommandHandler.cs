using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExcluirRemoverCursoAlunoErroCommandHandler : IRequestHandler<ExcluirRemoverCursoAlunoErroCommand, bool>
    {
        private readonly IRepositorioCursoUsuarioRemovidoGsaErro _repositorioCursoUsuarioRemovidoGsaErro;

        public ExcluirRemoverCursoAlunoErroCommandHandler(
            IRepositorioCursoUsuarioRemovidoGsaErro repositorioCursoUsuarioRemovidoGsaErro)
        {
            _repositorioCursoUsuarioRemovidoGsaErro = repositorioCursoUsuarioRemovidoGsaErro ??
                                                      throw new ArgumentNullException(
                                                          nameof(repositorioCursoUsuarioRemovidoGsaErro));
        }


        public async Task<bool> Handle(ExcluirRemoverCursoAlunoErroCommand request, CancellationToken cancellationToken)
        {
            await _repositorioCursoUsuarioRemovidoGsaErro.Excluir(request.UsuarioId, request.CursoId);
            return true;
        }
    }
}