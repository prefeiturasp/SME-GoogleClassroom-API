﻿using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IIniciarSyncGoogleAtribuicoesDosProfessoresUseCase
    {
        Task<bool> Executar();
    }
}