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
            if (request.FrequenciaSalvarAulaAlunos == null)
                return false;

            var frequenciaSalvarAulaAlunos = request.FrequenciaSalvarAulaAlunos;
            
            var frequencia = new FrequenciaDto(frequenciaSalvarAulaAlunos.AulaId);

            foreach(var frequenciaAluno in frequenciaSalvarAulaAlunos.Alunos)
            {
                frequencia.ListaFrequencia.Add(new RegistroFrequenciaAlunoDto()
                {
                    CodigoAluno = frequenciaAluno.CodigoAluno,
                    Aulas = frequenciaAluno.Frequencias.ToList()
                });
            }

            await mediator.Send(new PublicaFilaRabbitSgpCommand(RotasRabbitSgp.RotaFrequenciaLancamentoAulaSync, frequencia,frequenciaSalvarAulaAlunos.UsuarioLogado, string.Empty, frequenciaSalvarAulaAlunos.PerfilUsuario));
            return true;
        }
    }
}
