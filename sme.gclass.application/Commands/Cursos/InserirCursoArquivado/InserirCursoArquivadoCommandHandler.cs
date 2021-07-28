using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirCursoArquivadoCommandHandler : AsyncRequestHandler<InserirCursoArquivadoCommand>
    {
        private readonly IRepositorioCursoArquivado repositorioCursoArquivado;

        public InserirCursoArquivadoCommandHandler(IRepositorioCursoArquivado repositorioCursoArquivado)
        {
            this.repositorioCursoArquivado = repositorioCursoArquivado ?? throw new ArgumentNullException(nameof(repositorioCursoArquivado));
        }

        protected override async Task Handle(InserirCursoArquivadoCommand request, CancellationToken cancellationToken)
        {
            await repositorioCursoArquivado.Inserir(request.CursoId, request.DataArquivamento, request.DataExtincao, request.Extinto);
        }
    }
}
