using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirCursoUsuarioErroCommandHandler : IRequestHandler<IncluirCursoUsuarioErroCommand, long>
    {
        private readonly IRepositorioCursoUsuarioErro repositorioCursoUsuarioErro;

        public IncluirCursoUsuarioErroCommandHandler(IRepositorioCursoUsuarioErro repositorioCursoUsuarioErro)
        {
            this.repositorioCursoUsuarioErro = repositorioCursoUsuarioErro;
        }

        public async Task<long> Handle(IncluirCursoUsuarioErroCommand request, CancellationToken cancellationToken)
        {
            var cursoUsuarioErro = new CursoUsuarioErro(
                request.Rf,
                request.TurmaId,
                request.ComponenteCurricularId,
                request.ExecucaoTipo,
                request.ErroTipo,
                request.Mensagem);

            cursoUsuarioErro.Id = await repositorioCursoUsuarioErro.SalvarAsync(cursoUsuarioErro);
            return cursoUsuarioErro.Id;
        }
    }
}