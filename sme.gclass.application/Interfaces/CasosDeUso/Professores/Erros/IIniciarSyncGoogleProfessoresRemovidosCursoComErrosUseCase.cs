﻿using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Interfaces
{
    public interface IIniciarSyncGoogleProfessoresRemovidosCursoComErrosUseCase
    {
        Task<bool> Executar();
    }
}