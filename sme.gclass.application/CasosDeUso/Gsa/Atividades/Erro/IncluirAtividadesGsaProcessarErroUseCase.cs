using MediatR;
using Microsoft.Extensions.Configuration;
using Polly.Registry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirAtividadesGsaProcessarErroUseCase : AbstractTratarFilaErrosUseCase<AtividadeGsaDto>, IIncluirAtividadesGsaProcessarErroUseCase
    {
        public IncluirAtividadesGsaProcessarErroUseCase(IConfiguration configuration, IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
            : base(RotasRabbit.FilaGsaAtividadesIncluirErro, RotasRabbit.FilaGsaAtividadesIncluir, configuration, mediator, registry)
        {
        }
    }
}