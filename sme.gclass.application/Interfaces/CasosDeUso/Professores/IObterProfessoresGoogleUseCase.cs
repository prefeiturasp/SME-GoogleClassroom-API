﻿using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterProfessoresGoogleUseCase
    {
        Task<PaginacaoResultadoDto<ProfessorGoogle>> Executar(int registrosQuantidade, int paginaNumero, long? rf, string email);
    }
}