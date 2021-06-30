using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncGoogleFuncionarioUseCase : IIniciarSyncGoogleFuncionarioUseCase
    {
        private readonly IMediator mediator;

        public IniciarSyncGoogleFuncionarioUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar()
        {
            var publicarSyncFuncionario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaFuncionarioSync, RotasRabbit.FilaFuncionarioSync, true));

            if (!publicarSyncFuncionario)
                throw new NegocioException("Não foi possível iniciar a sincronização de funcionários.");

            return publicarSyncFuncionario;
        }

        public async Task<bool> Executar(long rf)
        {
            ValidarRF(rf);

            var filaProfessorSync = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorSync, RotasRabbit.FilaProfessorSync, rf));

            if (!filaProfessorSync)
                throw new NegocioException($"Não foi possível iniciar a sincronização do funcionário RF {rf}.");

            return filaProfessorSync;            
        }

        public void ValidarRF(long rf)
        {
            if (rf < 1)
                throw new ArgumentNullException(nameof(rf), "O RF deve ser informado.");
        }
    }
}