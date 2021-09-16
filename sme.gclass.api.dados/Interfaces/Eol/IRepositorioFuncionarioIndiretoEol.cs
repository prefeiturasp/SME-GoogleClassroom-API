using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados.Interfaces
{
    public interface IRepositorioFuncionarioIndiretoEol
    {
        Task<PaginacaoResultadoDto<FuncionarioIndiretoEol>> ObterFuncionariosIndiretosParaInclusaoAsync(DateTime dataReferencia, Paginacao paginacao, string cpf);

        Task<PaginacaoResultadoDto<FuncionarioIndiretoEol>> ObterFuncionariosIndiretosQueSeraoInativadosPaginados(Paginacao paginacao, string cpf);

        Task<IEnumerable<string>> ObterFuncionariosIndiretosQueSeraoInativados(string cpf);
    }
}