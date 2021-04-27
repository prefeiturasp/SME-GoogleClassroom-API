using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirComparativoCursoCommandHandler : IRequestHandler<InserirComparativoCursoCommand, bool>
    {
        private readonly IRepositorioCursoComparativo repositorioCursoComparativo;

        public InserirComparativoCursoCommandHandler(IRepositorioCursoComparativo repositorioCursoComparativo)
        {
            this.repositorioCursoComparativo = repositorioCursoComparativo ?? throw new ArgumentNullException(nameof(repositorioCursoComparativo));
        }

        public async Task<bool> Handle(InserirComparativoCursoCommand request, CancellationToken cancellationToken)
        {
            var cursoComparativo = new CursoComparativo
            {
                Id = request.Id,
                Nome = request.Nome,
                Secao = request.Secao,
                Descricao = request.Descricao,
                CriadorId = request.CriadorId,
                DataInclusao = request.DataInclusao
            };

            var curso = await repositorioCursoComparativo.SalvarAsync(cursoComparativo);
            return curso > 0;
        }
    }
}
