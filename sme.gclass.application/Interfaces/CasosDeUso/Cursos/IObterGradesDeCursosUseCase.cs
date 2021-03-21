﻿using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterGradesDeCursosUseCase
    {
        Task<PaginacaoResultadoDto<GradeCursoEol>> Executar(FiltroObterGradesDeCursosDto filtro);
    }
}