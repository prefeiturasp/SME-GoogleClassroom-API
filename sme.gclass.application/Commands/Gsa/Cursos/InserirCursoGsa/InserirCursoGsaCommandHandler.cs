using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirCursoGsaCommandHandler : IRequestHandler<InserirCursoGsaCommand, bool>
    {
        private readonly IRepositorioCursoGsa repositorioCursoComparativo;

        public InserirCursoGsaCommandHandler(IRepositorioCursoGsa repositorioCursoComparativo)
        {
            this.repositorioCursoComparativo = repositorioCursoComparativo ?? throw new ArgumentNullException(nameof(repositorioCursoComparativo));
        }

        public async Task<bool> Handle(InserirCursoGsaCommand request, CancellationToken cancellationToken)
        {
            var cursoComparativo = new CursoGsa
            {
                Id = request.Id,
                Nome = request.Nome,
                Secao = request.Secao,
                Descricao = request.Descricao,
                CriadorId = request.CriadorId,
                InseridoManualmenteGoogle = request.InseridoManualmenteGoogle,
                DataInclusao = request.DataInclusao
            };

            var curso = await repositorioCursoComparativo.SalvarAsync(cursoComparativo);
            return curso > 0;
        }
    }
}
