using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterCursosCadastradosUseCase
    {
        Task<IEnumerable<Curso>> Executar(int registrosQuantidade, int paginaNumero);
    }
}
