using MediatR;
using Microsoft.Extensions.Configuration;
using Polly.Registry;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
    {
        public class ProcessarUsuarioGsaComErrosUseCase : AbstractTratarFilaErrosUseCase<UsuarioGsaDto>, IProcessarUsuarioGsaComErrosUseCase
    {
            public ProcessarUsuarioGsaComErrosUseCase(IConfiguration configuration, IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
                : base(RotasRabbit.FilaGsaUsuarioIncluirErro, RotasRabbit.FilaGsaUsuarioIncluir, configuration, mediator, registry)
            {
            }
        }
    }