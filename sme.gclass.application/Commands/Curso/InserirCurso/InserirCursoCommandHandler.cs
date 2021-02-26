using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirCursoCommandHandler : IRequestHandler<InserirCursoCommand, long>
    {
        private readonly IRepositorioCurso repositorioCurso;

        public InserirCursoCommandHandler(IRepositorioCurso repositorioCurso)
        {
            this.repositorioCurso = repositorioCurso ?? throw new ArgumentNullException(nameof(repositorioCurso));
        }

        public async Task<long> Handle(InserirCursoCommand request, CancellationToken cancellationToken)
        {
            var curso = await repositorioCurso.SalvarAsync(request.Id, 
                                                           request.Email, 
                                                           request.Nome, 
                                                           request.Secao, 
                                                           request.TurmaId, 
                                                           request.ComponenteCurricularId, 
                                                           request.DataInclusao, 
                                                           request.DataAtualizacao);

            return curso;
        }
    }
}
