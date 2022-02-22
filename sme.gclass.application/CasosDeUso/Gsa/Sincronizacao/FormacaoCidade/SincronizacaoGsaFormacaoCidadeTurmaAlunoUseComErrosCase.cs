using MediatR;
using Microsoft.Extensions.Configuration;
using Polly.Registry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizacaoGsaFormacaoCidadeTurmaAlunoComErrosUseCase : AbstractTratarFilaErrosUseCase<AlunoCursoEol>, ISincronizacaoGsaFormacaoCidadeTurmaAlunoComErrosUseCase
    {
        public SincronizacaoGsaFormacaoCidadeTurmaAlunoComErrosUseCase(IConfiguration configuration, IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
            : base(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAlunoErro, RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAluno, configuration, mediator, registry)
        {
        }
    }
}