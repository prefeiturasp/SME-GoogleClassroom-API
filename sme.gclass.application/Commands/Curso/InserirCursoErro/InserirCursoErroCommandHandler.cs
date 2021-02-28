using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirCursoErroCommandHandler : IRequestHandler<InserirCursoErroCommand, long>
    {
        private readonly IRepositorioCursoErro repositorioCursoErro;

        public InserirCursoErroCommandHandler(IRepositorioCursoErro repositorioCursoErro)
        {
            this.repositorioCursoErro = repositorioCursoErro ?? throw new ArgumentNullException(nameof(repositorioCursoErro));
        }

        public async Task<long> Handle(InserirCursoErroCommand request, CancellationToken cancellationToken)
        {
            var entidade = MapearParaEntidade(request);
            var id = await repositorioCursoErro.SalvarAsync(entidade);

            if (id <= 0)
                throw new NegocioException("Erro ao inserir o erro do curso!");

            return id;
        }

        private CursoErro MapearParaEntidade(InserirCursoErroCommand request)
        {
            return new CursoErro(request.TurmaId, request.ComponenteCurricularId, request.Mensagem, request.ExecucaoTipo, request.CursoId, request.ErroTipo);
        }
    }
}
