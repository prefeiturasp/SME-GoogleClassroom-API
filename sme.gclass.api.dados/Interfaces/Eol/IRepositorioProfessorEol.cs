using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioProfessorEol
    {
        Task<PaginacaoResultadoDto<ProfessorParaIncluirGoogleDto>> ObterProfessoresParaInclusaoAsync(DateTime dataReferencia, Paginacao paginacao);
    }
}