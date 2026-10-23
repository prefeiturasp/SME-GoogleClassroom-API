using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Curso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterGradesAtuaisDeCursosQueryHandler : IRequestHandler<ObterGradesAtuaisDeCursosQuery, PaginacaoResultadoDto<CursoGoogleDto>>
    {
        private readonly IRepositorioCurso repositorioCurso;
        public ObterGradesAtuaisDeCursosQueryHandler(IRepositorioCurso repositorioCurso)
        {
            this.repositorioCurso = repositorioCurso ?? throw new ArgumentNullException(nameof(repositorioCurso));
        }

        public async Task<PaginacaoResultadoDto<CursoGoogleDto>> Handle(ObterGradesAtuaisDeCursosQuery request, CancellationToken cancellationToken)
        {
            PaginacaoResultadoDto<CursoGoogleDto> gradesAtuais = await repositorioCurso.ObterTodosCursosAsync(request.Paginacao, null, null, null, String.Empty);
            gradesAtuais.Items = gradesAtuais.Items.Where(x => x.DataInclusao >= request.UltimaDataExecucao);
            return gradesAtuais;
        }            
    }
}
