﻿using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public interface IObterAlunosInativosUseCase
    {
        Task<PaginacaoResultadoDto<UsuarioInativoDto>> Executar(FiltroObterAlunosInativosDto filtro);
    }
}
