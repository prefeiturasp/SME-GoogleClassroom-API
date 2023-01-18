using System;
using System.Linq;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class LancarFrequenciaCommandHandler : IRequestHandler<LancarFrequenciaCommand, bool>
    {
        private readonly IMediator mediator;

        public LancarFrequenciaCommandHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        public async Task<bool> Handle(LancarFrequenciaCommand request, CancellationToken cancellationToken)
        {
            if (request.FrequenciaSalvarAulaAlunos == null || !request.FrequenciaSalvarAulaAlunos.Any())
                return false;
            
            foreach(var frequenciaAula in request.FrequenciaSalvarAulaAlunos)
            {
                var frequencia = new FrequenciaDto(frequenciaAula.AulaId);

                foreach(var frequenciaAluno in frequenciaAula.Alunos)
                {
                    frequencia.ListaFrequencia.Add(new RegistroFrequenciaAlunoDto()
                    {
                        CodigoAluno = frequenciaAluno.CodigoAluno,
                        Aulas = frequenciaAluno.Frequencias.ToList()
                    });
                }

                await mediator.Send(new PublicaFilaRabbitSgpCommand(RotasRabbitSgp.RotaFrequenciaLancamentoAulaSgaSync, frequencia,frequenciaAula.UsuarioLogado));
            }
            return true;
        }
    }
}
