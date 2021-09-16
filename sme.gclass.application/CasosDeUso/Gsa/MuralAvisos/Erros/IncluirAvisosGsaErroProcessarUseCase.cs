using MediatR;
using Microsoft.Extensions.Configuration;
using Polly.Registry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirAvisosGsaErroProcessarUseCase : AbstractTratarFilaErrosUseCase<AvisoMuralGsaDto>, IIncluirAvisosGsaErroProcessarUseCase
    {
        public IncluirAvisosGsaErroProcessarUseCase(IConfiguration configuration, IReadOnlyPolicyRegistry<string> registry, IMediator mediator)
            : base(RotasRabbit.FilaGsaMuralAvisosIncluirErro, RotasRabbit.FilaGsaMuralAvisosIncluir, configuration, mediator, registry)
        {
        }
    }
}
