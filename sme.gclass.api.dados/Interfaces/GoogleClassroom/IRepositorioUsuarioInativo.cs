using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Dados
{
    public interface IRepositorioUsuarioInativo
    {
        Task<bool> InativarUsuarioAsync(long usuarioId, UsuarioTipo tipo, DateTime inativadoEm);
        Task LimparAsync();

        Task<PaginacaoResultadoDto<UsuarioInativo>> ObterAlunosInativos(Paginacao paginacao);
    }
}
