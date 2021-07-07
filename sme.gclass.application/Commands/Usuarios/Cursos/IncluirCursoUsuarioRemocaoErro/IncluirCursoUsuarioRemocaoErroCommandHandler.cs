using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirCursoUsuarioRemocaoErroCommandHandler : IRequestHandler<IncluirCursoUsuarioRemocaoErroCommand, long>
    {
        private readonly IRepositorioUsuarioCursoRemovidoGsaErro repositorio;

        public IncluirCursoUsuarioRemocaoErroCommandHandler(IRepositorioUsuarioCursoRemovidoGsaErro repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<long> Handle(IncluirCursoUsuarioRemocaoErroCommand request, CancellationToken cancellationToken)
            => await repositorio.SalvarAsync(request.UsuarioCursoRemovidoGsaErro);
    }
}