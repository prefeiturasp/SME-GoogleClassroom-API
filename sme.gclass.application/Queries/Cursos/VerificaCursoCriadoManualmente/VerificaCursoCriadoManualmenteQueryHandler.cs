using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class VerificaCursoCriadoManualmenteQueryHandler : IRequestHandler<VerificaCursoCriadoManualmenteQuery, bool>
    {
        IRepositorioCurso repositorioCursos;
        public VerificaCursoCriadoManualmenteQueryHandler(IRepositorioCurso repositorioCursos)
        {
            this.repositorioCursos = repositorioCursos ?? throw new ArgumentNullException(nameof(repositorioCursos));
        }
        public async Task<bool> Handle(VerificaCursoCriadoManualmenteQuery request, CancellationToken cancellationToken)
             => await repositorioCursos.VerificaSeFoiCriadoManualmente(request.CursoId);           
    }
}
