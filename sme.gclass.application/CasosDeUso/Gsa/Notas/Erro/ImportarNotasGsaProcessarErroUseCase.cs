﻿using MediatR;
using Microsoft.Extensions.Configuration;
using Polly.Registry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ImportarNotasGsaProcessarErroUseCase : AbstractTratarFilaErrosUseCase<PaginaConsultaNotasGsaDto>, IImportarNotasGsaProcessarErroUseCase
    {
        public ImportarNotasGsaProcessarErroUseCase(IConfiguration configuration, IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
            : base(RotasRabbit.FilaGsaNotasImportarErro, RotasRabbit.FilaGsaNotasImportar, configuration, mediator, registry)
        {
        }
    }
}