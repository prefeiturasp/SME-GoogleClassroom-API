using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarCargaCursosUseCase
    {
        Task<bool> Executar();
    }
}
