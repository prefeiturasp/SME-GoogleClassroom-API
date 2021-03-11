using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresCursosGoogleUseCase : IObterProfessoresCursosGoogleUseCase
    {
        private readonly IMediator mediator;

        public ObterProfessoresCursosGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<ProfessorCursosCadastradosDto>> Executar(FiltroObterProfessoresCursosCadastradosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            return await mediator.Send(new ObterProfessoresCursosGoogleQuery(paginacao, filtro.Rf, filtro.TurmaId, filtro.ComponenteCurricularId));
        }
    }
}
