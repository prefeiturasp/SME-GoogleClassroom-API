using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IIniciarCargaCursosGsaUseCase
    {
        Task<bool> Executar();
    }
}
