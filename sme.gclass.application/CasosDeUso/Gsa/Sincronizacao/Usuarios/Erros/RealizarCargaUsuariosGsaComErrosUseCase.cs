using MediatR;
using Microsoft.Extensions.Configuration;
using Polly.Registry;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
    {
        public class RealizarCargaUsuariosGsaComErrosUseCase : AbstractTratarFilaErrosUseCase<FiltroCargaGsaDto>, IRealizarCargaUsuariosGsaComErrosUseCase
    {
            public RealizarCargaUsuariosGsaComErrosUseCase(IConfiguration configuration, IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
                : base(RotasRabbit.FilaGsaUsuarioCarregarErro, RotasRabbit.FilaGsaUsuarioCarregar, configuration, mediator, registry)
            {
            }
        }
    }