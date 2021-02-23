using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
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
            var id = await repositorioCursoErro.SalvarAsync(MapearParaDto(request));

            if (id <= 0)
                throw new NegocioException("Erro ao inserir o erro do curso!");

            return id;
        }

        private CursoErroDto MapearParaDto(InserirCursoErroCommand request) {
            return new CursoErroDto()
            {
                TurmaId = request.TurmaId,
                ComponenteCurricularId = request.ComponenteCurricularId,
                CursoId = request.CursoId,
                ExecucaoTipo = request.ExecucaoTipo,
                DataInclusao = DateTime.Now,
                Mensagem = request.Mensagem
            };
        }
    }
}
